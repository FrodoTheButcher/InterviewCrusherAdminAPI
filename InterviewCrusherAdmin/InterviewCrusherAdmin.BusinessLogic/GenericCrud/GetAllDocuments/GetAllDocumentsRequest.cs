using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocument;
using InterviewCrusherAdmin.CommonDomain.Requests;
using InterviewCrusherAdmin.DataAbstraction;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetAllDocuments
{
  public class GetAllDocumentsRequest<DtoRepresentation, DatabaseEntityRepresentation> : GetAllRequest, IRequest<GetAllDocumentsResponse<DtoRepresentation>>
     where DtoRepresentation : IDtoRepresentation
     where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
  }
}
