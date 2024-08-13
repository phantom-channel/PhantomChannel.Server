using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PhantomChannel.Server.Api.Models;

namespace PhantomChannel.Server.Api.Filters;


public class DtoFilter : ResultFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {

        if (!context.ModelState.IsValid)
        {
            CheckValidation(context, out var errors);

            var response = new ApiResponse<Dictionary<string, string>>(HttpStatusCode.BadRequest, "请求参数错误", errors);

            context.Result = new JsonResult(response);
        }
    }

    private static void CheckValidation(ActionContext context, out Dictionary<string, string> errors
    )
    {
        errors = [];
        foreach (var key in context.ModelState.Keys)
        {
            var state = context.ModelState[key];
            if (state?.ValidationState != ModelValidationState.Invalid) continue;
            var error = state.Errors.FirstOrDefault();

            if (error == null)
            {
                continue;
            }
            var ErrKey = key;
            var ErrMsg = error.ErrorMessage;

            if (ErrKey.StartsWith("$."))
            {
                ErrKey = ErrKey[2..];
                ErrMsg = "格式错误";
            }


            if (errors.ContainsKey(ErrKey))
            {
                errors[ErrKey] += $",{ErrMsg}";
                continue;
            }

            errors.Add(ErrKey, ErrMsg);
        }

    }
}