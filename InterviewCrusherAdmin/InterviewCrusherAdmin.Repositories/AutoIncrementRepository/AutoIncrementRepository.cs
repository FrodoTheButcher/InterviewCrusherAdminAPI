using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Database;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using InterviewCrusherAdmin.Domain.Chapter;
using MongoDB.Driver;

namespace InterviewCrusherAdmin.Repositories.AutoIncrementRepository
{
    public class AutoIncrementRepository<T> : IAutoIncrementRepository<T>
    where T : IDatabaseEntityRepresentation, IAutoIncrementEntity
  {
    private readonly IMongoCollection<T> _collection;

    public AutoIncrementRepository(IDatabase database)
    {
      _collection = database.GetMongoCollection<T>();
    }
    public async Task<string> CreateAutoIncrementAsync(T entity, CancellationToken cancellationToken)
    {
      var filter = Builders<T>.Filter.Eq(x => x.ParentId, entity.ParentId);
      var size = await this._collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);

      if (size > ushort.MaxValue)
      {
          //Custom exception
      }
      else
      {
        entity.ExerciseNumber = (ushort)(size + 1);
      }
      await this._collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
      return entity.Id;
    }

    public async Task<List<AutoIncrementEntityResponse>> GetByTemplateIdSortedByNumber(string templateId, CancellationToken cancellationToken)
    {
      List<AutoIncrementEntityResponse> result = await this._collection.Find(Builders<T>.Filter.Eq(x=>x.ParentId , templateId)).Project(Builders<T>.Projection.Include(x=>x.Id).Include(x=>x.ParentId).Include(x=>x.ExerciseNumber)).As<AutoIncrementEntityResponse>().ToListAsync(cancellationToken);
      return result;
    }
  }
}
