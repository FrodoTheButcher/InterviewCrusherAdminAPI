using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.CommonDomain.Requests;
using InterviewCrusherAdmin.DataAbstraction;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.DeleteDocument
{
  public class DeleteDocumentRequest<DtoRepresentation, DbEntityRepresentation> 
    : DeleteRequest, IRequest<DeleteDocumentResponse> where DtoRepresentation : IDtoRepresentation where DbEntityRepresentation : IDatabaseEntityRepresentation
  {
  }
}
