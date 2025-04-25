using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusher.AbstractDomain.Chapter
{
  public class BaseChapter : BaseChapterDto, IDatabaseEntityRepresentation, IAutoIncrementEntity
  {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public bool Deleted { get; set; }
  }
}
