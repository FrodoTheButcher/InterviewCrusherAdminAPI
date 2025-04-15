using InterviewCrusherAdmin.CommonDomain.Requests;
using InterviewCrusherAdmin.DataAbstraction;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsName
{
  public class GetDocumentsNameRequest<DatabaseEntityRepresentation> : GetAllRequest, IRequest<GetDocumentsNameResponse>
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
  }
}
