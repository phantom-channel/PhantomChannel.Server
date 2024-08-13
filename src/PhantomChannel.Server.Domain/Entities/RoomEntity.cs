using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// RoomEntity: 房间实体类
/// </summary>
[Table("room")]
public class RoomEntity : BaseEntity
{
    [Description("房间名称")]
    [Column("name")]
    public required string Name { get; set; }

    [Description("房间描述")]
    [Column("description")]
    public string? Description { get; set; }

    [Description("房间图标")]
    [Column("icon")]
    public string? Icon { get; set; }

    [Description("房间管理员")]
    [Column("admin_id")]
    public required long[] AdminId { get; set; }

    [Description("房间版块")]
    [Column("section_id")]
    public required long? SectionId { get; set; }

    [Description("是否公开房间")]
    [Column("is_public")]
    [DefaultValue(false)]
    public bool? IsPublic { get; set; }

}
