using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.TemplateDto
{
  public class TemplateRepresentation : IDtoRepresentation
  {
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AverageTimeToFinish { get; set; } = string.Empty;
    public string Video { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CoinsEarnedIfFinished { get; set; }

  }
}
