using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using InterviewCrusherAdmin.Domain.Quiz;

namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz
{
  public class GenerateQuiz : IDatabaseEntityRepresentation, IAutoIncrementEntity
  {
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public List<GenerateQuizAnswer> QuizAnswers { get; set; } = new List<GenerateQuizAnswer>();
    public string ParentId { get; set; } = string.Empty;
    public ushort ExerciseNumber { get; set; } = ushort.MinValue;
  }
}
