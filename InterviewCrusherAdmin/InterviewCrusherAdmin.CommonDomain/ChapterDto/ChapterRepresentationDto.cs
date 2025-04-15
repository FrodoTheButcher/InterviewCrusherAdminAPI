using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusher.AbstractDomain.Chapter;

public class ChapterRepresentationDto : BaseChapterDto, IDtoRepresentation
{
  public ChapterRepresentationDto() { }

  public ChapterRepresentationDto(string title, string templateId, string description, string sourceLink, string sourceCode)
  {
    this.Title = title;
    this.ParentId = templateId;
    this.Description = description;
    this.SourceLink = sourceLink;
    this.SourceCode = sourceCode;
  }

}
