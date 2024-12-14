using FluentValidation;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.DeleteDocument
{
  public class DeleteDocumentValidator<DbEntityRepresentation> : AbstractValidator<DeleteDocumentRequest<DbEntityRepresentation>>
    where DbEntityRepresentation : IDatabaseEntityRepresentation
  {
    public DeleteDocumentValidator()
    {
      RuleFor(x => x.Id.IsValidObjectId()).Equal(true);
    }
  }
}
