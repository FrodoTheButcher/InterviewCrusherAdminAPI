using MongoDB.Bson;

namespace InterviewCrusherAdmin.DataAbstraction
{
  public abstract class IDatabaseEntityRepresentation
  {
    string Id { get; }

    public bool Deleted { get; set; }

    public IDatabaseEntityRepresentation()
    {
      Deleted = false;
      Id = ObjectId.GenerateNewId().ToString();
    }
  }
}
