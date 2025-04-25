using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusher.AbstractDomain.Algorithm
{
  public class BaseAlgorithmDto : IDtoRepresentation
  {
    public string Title { get; set; } = string.Empty;
    public ushort ExerciseNumber { get; set; } = ushort.MinValue;

    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public bool AllLanguagesAvailable { get; set; } = false;

    public string CompletedCode { get; set; } = string.Empty;
    [BsonRepresentation(BsonType.ObjectId)]
    public string ParentId { get; set; } = string.Empty;
  }
}
