using FluentValidation;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertAutoIncrementDocument
{
  public class InsertAutoIncrementDocumentValidator<DtoRepresentation, DbEntityRepresentation> : AbstractValidator<InsertAutoIncrementDocumentRequest<DtoRepresentation, DbEntityRepresentation>>
    where DtoRepresentation : IDtoRepresentation
    where DbEntityRepresentation : IDatabaseEntityRepresentation , IAutoIncrementDatabaseEntity
  {
    public InsertAutoIncrementDocumentValidator()
    {
      RuleFor(x => x.DocumentToInsert).NotNull();
    }
  }
}
