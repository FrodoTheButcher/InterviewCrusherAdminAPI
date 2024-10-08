using MongoDB.Driver;

namespace InterviewCrusherAdmin.DataAbstraction.Database
{
  public interface IDatabase
  {
    IMongoDatabase GetMongoDatabase();
  }
}
