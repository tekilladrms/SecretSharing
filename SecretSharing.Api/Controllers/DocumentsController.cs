using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecretSharing.Application.Documents.Commands.CreateDocument;
using SecretSharing.Application.Documents.Commands.CreateDocumentFromText;
using SecretSharing.Application.Documents.Commands.DeleteDocument;
using SecretSharing.Application.Documents.Queries.GetAllDocumentsByUserId;
using SecretSharing.Application.Documents.Queries.GetDocumentByKey;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecretSharing.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/user/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> GetAllAsync(GetAllDocumentsByUserIdQuery request)
        {
            var results = await _mediator.Send(request);

            return Ok(results);
        }

        [HttpPost("download")]
        public async Task<FileStreamResult> DownloadDocumentByKey(DownloadDocumentByKeyQuery request)
        {
            var (result, contentType) = await _mediator.Send(request);

            return new FileStreamResult(result, contentType)
            {
                FileDownloadName = request.FileName,
            };
        }

        [HttpPost("file")]
        public async Task<IActionResult> PostFromFile([FromQuery] CreateDocumentFromFileCommand request)
        {
            var document = await _mediator.Send(request);

            if (document is null) return BadRequest();

            return Ok(document);
        }

        [HttpPost("text")]
        public async Task<IActionResult> PostFromText(CreateDocumentFromTextCommand request)
        {
            var document = await _mediator.Send(request);

            if (document is null) return BadRequest();

            return Ok(document);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete([FromQuery] DeleteDocumentCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
