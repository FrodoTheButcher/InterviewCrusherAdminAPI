using FluentValidation;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.ReplaceDocument
{
  public class ReplaceDocumentValidator<DatabaseEntityRepresentation> 
    : AbstractValidator<ReplaceDocumentRequest<DatabaseEntityRepresentation>>
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
    public ReplaceDocumentValidator()
    {
      this.RuleFor(request => request.DocumentToReplace).NotNull();
      this.RuleFor(x => x.DocumentToReplace.Id)
                    .Must(id => id.IsValidObjectId())
                    .When(request => request.DocumentToReplace != null);
    }
  }
}
