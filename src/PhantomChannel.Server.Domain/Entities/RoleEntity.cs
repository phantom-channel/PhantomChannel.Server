using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using PhantomChannel.Server.Domain.Enums;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// RoleEntity: 角色实体类
/// </summary>
[Table("role")]
public class RoleEntity : BaseEntity
{
    [Description("角色名称")]
    [Column("name")]
    public required string Name { get; set; }

    [Description("角色描述")]
    [Column("description")]
    public string? Description { get; set; }

    [Description("角色权限")]
    [Column("permissions")]
    public required string[] Permissions { get; set; }

}
