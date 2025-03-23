namespace InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository
{
  public class AutoIncrementEntityResponse : IDatabaseEntitySerializer, IDtoRepresentation
  {
    public string Name { get; set; } = string.Empty;
  }
}
