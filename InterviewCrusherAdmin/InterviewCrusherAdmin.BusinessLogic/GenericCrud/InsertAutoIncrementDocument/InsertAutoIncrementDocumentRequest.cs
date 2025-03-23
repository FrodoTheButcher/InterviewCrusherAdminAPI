using InterviewCrusherAdmin.CommonDomain.Requests;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertAutoIncrementDocument
{
  public class InsertAutoIncrementDocumentRequest<DtoRepresentation, DbEntityRepresentation> : InsertRequest<DtoRepresentation>, IRequest<InsertAutoIncrementDocumentResponse> where DtoRepresentation : IDtoRepresentation where DbEntityRepresentation : IDatabaseEntityRepresentation, IAutoIncrementDatabaseEntity
  {

  }
}
