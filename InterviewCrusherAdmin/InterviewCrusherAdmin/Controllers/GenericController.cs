using InterviewCrusherAdmin.BusinessLogic.GenericCrud.DeleteDocument;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocument;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.ReplaceDocument;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateAlgorithm;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;
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

    [HttpPost("GenerateVideo")]
    public async Task<IActionResult> GenerateVideo([FromBody] InsertDocumentRequest<GeneratedVideoDto, GenerateVideo> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpPost("GenerateAlgorithm")]
    public async Task<IActionResult> GenerateAlgorithm([FromBody] InsertDocumentRequest<GeneratedAlgorithmDto, GenerateAlgorithm> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpPost("GenerateQuiz")]
    public async Task<IActionResult> GenerateQuiz([FromBody] InsertDocumentRequest<GenerateQuizDto, GenerateQuiz> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpPost("GenerateTemplate")]
    public async Task<IActionResult> GenerateQuiz([FromBody] InsertDocumentRequest<GenerateTemplateDto, GenerateTemplate> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpDelete("DeleteGeneratedTemplate")]
    public async Task<IActionResult> DeleteDocument([FromBody] DeleteDocumentRequest<GenerateTemplate> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpGet("GetGeneratedTemplate")]
    public async Task<IActionResult> GetDocument([FromQuery] GetDocumentRequest<GenerateTemplateDto, GenerateTemplate> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpPut("ReplaceGeneratedTemplate")]
    public async Task<IActionResult> ReplaceDocument([FromBody] ReplaceDocumentRequest<GenerateTemplate> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }
  }
}
