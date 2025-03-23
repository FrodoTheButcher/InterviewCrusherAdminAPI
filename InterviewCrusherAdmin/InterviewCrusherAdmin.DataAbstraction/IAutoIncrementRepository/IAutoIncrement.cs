namespace InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository
{
  public interface IAutoIncrement
  {
    public string TemplateId { get; set; }

    public int ExerciseNumber {  get; set; }

    public string Name {  get; set; }
  }
}
