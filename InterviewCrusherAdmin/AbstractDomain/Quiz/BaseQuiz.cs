using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace InterviewCrusher.AbstractDomain.Quiz
{
  public class BaseQuiz : BaseQuizDto, IDatabaseEntityRepresentation, IAutoIncrementEntity
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string Id { get; set; } = string.Empty;
    public bool Deleted { get; set; }

    public ushort ExerciseNumber { get; set; }

    //todo remove
    public string ChapterId { get; set; } = string.Empty;
  }
}
