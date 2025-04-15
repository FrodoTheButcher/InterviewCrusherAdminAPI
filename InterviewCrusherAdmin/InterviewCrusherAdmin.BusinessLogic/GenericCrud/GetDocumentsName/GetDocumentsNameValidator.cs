using FluentValidation;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsName
{
  public class GetDocumentsNameValidator<DatabaseEntityRepresentation> : AbstractValidator<GetDocumentsNameRequest<DatabaseEntityRepresentation>>
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
    public GetDocumentsNameValidator()
    {
    }
  }
}
