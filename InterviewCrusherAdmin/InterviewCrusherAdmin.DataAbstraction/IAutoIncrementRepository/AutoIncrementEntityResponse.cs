namespace InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository
{
  public class AutoIncrementEntityResponse : IDatabaseEntitySerializer
  {
    public string Name { get; set; } = string.Empty;
  }
}
