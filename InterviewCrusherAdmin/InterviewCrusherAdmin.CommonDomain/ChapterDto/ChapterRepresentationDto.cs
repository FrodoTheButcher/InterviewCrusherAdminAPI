using InterviewCrusherAdmin.DataAbstraction;
using System.Text.Json.Serialization;

public class ChapterRepresentationDto : IDtoRepresentation
{
  public ChapterRepresentationDto() { }

  public ChapterRepresentationDto(string title, string templateId, string description, string sourceLink, string sourceCode)
  {
    this.Title = title;
    this.TemplateId = templateId;
    this.Description = description;
    this.SourceLink = sourceLink;
    this.SourceCode = sourceCode;
  }

  [JsonPropertyName("title")]
  public string Title { get; set; } = string.Empty;

  [JsonPropertyName("templateId")]
  public string TemplateId { get; set; } = string.Empty;

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;

  [JsonPropertyName("sourceLink")]
  public string SourceLink { get; set; } = string.Empty;

  [JsonPropertyName("sourceCode")]
  public string SourceCode { get; set; } = string.Empty;
}
