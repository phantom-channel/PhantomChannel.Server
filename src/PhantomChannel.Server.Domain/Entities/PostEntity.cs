using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// PostEntity: 帖子实体类
/// </summary>
[Table("post")]
public class PostEntity : BaseEntity
{
    [Description("帖子标题")]
    [Column("title")]
    public required string Title { get; set; }

    [Description("帖子内容")]
    [Column("content")]
    public required string Content { get; set; }

    [Description("帖子作者")]
    [Column("author_id")]
    public required long AuthorId { get; set; }

    [Description("帖子所属房间")]
    [Column("section_id")]
    public required long RoomId { get; set; }

    [Description("是否投票")]
    [Column("is_vote")]
    public bool? IsVote { get; set; }

}
