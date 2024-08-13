using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PhantomChannel.Server.Domain.Enums;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// UserEntity: 用户实体类
/// </summary>
[Table("user")]
[Index(nameof(Username), nameof(Email), IsUnique = true)]
public class UserEntity : BaseEntity
{
    [Description("用户名")]
    [Column("username")]

    public required string Username { get; set; }

    [Description("用户昵称")]
    [Column("nickname")]
    public required string Nickname { get; set; }

    [Description("头像")]
    [Column("avatar")]
    public required string? Avatar { get; set; }

    [Description("邮箱")]
    [Column("email")]
    public required string Email { get; set; }

    [Description("密码")]
    [Column("password")]
    public required string Password { get; set; }


    [Description("用户角色")]
    [Column("role")]
    [DefaultValue(new RoleEnum[] { RoleEnum.User })]
    public required RoleEnum[] Role { get; set; }

}
