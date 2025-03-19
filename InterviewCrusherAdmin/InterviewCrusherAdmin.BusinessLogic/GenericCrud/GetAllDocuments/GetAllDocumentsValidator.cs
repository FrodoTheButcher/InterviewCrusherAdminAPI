using FluentValidation;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocument;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetAllDocuments
{
  public class GetAllDocumentsValidator<DtoRepresentation, DatabaseEntityRepresentation> : AbstractValidator<GetAllDocumentsRequest<DtoRepresentation, DatabaseEntityRepresentation>>
  where DtoRepresentation : IDtoRepresentation
  where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
    public GetAllDocumentsValidator()
    {
    }
  }
}
