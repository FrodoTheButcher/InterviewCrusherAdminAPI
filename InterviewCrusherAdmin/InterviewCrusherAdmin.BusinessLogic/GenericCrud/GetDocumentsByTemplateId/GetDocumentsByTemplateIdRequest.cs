using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetAllDocuments;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocument;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.CommonDomain.Requests;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsByTemplateId
{
  public class GetDocumentsByTemplateIdRequest<DatabaseEntityRepresentation> : GetRequest, IRequest<GetDocumentsByTemplateIdResponse>
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation , IAutoIncrementEntity
  {
  }
}
