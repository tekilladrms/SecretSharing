using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecretSharing.Application.Documents.Commands.CreateDocument;
using SecretSharing.Application.Documents.Commands.DeleteDocument;
using SecretSharing.Application.Documents.Commands.UpdateDocument;
using SecretSharing.Application.Documents.Queries.GetDocumentById;
using SecretSharing.Application.Documents.Queries.GetDocumentsByUser;
using SecretSharing.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecretSharing.Api.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/documents
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(Guid userId)
        {
            //var results = await _mediator.Send(new GetDocumentsByUserIdQuery(userId));

            //if (results is null || !results.Any()) return BadRequest();

            //return Ok(results);
        }

        // GET api/documents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid documentId)
        {
            var document = await _mediator.Send(new GetDocumentByIdQuery(documentId));

            if(document is null) return BadRequest();

            return Ok(document);
        }

        // POST api/documents
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DocumentDto documentDto, Guid UserPrifileId)
        {
            var document = await _mediator.Send(new CreateDocumentCommand(documentDto, UserPrifileId));

            if(document is null) return BadRequest();

            return Created($"api/documents/{document.Name}", document);
        }

        // PUT api/documents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] DocumentDto documentDto)
        {
            var document = await _mediator.Send(new UpdateDocumentCommand(documentDto));

            if(document is null) return BadRequest(); 

            return Ok(document);
        }

        // DELETE api/documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid documentId, Guid)
        {
            return Ok(await _mediator.Send(new DeleteDocumentCommand(documentId)));
        }
    }
}
