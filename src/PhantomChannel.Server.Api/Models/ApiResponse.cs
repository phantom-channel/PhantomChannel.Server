// Models/ApiResponse.cs
using System.Net;
using Microsoft.EntityFrameworkCore;
namespace PhantomChannel.Server.Api.Models;


/// <summary>
/// 通用响应模型
/// </summary>
/// <typeparam name="T"></typeparam>
public class ApiResponse<T>
{

    public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;

    public string Msg { get; set; }

    public T Data { get; set; }

    public ApiResponse(HttpStatusCode code, string msg, T data)
    {
        Code = code;
        Msg = msg;
        Data = data;
    }

    public ApiResponse(T data)
    {
        Msg = "请求成功";
        Data = data;
    }

    public ApiResponse(string msg, T data)
    {
        Msg = msg;
        Data = data;
    }

}

public class ApiResponse
{
    public HttpStatusCode Code { get; set; }
    public string Msg { get; set; }
    public object? Data { get; set; } = null;

    public ApiResponse(HttpStatusCode code, string msg)
    {
        Code = code;
        Msg = msg;
    }
    public ApiResponse()
    {
        Code = HttpStatusCode.OK;
        Msg = "请求成功";
    }
    public ApiResponse(string msg)
    {
        Code = HttpStatusCode.OK;
        Msg = msg;
    }
    public ApiResponse(HttpStatusCode code)
    {
        Code = code;
        Msg = "请求成功";
    }
}

