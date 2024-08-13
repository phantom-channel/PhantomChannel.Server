// 角色身份的枚举
namespace PhantomChannel.Server.Domain.Enums;
public enum MessageTypeEnum
{
    /// <summary>
    /// 文本消息
    /// </summary>
    Text = 1,

    /// <summary>
    /// 图片消息
    /// </summary>
    Image = 2,

    /// <summary>
    /// 文件消息
    /// </summary>
    File = 3,

    /// <summary>
    /// 音频消息
    /// </summary>
    Audio = 4,

    /// <summary>
    /// 视频消息
    /// </summary>
    Video = 5,

    /// <summary>
    /// 链接消息
    /// </summary>
    Link = 6,

    /// <summary>
    /// 位置消息
    /// </summary>
    Location = 7,

    /// <summary>
    /// 通知消息
    /// </summary>
    Notice = 8,

    /// <summary>
    /// 系统消息
    /// </summary>
    System = 9,

    /// <summary>
    /// Markdown消息
    /// </summary>
    Markdown = 10,
}