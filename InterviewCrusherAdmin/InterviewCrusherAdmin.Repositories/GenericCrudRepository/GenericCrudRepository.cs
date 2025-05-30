﻿using InterviewCrusherAdmin.CommonDomain.AbstractImplementations;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Database;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InterviewCrusherAdmin.Repositories.GenericCrudRepository
{
  public class GenericCrudRepository<T> : IGenericCrudRepository<T>
      where T : IDatabaseEntityRepresentation
  {
    private readonly IMongoCollection<T> _collection;

    public GenericCrudRepository(IDatabase database)
    {
      _collection = database.GetMongoDatabase().GetCollection<T>(typeof(T).Name);
    }

    public async Task<string> CreateAsync(T entity, CancellationToken cancellationToken)
    {
      await this._collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
      return entity.Id;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
      return (await this._collection.DeleteOneAsync(Builders<T>.Filter.Eq(e => e.Id, id), cancellationToken)).DeletedCount == 0;
    }

    public async Task<List<T>?> GetAllAsync(CancellationToken cancellationToken)
    {
      return await this._collection.Find(Builders<T>.Filter.Empty).ToListAsync(cancellationToken);
    }

    public async Task<T>? GetAsync(string id, CancellationToken cancellationToken)
    {
      var objectId = ObjectId.Parse(id);

      return await this._collection.Find(Builders<T>.Filter.Eq(e => e.Id, objectId.ToString())).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<IBaseDataEntity>> GetBaseDatas(CancellationToken cancellationToken)
    {
      return (await this._collection
          .Aggregate()
          .Match(c => c.Deleted == false)
          .As<BaseDataEntity>()
          .Project<BaseDataEntity>(Builders<BaseDataEntity>.Projection
              .Include(x => x.Id)
              .Include(x => x.Title))
          .ToListAsync(cancellationToken))
          .Cast<IBaseDataEntity>()
          .ToList();
    }


    public async Task<bool> ReplaceAsync(string id, T entity, CancellationToken cancellationToken)
    {
      return (await this._collection.ReplaceOneAsync(Builders<T>.Filter.Eq(e => e.Id, id), entity, cancellationToken: cancellationToken)).MatchedCount == 0;
    }

    public async Task<bool> RestoreAsync(string id, CancellationToken cancellationToken)
    {
      return (await this._collection.UpdateOneAsync(Builders<T>.Filter.Eq(e => e.Id, id), Builders<T>.Update.Set(e => e.Deleted, false), cancellationToken: cancellationToken)).ModifiedCount == 1;
    }

    public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
