using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using InterviewCrusher.AbstractDomain.Quiz;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusher.AbstractDomain.Algorithm
{
  public class BaseAlgorithm : BaseAlgorithmDto, IDatabaseEntityRepresentation, IAutoIncrementEntity
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string Id { get; set; } = string.Empty;
    public bool Deleted { get; set; }

  }
}
