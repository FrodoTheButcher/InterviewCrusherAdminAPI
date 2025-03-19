using InterviewCrusherAdmin.CommonDomain.ChapterDto;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto
{
  public class GenerateTemplateDto : IDtoRepresentation
    {
    public string? Id { get; set; } = null;
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string AvarageTimeToFinish { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int Difficulty { get; set; }

    public List<GeneratedChapterDto> GeneratedChaptersDtos { get; set; } = new List<GeneratedChapterDto>();
  }
}
