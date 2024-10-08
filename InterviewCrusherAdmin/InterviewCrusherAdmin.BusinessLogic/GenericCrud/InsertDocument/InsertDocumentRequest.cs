using InterviewCrusherAdmin.CommonDomain.Requests;
using InterviewCrusherAdmin.DataAbstraction;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument
{
  public class InsertDocumentRequest<DtoRepresentation , DbEntityRepresentation> : InsertRequest<DtoRepresentation>, IRequest<InsertDocumentResponse> where DtoRepresentation : IDtoRepresentation where DbEntityRepresentation : IDatabaseEntityRepresentation
  {
  }
}
