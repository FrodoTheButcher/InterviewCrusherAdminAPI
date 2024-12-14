using InterviewCrusherAdmin.CommonDomain.Requests;
using InterviewCrusherAdmin.DataAbstraction;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.ReplaceDocument
{
  public class ReplaceDocumentRequest<DatabaseEntityRepresentation> : ReplaceRequest<DatabaseEntityRepresentation> , IRequest<ReplaceDocumentResponse>
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
  }
}
