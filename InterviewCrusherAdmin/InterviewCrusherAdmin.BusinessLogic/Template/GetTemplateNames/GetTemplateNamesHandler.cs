using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain.Template;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames
{
  public class GetTemplateNamesHandler : IRequestHandler<GetTemplateNamesRequest, GetTemplateNamesResponse>
  {
    private readonly ITemplateRepository templateRepository;

    public GetTemplateNamesHandler(ITemplateRepository templateRepository)
    {
      this.templateRepository = templateRepository ?? throw new DependencyException<ITemplateRepository>();
    }
    public async Task<GetTemplateNamesResponse> Handle(GetTemplateNamesRequest request, CancellationToken cancellationToken)
    {
      var templateNames = await this.templateRepository.GetTemplateNames(cancellationToken);
      return new GetTemplateNamesResponse(templateNames);
    }
  }
}
