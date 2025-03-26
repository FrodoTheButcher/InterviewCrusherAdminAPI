using InterviewCrusherAdmin.DataAbstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

public class ChapterRepresentationDto : IDtoRepresentation
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

  [JsonPropertyName("title")]
  public string Title { get; set; } = string.Empty;

  [JsonPropertyName("templateId")]
  [BsonRepresentation(BsonType.ObjectId)]
  public string ParentId { get; set; } = string.Empty;

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;

  [JsonPropertyName("sourceLink")]
  public string SourceLink { get; set; } = string.Empty;

  [JsonPropertyName("sourceCode")]
  public string SourceCode { get; set; } = string.Empty;
}
