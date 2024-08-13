using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using PhantomChannel.Server.Domain.Enums;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// MessageEntity: 消息实体类
/// </summary>
[Table("message")]
public class MessageEntity : BaseEntity
{
    [Description("消息内容")]
    [Column("content")]
    public required string Content { get; set; }

    [Description("消息类型")]
    [Column("type")]
    [DefaultValue(MessageTypeEnum.Text)]
    public required MessageTypeEnum Type { get; set; }

    [Description("消息发送者")]
    [Column("sender_id")]
    public required long SenderId { get; set; }

    [Description("消息接收者")]
    [Column("receiver_id")]
    public required long ReceiverId { get; set; }

    // 接收者类型
    [Description("接收者类型")]
    [Column("receiver_type")]
    [DefaultValue(ReceiverTypeEnum.User)]
    public required ReceiverTypeEnum ReceiverType { get; set; }

}
