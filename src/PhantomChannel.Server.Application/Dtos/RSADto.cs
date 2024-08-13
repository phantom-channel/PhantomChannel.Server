using System.ComponentModel.DataAnnotations;

namespace PhantomChannel.Server.Application.Dtos;

public class RSADto
{
    // 必传,字符串类型,长度最大为 100,自定义错误信息
    [StringLength(100, ErrorMessage = "长度不能超过100")]
    public string? Key { get; set; } = null!;
    // 必传,字符串类型,长度最大为 100,自定义错误信息
    public int? Key2 { get; set; }
}