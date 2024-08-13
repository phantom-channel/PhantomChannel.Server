using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhantomChannel.Server.Domain.Enums;

namespace PhantomChannel.Server.Domain.Entities;

/// <summary>
/// DictionaryEntity: 字典实体类
/// </summary>
[Table("dictionary")]
public class DictionaryEntity : BaseEntity
{
    [Description("字典名称")]
    [Column("name")]
    public required string Name { get; set; }

    [Description("字典键")]
    [Column("key")]
    public required string Type { get; set; }

    [Description("字典值")]
    [Column("value")]
    public required string Value { get; set; }

    [Description("字典描述")]
    [Column("description")]
    public string? Description { get; set; }

    [Description("排序")]
    [Column("sort")]
    public int Sort { get; set; }

    [Description("是否只读")]
    [Column("is_readonly")]
    [DefaultValue(false)]
    public bool IsReadonly { get; set; }


    [Description("父级ID")]
    [Column("parent_id")]
    public long? ParentId { get; set; }


}
