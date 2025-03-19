using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Database;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate;
using MongoDB.Driver;

namespace InterviewCrusherAdmin.Database
{
  public class Database : IDatabase
  {
    private readonly IDatabaseConfiguration _databaseConfiguration;
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _mongoDatabase;
    public Database(IDatabaseConfiguration databaseConfiguration)
    {
      _databaseConfiguration = databaseConfiguration ??
          throw new ArgumentNullException(nameof(databaseConfiguration), "Database configuration cannot be null");

      _mongoClient = new MongoClient(_databaseConfiguration.ConnectionString);
      _mongoDatabase = _mongoClient.GetDatabase(_databaseConfiguration.DatabaseName);
    }
    public IMongoDatabase GetMongoDatabase()
    {
      return _mongoDatabase;
    }

    public IMongoCollection<T> GetMongoCollection<T>()
      where T : IDatabaseEntityRepresentation
    {
      return _mongoDatabase.GetCollection<T>(typeof(T).Name);
    }
  }
}
