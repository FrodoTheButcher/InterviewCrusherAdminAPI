using InterviewCrusherAdmin.DataAbstraction.Database;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.Domain.Chapter;
using MongoDB.Driver;

namespace InterviewCrusherAdmin.Repositories.ChapterRepresentationRepository
{
  public class ChapterRepresentationRepository : IChapterRepresentationRepository
  {
    private readonly IMongoCollection<ChapterRepresentation> chapterRepresentationCollection;

    public ChapterRepresentationRepository(IDatabase database)
    {
      if (database == null)
      {
        throw new DependencyException<IDatabase>();
      }
      this.chapterRepresentationCollection = database.GetMongoCollection<ChapterRepresentation>();
    }
    public async Task<string> CreateAsync(ChapterRepresentation entity, CancellationToken cancellationToken)
    {
      await this.chapterRepresentationCollection.InsertOneAsync(entity, cancellationToken: cancellationToken);
      return entity.Id;
    }

    public async Task<string> CreateAutoIncrementAsync(ChapterRepresentation entity, CancellationToken cancellationToken)
    {
      var filter = Builders<ChapterRepresentation>.Filter.Eq(x => x.TemplateId, entity.TemplateId);
      var size = await this.chapterRepresentationCollection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);
   
      if (size > ushort.MaxValue)
      {
        //todo exception
      }
      else
      {
        entity.NumberChapter = (ushort)(size + 1);
      }
      await this.chapterRepresentationCollection.InsertOneAsync(entity, cancellationToken: cancellationToken);
      return entity.Id;
    }
    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
      var filter = Builders<ChapterRepresentation>.Filter.Eq(x => x.Id, id);
      var update = Builders<ChapterRepresentation>.Update.Set(x => x.Deleted, true);
      var response = await this.chapterRepresentationCollection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
      if (response.MatchedCount == 0)
      {
        throw new KeyNotFoundException();
      }
      return response.ModifiedCount > 0;
    }

    public async Task<List<ChapterRepresentation>> GetByTemplateIdSortedByNumber(string templateId, CancellationToken cancellationToken)
    {
      var filter = Builders<ChapterRepresentation>.Filter.Eq(x => x.TemplateId, templateId);
      var documents = await this.chapterRepresentationCollection.Find(filter).SortBy(x => x.NumberChapter).ToListAsync(cancellationToken: cancellationToken);
      return documents;
    }

    public Task<List<ChapterRepresentation>?> GetAllAsync(CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<ChapterRepresentation?> GetAsync(string id, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<bool> ReplaceAsync(string id, ChapterRepresentation entity, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<bool> RestoreAsync(string id, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ChapterRepresentation entity, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
