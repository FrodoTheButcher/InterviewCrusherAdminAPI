using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.Domain.Template;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateChapters
{
  public class GetTemplateChaptersHandler : IRequestHandler<GetTemplateChaptersRequest, GetTemplateChaptersResponse>
  {
    private readonly ITemplateRepository templateRepository;

    public GetTemplateChaptersHandler(ITemplateRepository templateRepository)
    {
      this.templateRepository = templateRepository ?? throw new DependencyException<ITemplateRepository>();
    }
    public async Task<GetTemplateChaptersResponse> Handle(GetTemplateChaptersRequest request, CancellationToken cancellationToken)
    {
      var response = await this.templateRepository.GetTemplateWithChapterNames(request.Id, cancellationToken);
      return new GetTemplateChaptersResponse(response);
    }
  }
}
