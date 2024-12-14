using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter;

namespace InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto
{
  public class GenerateTemplateDto : IDtoRepresentation
    {
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string AvarageTimeToFinish { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int Difficulty { get; set; }

    public List<GenerateChapter> Chapters { get; set; }
  }
}
