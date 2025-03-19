using Amazon.Runtime.Internal;
using InterviewCrusherAdmin.CommonDomain.Requests;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateChapters
{
  public class GetTemplateChaptersRequest : GetRequest, IRequest<GetTemplateChaptersResponse>
  {
    public GetTemplateChaptersRequest() { }

    public GetTemplateChaptersRequest(string id) : base(id) { }
  }
}
