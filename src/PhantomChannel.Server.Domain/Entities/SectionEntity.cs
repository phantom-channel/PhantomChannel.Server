using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// SectionEntity: 版块实体类
/// </summary>
[Table("section")]
public class SectionEntity : BaseEntity
{
    [Description("版块名称")]
    [Column("name")]
    public required string Name { get; set; }

    [Description("版块描述")]
    [Column("description")]
    public string? Description { get; set; }

    [Description("版块图标")]
    [Column("icon")]
    public string? Icon { get; set; }

    [Description("版块管理员")]
    [Column("admin_id")]
    public required long[] AdminId { get; set; }

}
