namespace InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository
{
  public interface IAutoIncrementDatabaseEntity
  {
    public string TemplateId { get; set; }

    public ushort ExerciseNumber {  get; set; }

    public string Title {  get; set; }
  }
}
