using InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateChapters;
using InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterviewCrusherAdmin.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TemplateController : ControllerBase
  {
    private readonly IMediator mediator;

    public TemplateController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    [HttpGet(UrlConstants.TemplateController.GET_TEMPLATE_NAMES)]
    public async Task<IActionResult> GetTemplateNames(CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(new GetTemplateNamesRequest(), cancellationToken);
      return this.ToActionResult(response);
    }

    [HttpGet(UrlConstants.TemplateController.GET_TEMPLATE_WITH_CHAPTER_NAMES + "/{id}")]
    public async Task<IActionResult> GetTemplateWithChapterNames(string id, CancellationToken cancellationToken)
    {
      var response = await this.mediator.Send(new GetTemplateChaptersRequest(id), cancellationToken);
      return this.ToActionResult(response);
    }
  }
}
