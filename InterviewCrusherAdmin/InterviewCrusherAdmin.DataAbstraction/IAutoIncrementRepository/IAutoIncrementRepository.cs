using InterviewCrusherAdmin.DataAbstraction.Repositories;

namespace InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository
{
  public interface IAutoIncrementRepository<T>
    where T : IDatabaseEntityRepresentation, IAutoIncrement
  {
    public Task<string> CreateAutoIncrementAsync(T entity, CancellationToken cancellationToken);
    public Task<List<AutoIncrementEntityResponse>> GetByTemplateIdSortedByNumber(string templateId, CancellationToken cancellationToken);
  }
}
