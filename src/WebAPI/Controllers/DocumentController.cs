using Application.Features.Documents.Commands.Add;
using Application.Features.Documents.Commands.Delete;
using Application.Features.Documents.Commands.Move;
using Application.Features.Documents.Commands.Rename;
using Application.Features.Documents.DTOs;
using Application.Features.Documents.Queries.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace WebAPI.Controllers
{
    /// <summary>
    /// 文档管理
    /// </summary>
    [AllowAnonymous]
    [Description("文档管理")]
    public class DocumentController : ApiControllerBase
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("PaginationQuery")]
        public async Task<Result<PaginatedData<DocumentDto>>> PaginationQuery(DocumentsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// 添加文档
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Add")]
        public async Task<Result<long>> Add(AddDocumentCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// 重命名
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("Rename")]
        public async Task<Result<bool>> Rename(RenameDocumentCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// 移动文档
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("Move")]
        public async Task<Result<bool>> Move(MoveDocumentCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// 删除文档
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpDelete("Delete")]
        public async Task<Result<bool>> Delete(DeleteDocumentCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
