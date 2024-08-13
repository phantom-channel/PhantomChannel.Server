using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// CommentEntity: 留言实体类
/// </summary>
[Table("comment")]
public class CommentEntity : BaseEntity
{
    [Description("留言内容")]
    [Column("content")]
    public required string Content { get; set; }

    [Description("留言用户")]
    [Column("user_id")]
    public long UserId { get; set; }

    [Description("留言帖子")]
    [Column("post_id")]
    public long PostId { get; set; }

    [Description("回复的留言")]
    [Column("reply_id")]
    public long? ReplyId { get; set; }

    [Description("投票值")]
    [Column("vote")]
    public bool? Vote { get; set; }

}
