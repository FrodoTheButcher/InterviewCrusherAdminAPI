using InterviewCrusherAdmin.DataAbstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace InterviewCrusherAdmin.CommonDomain.QuizDto
{
  public class QuizRepresentationDto : IDtoRepresentation
  {
    [BsonRepresentation(BsonType.ObjectId)]
    public string ParentId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public List<QuizAnswersDto> QuizAnswers { get; set; } = new List<QuizAnswersDto>();

  }
}
