using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecretSharing.Application.Documents.Commands.CreateDocument;
using SecretSharing.Application.Documents.Commands.CreateDocumentFromText;
using SecretSharing.Application.Documents.Commands.DeleteDocument;
using SecretSharing.Application.Documents.Queries.GetAllDocumentsByUserId;
using SecretSharing.Application.Documents.Queries.GetDocumentByKey;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecretSharing.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync(string userId)
        {
            var results = await _mediator.Send(new GetAllDocumentsByUserIdQuery(userId));

            if (results is null || !results.Any()) return BadRequest();

            return Ok(results);
        }

        [HttpGet("download")]
        public async Task<FileStreamResult> DownloadDocumentByKey(string userId, string fileName, string path)
        {
            var (result, contentType) = await _mediator.Send(new DownloadDocumentByKeyQuery(userId, fileName, path));

            return new FileStreamResult(result, contentType)
            {
                FileDownloadName = fileName
            };
        }

        [HttpPost("file")]
        public async Task<IActionResult> PostFromFile(IFormFile file, string userId)
        {
            var document = await _mediator.Send(new CreateDocumentFromFileCommand(file, userId));

            if(document is null) return BadRequest();

            return Ok(document);
        }

        [HttpPost("text")]
        public async Task<IActionResult> PostFromText(string text, string title, string userId)
        {
            var document = await _mediator.Send(new CreateDocumentFromTextCommand(text, title, userId));

            if(document is null) return BadRequest();
            
            return Ok(document);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string userId, string fileName)
        {
            return Ok(await _mediator.Send(new DeleteDocumentCommand(userId, fileName)));
        }
    }
}
