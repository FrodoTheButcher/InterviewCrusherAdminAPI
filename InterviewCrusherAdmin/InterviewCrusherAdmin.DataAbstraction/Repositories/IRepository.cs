namespace InterviewCrusherAdmin.DataAbstraction.Repositories
{
  public interface IRepository <T> : IDependencyRepresentation
    where T : IDatabaseEntityRepresentation
  {
    Task<string> CreateAsync(T entity, CancellationToken cancellationToken);

    Task<T?> GetAsync(string id, CancellationToken cancellationToken);

    Task<List<T>?> GetAllAsync(CancellationToken cancellationToken);

    Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);

    Task<bool> ReplaceAsync(string id, T entity, CancellationToken cancellationToken);

    Task<bool> RestoreAsync(string id, CancellationToken cancellationToken);
  }
}
