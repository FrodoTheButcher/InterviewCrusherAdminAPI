using InterviewCrusherAdmin.BusinessLogic.GenericCrud.DeleteDocument;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetAllDocuments;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocument;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertAutoIncrementDocument;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.ReplaceDocument;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm;
using InterviewCrusherAdmin.CommonDomain.ChapterDto;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;
using InterviewCrusherAdmin.Domain.Chapter;
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

    [HttpPost(UrlConstants.GenericController.GENERATE_VIDEO)]
    public async Task<IActionResult> GenerateVideo([FromBody] InsertDocumentRequest<GeneratedVideoDto, GenerateVideo> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpPost(UrlConstants.GenericController.GENERATE_ALGORITHM)]
    public async Task<IActionResult> GenerateAlgorithm([FromBody] InsertDocumentRequest<GeneratedAlgorithmDto, GenerateAlgorithm> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpPost(UrlConstants.GenericController.GENERATE_QUIZ)]
    public async Task<IActionResult> GenerateQuiz([FromBody] InsertDocumentRequest<GeneratedQuizDto, GenerateQuiz> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpPost(UrlConstants.GenericController.GENERATE_TEMPLATE)]
    public async Task<IActionResult> GenerateTemplate([FromBody] InsertDocumentRequest<GenerateTemplateDto, GenerateTemplate> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpPost(UrlConstants.GenericController.INITIALIZE_TEMPLATE)]
    public async Task<IActionResult> InitializeTemplate([FromBody] InsertDocumentRequest<TemplateRepresentation, GenerateTemplate> request, CancellationToken cancellationToken)
    {
        var response = await this.mediator.Send(request);
        return this.ToActionResult(response);
    }

    [HttpPost(UrlConstants.GenericController.INSERT_AUTO_INCREMENT_CHAPTER)]
    public async Task<IActionResult> InitializeChapter([FromBody] InsertAutoIncrementDocumentRequest<ChapterRepresentationDto, ChapterRepresentation> request, CancellationToken cancellationToken)
    {
        var response = await this.mediator.Send(request);
        return this.ToActionResult(response);
    }

    [HttpPost(UrlConstants.GenericController.INITIALIZE_CHAPTER)]

    [HttpDelete(UrlConstants.GenericController.DELETE_GENERATED_TEMPLATE + "/{id}")]
    public async Task<IActionResult> DeleteDocument(string id, CancellationToken cancellationToken)
    {
      DeleteDocumentRequest<GenerateTemplate> request = new() { Id = id };
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpGet(UrlConstants.GenericController.GET_GENERATED_TEMPLATE + "/{id}")]
    public async Task<IActionResult> GetDocument(string id, CancellationToken cancellationToken)
    {
      GetDocumentRequest<GenerateTemplateDto, GenerateTemplate> request = new() { Id = id };
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpGet(UrlConstants.GenericController.GET_GENERATED_TEMPLATES)]
    public async Task<IActionResult> GetAllDocuments(CancellationToken cancellationToken)
    {
      GetAllDocumentsRequest<GenerateTemplateDto, GenerateTemplate> request = new();
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }

    [HttpPut(UrlConstants.GenericController.REPLACE_GENERATED_TEMPLATE)]
    public async Task<IActionResult> ReplaceDocument(ReplaceDocumentRequest<GenerateTemplate> request, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(request);
      return this.ToActionResult(response);
    }
  }
}
