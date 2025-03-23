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

  }
}
