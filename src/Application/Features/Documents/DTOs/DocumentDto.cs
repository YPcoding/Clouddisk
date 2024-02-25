namespace Application.Features.Documents.DTOs;

/// <summary>
/// 用户信息
/// </summary>
[Map(typeof(Document))]
public class DocumentDto
{
    /// <summary>
    /// 唯一标识
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 文档唯一标识
    /// </summary>
    public long DocumentId
    {
        get
        {
            return Id;
        }
    }

    /// <summary>
    /// 名称
    /// </summary>
    [Description("名称")]
    public string Name { get; set; }

    /// <summary>
    /// 后缀名
    /// </summary>
    [Description("后缀名")]
    public string? Extension { get; set; }

    /// <summary>
    /// 别名
    /// </summary>
    [Description("别名")]
    public Guid? AliasName { get; set; }

    /// <summary>
    /// 路径
    /// </summary>
    [Description("路径")]
    public string? Path { get; set; }

    /// <summary>
    /// 字节大小
    /// </summary>
    [Description("字节大小")]
    public long SizeByte { get; set; }

    /// <summary>
    /// 文件是否保存
    /// </summary>
    [Description("文件是否保存")]
    public bool? IsFileSaved { get; set; }

    /// <summary>
    /// 父级
    /// </summary>
    [Description("父级")]
    public long? ParentId { get; set; } = null;

    /// <summary>
    /// 乐观并发标记
    /// </summary>
    [Description("乐观并发标记")]
    public string ConcurrencyStamp { get; set; }
}

