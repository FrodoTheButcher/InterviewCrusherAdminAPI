namespace InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto
{
  public class GenerateQuizAnswerDto
  {
    public string Name { get; set; } = string.Empty;

    public bool IsCorrect { get; set; } = false;

    public string Explanation { get; set; } = string.Empty;
  }
}
