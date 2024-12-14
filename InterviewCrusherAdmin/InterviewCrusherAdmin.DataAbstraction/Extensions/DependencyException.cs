namespace InterviewCrusherAdmin.DataAbstraction.Extensions
{
  public class DependencyException<DependencyRepresentation> : Exception
      where DependencyRepresentation : IDependencyRepresentation
  {
    public DependencyException()
        : base($"Dependency Exception: {typeof(DependencyRepresentation).Name}")
    {
    }
  }
}
