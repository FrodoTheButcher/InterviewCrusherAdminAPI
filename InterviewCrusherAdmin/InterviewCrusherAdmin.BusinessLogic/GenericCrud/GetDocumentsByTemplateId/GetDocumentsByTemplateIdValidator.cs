using FluentValidation;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsByTemplateId
{
  public class GetDocumentsByTemplateIdValidator<DatabaseEntityRepresentation> : AbstractValidator<GetDocumentsByTemplateIdRequest<DatabaseEntityRepresentation>>
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation, IAutoIncrementDatabaseEntity
  {
    public GetDocumentsByTemplateIdValidator()
    {
      this.RuleFor(x => x.Id.IsValidObjectId()).Equal(true);
    }
  }
}
