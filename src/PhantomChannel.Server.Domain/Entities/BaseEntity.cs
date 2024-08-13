using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhantomChannel.Server.Domain.Enums;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// BaseEntity: 基础实体类
/// </summary>
[Table("base")]
public abstract class BaseEntity
{
    /// <summary>
    /// Id: 自增主键Id
    /// </summary>
    [Description("主键")]
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    /// <summary>
    /// Status 0: 
    /// </summary>
    [Description("状态")]
    [Column("status")]
    [DefaultValue(StatusEnum.Normal)]
    public StatusEnum Status { get; set; }

    /// <summary>
    /// CreateTime: 创建时间
    /// </summary>
    [Description("创建时间")]
    [Column("create_time")]
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// UpdateTime: 更新时间
    /// </summary>
    [Description("更新时间")]
    [Column("update_time")]
    public DateTime UpdateTime { get; set; }
}

