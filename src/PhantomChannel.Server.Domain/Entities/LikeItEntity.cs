using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhantomChannel.Server.Domain.Enums;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// LikeItEntity: 点赞统计实体类
/// </summary>
[Table("like_it")]
public class LikeItEntity : BaseEntity
{
    [Description("点赞用户")]
    [Column("user_id")]
    public required long UserId { get; set; }

    [Description("点赞帖子")]
    [Column("post_id")]
    public long? PostId { get; set; }

    [Description("点赞评论")]
    [Column("comment_id")]
    public long? CommentId { get; set; }

}
