using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto
{
  public class GeneratedQuizDto : IDtoRepresentation
  {
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public List<GenerateQuizAnswerDto> QuizAnswers { get; set; } = new List<GenerateQuizAnswerDto>();
    public string ParentId { get; set; } = string.Empty;
  }
}
