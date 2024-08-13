using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using PhantomChannel.Server.Domain.Enums;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// QuerysEntity: 请求操作记录 实体类
/// </summary>
[Table("views")]
public class QueryEntity : BaseEntity
{
    [Description("IP")]
    [Column("ip")]
    public string? Ip { get; set; }

    [Description("方法")]
    [Column("method")]
    public string? Method { get; set; }

    [Description("主机")]
    [Column("host")]
    public string? Host { get; set; }

    [Description("路径")]
    [Column("path")]
    public string? Path { get; set; }

    [Description("搜索")]
    [Column("search")]
    public string? Search { get; set; }

    [Description("来自用户")]
    [Column("from_user_id")]
    public long? FromUserId { get; set; }

    [Description("设备类型")]
    [Column("device_type")]
    [DefaultValue(DeviceTypeEnum.Unknown)]
    public int DeviceType { get; set; }

    [Description("哈希识别码,无隐私信息")]
    [Column("device_code")]
    public string? DeviceCode { get; set; }

}
