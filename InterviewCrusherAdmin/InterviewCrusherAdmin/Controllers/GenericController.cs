using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterviewCrusherAdmin.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GenericController : ControllerBase
  {
    private readonly IMediator mediator;

    public GenericController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> InsertVideo([FromBody] InsertDocumentRequest<GeneratedVideoDto, GenerateVideo> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }
  }
}
