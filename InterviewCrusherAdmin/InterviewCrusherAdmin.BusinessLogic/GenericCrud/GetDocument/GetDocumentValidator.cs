using FluentValidation;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocument
{
  public class GetDocumentValidator<DtoRepresentation, DatabaseEntityRepresentation> : AbstractValidator<GetDocumentRequest<DtoRepresentation,DatabaseEntityRepresentation>>
    where DtoRepresentation : IDtoRepresentation
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
    public GetDocumentValidator()
    {
      this.RuleFor(x => x.Id.IsValidObjectId()).Equal(true);
    }
  }
}
