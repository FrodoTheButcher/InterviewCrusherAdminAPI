using MongoDB.Driver;

namespace InterviewCrusherAdmin.DataAbstraction.Database
{
  public interface IDatabase : IDependencyRepresentation
  {
    IMongoDatabase GetMongoDatabase();

    public IMongoCollection<T> GetMongoCollection<T>()
      where T : IDatabaseEntityRepresentation;
  }
}
