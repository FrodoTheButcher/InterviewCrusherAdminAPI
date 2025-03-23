using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;

namespace InterviewCrusherAdmin.Domain.Quiz
{
  public class QuizRepresentation : IDatabaseEntityRepresentation
  {
    public string ChapterId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public List<GenerateQuizAnswer> QuizAnswers { get; set; } = new List<GenerateQuizAnswer>();

    public short ExerciseNumber { get; set; } = 0;
  }
}
