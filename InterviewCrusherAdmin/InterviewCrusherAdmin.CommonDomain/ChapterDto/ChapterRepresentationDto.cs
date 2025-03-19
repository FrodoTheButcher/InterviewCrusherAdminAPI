using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.ChapterDto
{
  public class ChapterRepresentationDto : IDtoRepresentation
  {
    public ChapterRepresentationDto() { }

    public ChapterRepresentationDto(string title, string templateId, string description, string sourceLink, string sourceCode) { 
      this.Title = title;
      this.TemplateId = templateId;
      this.Description = description;
      this.SourceLink = sourceLink;
      this.SourceCode = sourceCode;
      this.SourceLink = sourceCode;
    }
    public string Title { get; set; } = string.Empty;

    public string TemplateId { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string SourceLink {  get; set; } = string.Empty;

    public string SourceCode { get; set; } = string.Empty;
  }
}
