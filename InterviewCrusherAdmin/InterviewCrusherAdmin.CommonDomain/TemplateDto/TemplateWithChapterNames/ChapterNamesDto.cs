using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.TemplateDto.TemplateWithChapterNames
{
  public class ChapterNamesDto : IDatabaseEntitySerializer
  {
    public short ChapterNumber { get; set; }

    public string ChapterName { get; set; } = string.Empty;

    public string ChapterDescription { get; set; } = string.Empty;

  }
}
