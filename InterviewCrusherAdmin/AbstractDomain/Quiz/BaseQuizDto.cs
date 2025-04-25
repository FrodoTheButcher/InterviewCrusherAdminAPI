using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusher.AbstractDomain.Quiz
{
  public class BaseQuizDto : IDtoRepresentation
  {
    [BsonRepresentation(BsonType.ObjectId)]
    public string ParentId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public List<string> Images { get; set; } = new List<string>();
  }
}
