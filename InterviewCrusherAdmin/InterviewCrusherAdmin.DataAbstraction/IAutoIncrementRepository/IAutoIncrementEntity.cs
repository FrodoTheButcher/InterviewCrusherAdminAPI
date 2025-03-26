namespace InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository
{
  public interface IAutoIncrementEntity
  {
    public string ParentId { get; set; }

    public ushort ExerciseNumber {  get; set; }

    public string Title {  get; set; }
  }
}
