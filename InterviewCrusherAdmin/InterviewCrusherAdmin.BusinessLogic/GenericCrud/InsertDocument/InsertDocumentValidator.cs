using FluentValidation;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument
{
  public class InsertDocumentValidator<DtoRepresentation,DbEntityRepresentation> : AbstractValidator<InsertDocumentRequest<DtoRepresentation, DbEntityRepresentation>>
    where DtoRepresentation : IDtoRepresentation
    where DbEntityRepresentation : IDatabaseEntityRepresentation
  {
    public InsertDocumentValidator()
    {
      RuleFor(x => x.DocumentToInsert).NotNull();
    }
  }
}
