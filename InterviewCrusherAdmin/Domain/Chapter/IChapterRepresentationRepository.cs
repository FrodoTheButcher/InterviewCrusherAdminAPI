using InterviewCrusherAdmin.DataAbstraction.Repositories;

namespace InterviewCrusherAdmin.Domain.Chapter
{
  public interface IChapterRepresentationRepository : IRepository<ChapterRepresentation>
  {
    public Task<string> CreateAutoIncrementAsync(ChapterRepresentation entity, CancellationToken cancellationToken);
    public Task<List<ChapterRepresentation>> GetByTemplateIdSortedByNumber(string templateId, CancellationToken cancellationToken);
  }
}
