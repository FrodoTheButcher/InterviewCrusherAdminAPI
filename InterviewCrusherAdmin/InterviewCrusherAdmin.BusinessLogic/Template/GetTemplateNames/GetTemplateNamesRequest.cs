using Amazon.Runtime.Internal;
using InterviewCrusherAdmin.CommonDomain.Requests;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames
{
  public class GetTemplateNamesRequest : GetAllRequest , IRequest<GetTemplateNamesResponse>
  {

  }
}
