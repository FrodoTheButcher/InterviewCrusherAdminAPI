namespace AbstractDomain.Quiz
{
  public class BaseQuizAnswer
  {
    public string Name { get; set; } = string.Empty;

    public bool IsCorrect { get; set; } = false;

    public string Explanation { get; set; } = string.Empty;
  }
}
