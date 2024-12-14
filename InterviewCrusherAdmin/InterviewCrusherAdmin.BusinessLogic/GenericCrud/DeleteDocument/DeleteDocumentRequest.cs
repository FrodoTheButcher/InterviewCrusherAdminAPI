using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.CommonDomain.Requests;
using InterviewCrusherAdmin.DataAbstraction;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.DeleteDocument
{
  public class DeleteDocumentRequest<DbEntityRepresentation> 
    : DeleteRequest, IRequest<DeleteDocumentResponse>where DbEntityRepresentation : IDatabaseEntityRepresentation
  {
  }
}
