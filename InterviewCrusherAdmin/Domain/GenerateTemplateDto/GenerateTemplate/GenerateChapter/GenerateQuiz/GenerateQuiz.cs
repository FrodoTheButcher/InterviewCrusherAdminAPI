using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz
{
  public class GenerateQuiz : IDatabaseEntityRepresentation
  {
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public List<GenerateQuizAnswer> QuizAnswers { get; set; }
  }
}
