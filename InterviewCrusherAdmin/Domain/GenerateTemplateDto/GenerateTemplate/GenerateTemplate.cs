using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter;

namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate
{
  public class GenerateTemplate : IDatabaseEntityRepresentation
  {
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string AvarageTimeToFinish { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int CoinsEarnedIfFinished { get; set; }

    public List<GenerateChapter.GenerateChapter> Chapters { get; set; } = new List<GenerateChapter.GenerateChapter>();
  }
}
