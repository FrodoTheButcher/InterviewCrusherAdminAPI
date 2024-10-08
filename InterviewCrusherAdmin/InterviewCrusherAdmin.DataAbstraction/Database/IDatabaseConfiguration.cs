namespace InterviewCrusherAdmin.DataAbstraction.Database
{
  public interface IDatabaseConfiguration
  {
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }
  }
}
