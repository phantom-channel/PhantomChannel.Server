using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// MenuEntity: 菜单实体类
/// </summary>
[Table("menu")]
public class MenuEntity : BaseEntity
{
    [Description("菜单名称")]
    [Column("name")]
    public required string Name { get; set; }

    [Description("菜单图标")]
    [Column("icon")]
    public required string Icon { get; set; }

    [Description("菜单路径")]
    [Column("path")]
    public required string Path { get; set; }

    [Description("菜单排序")]
    [Column("sort")]
    public required int Sort { get; set; }

    [Description("菜单域名")]
    [Column("domain")]
    public string? Domain { get; set; }

}
