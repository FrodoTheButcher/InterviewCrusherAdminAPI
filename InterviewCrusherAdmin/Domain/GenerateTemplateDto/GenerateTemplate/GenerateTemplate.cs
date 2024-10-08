namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate
{
  public class GenerateTemplate
  {
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string AvarageTimeToFinish { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int CoinsEarnedIfFinished { get; set; }
  }
}
