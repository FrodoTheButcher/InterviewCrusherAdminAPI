using AutoMapper;
using InterviewCrusherAdmin.BusinessLogic.Chapter.CreateChapterAutoIncrement;
using InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames;
using InterviewCrusherAdmin.CommonDomain.ChapterDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterviewCrusherAdmin.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ChapterController : ControllerBase
  {
    private readonly IMediator mediator;

    public ChapterController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    [HttpPost(UrlConstants.ChapterController.CREATE_CHAPTER_REPRESENTATION)]
    public async Task<IActionResult> CreateChapterRepresentation(CreateChapterRepresentationAutoIncrementRequest chapterRepresentationDto, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(chapterRepresentationDto, cancellationToken);
      return this.ToActionResult(response);
    }
  }
}
