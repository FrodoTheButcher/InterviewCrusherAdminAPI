using InterviewCrusherAdmin.CommonDomain.Requests;
using InterviewCrusherAdmin.DataAbstraction;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocument
{
  public class GetDocumentRequest<DtoRepresentation, DatabaseEntityRepresentation> : GetRequest ,IRequest<GetDocumentResponse<DtoRepresentation>>
    where DtoRepresentation : IDtoRepresentation
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
  }
}
