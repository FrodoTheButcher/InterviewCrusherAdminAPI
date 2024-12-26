using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;

namespace InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto
{
  public class GeneratedQuizDto : IDtoRepresentation
  {
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public List<GenerateQuizAnswer> QuizAnswers { get; set; }
  }
}
