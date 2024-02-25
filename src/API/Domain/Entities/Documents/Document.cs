using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

/// <summary>
/// 文档管理
/// </summary>
[Description("文档管理")]
public class Document : BaseAuditableSoftDeleteEntity, IAuditTrial
{
    [Description("名称")]
    public string Name { get; set; }

    [Description("后缀名")]
    public string? Extension { get; set; }

    [Description("别名")]
    public Guid? AliasName { get; set; }

    [Description("路径")]
    public string? Path { get; set; }

    [Description("字节大小")]
    public long SizeByte{ get; set; }

    [Description("文件是否保存")]
    public bool? IsFileSaved { get; set; }

    [Description("父级")]
    public long? ParentId { get; set; } = null;

    [ForeignKey("ParentId")]
    public Document? Parent { get; set; } = null;

    [NotMapped]
    public IFormFile? File { get; set; }
}
