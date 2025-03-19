using FluentValidation;
using InterviewCrusherAdmin.DataAbstraction.Extensions;

namespace InterviewCrusherAdmin.BusinessLogic.Chapter.CreateChapterAutoIncrement
{
  public class CreateChapterRepresentationAutoIncrementValidator : AbstractValidator<CreateChapterRepresentationAutoIncrementRequest>
  {
    public CreateChapterRepresentationAutoIncrementValidator()
    {
      this.RuleFor(request => request.RepresentationDto.Title).MinimumLength(5);
      this.RuleFor(request => request.RepresentationDto.Description).MinimumLength(50);
      this.RuleFor(request => request.RepresentationDto.TemplateId.IsValidObjectId()).Equal(true);
    }
  }
}
