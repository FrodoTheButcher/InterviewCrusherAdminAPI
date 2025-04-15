using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto.TemplateWithChapterNames;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Database;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate;
using InterviewCrusherAdmin.Domain.Template;
using MongoDB.Driver;

namespace InterviewCrusherAdmin.Repositories.Template
{
  public class TemplateRepository : ITemplateRepository
  {
    private readonly IMongoCollection<GenerateTemplate> generatedTemplatesCollection;

    public TemplateRepository(IDatabase database)
    {
      this.generatedTemplatesCollection = database.GetMongoCollection<GenerateTemplate>();
    }
    public Task<string> CreateAsync(GenerateTemplate entity, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<List<GenerateTemplate>?> GetAllAsync(CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<GenerateTemplate?> GetAsync(string id, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<IBaseDataEntity> GetBaseData(CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<List<TemplateNameDto>> GetTemplateNames(CancellationToken cancellationToken)
    {
      return await this.generatedTemplatesCollection.Aggregate().Project(Builders<GenerateTemplate>.Projection.Include(e => e.Title).Include(e => e.Id)).As<TemplateNameDto>().ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<TemplateWithChapterNamesDto> GetTemplateWithChapterNames(string id, CancellationToken cancellationToken)
    {
      return await this.generatedTemplatesCollection
       .Aggregate()
       .Match(Builders<GenerateTemplate>.Filter.Eq(_ => _.Id, id))
       .Project(Builders<GenerateTemplate>.Projection.Expression<TemplateWithChapterNamesDto>(x => new TemplateWithChapterNamesDto
       {
         Description = x.Description,
         Id = x.Id,
         Title = x.Title,
         ChapterNamesDto = x.Chapters.Select(c => new ChapterNamesDto { ChapterDescription = c.Description, ChapterName = c.Title, ChapterNumber = 0 }).ToList()
       }))
       .As<TemplateWithChapterNamesDto>()
       .FirstOrDefaultAsync(cancellationToken: cancellationToken) ;       
    }

    public Task<bool> ReplaceAsync(string id, GenerateTemplate entity, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<bool> RestoreAsync(string id, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(GenerateTemplate entity, CancellationToken cancellationToken)
    {
     throw new NotImplementedException();
    }
  }
}
