using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.TemplateDto.TemplateWithChapterNames
{
  public class TemplateWithChapterNamesDto : IDatabaseEntitySerializer , IDtoRepresentation
  {
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<ChapterNamesDto> ChapterNamesDto { get; set; } = new List<ChapterNamesDto>();
  }
}
