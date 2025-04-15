namespace InterviewCrusherAdmin.DataAbstraction.Repositories
{
  public interface IGenericCrudRepository<T> : IDependencyRepresentation , IRepository<T>
    where T : IDatabaseEntityRepresentation
  {
    public Task<List<IBaseDataEntity>> GetBaseDatas(CancellationToken cancellationToken);
  }
}
