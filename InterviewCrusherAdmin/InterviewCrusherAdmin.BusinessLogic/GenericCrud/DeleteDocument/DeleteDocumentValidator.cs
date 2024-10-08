using FluentValidation;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.DeleteDocument
{
  public class DeleteDocumentValidator<DtoRepresentation, DbEntityRepresentation> : AbstractValidator<DeleteDocumentRequest<DtoRepresentation, DbEntityRepresentation>>
    where DtoRepresentation : IDtoRepresentation
    where DbEntityRepresentation : IDatabaseEntityRepresentation
  {
    public DeleteDocumentValidator()
    {
      RuleFor(x => x.Id.IsValidObjectId()).Equal(true);
    }
  }
}
