
using InterviewCrusherAdmin.DataAbstraction.Database;

namespace InterviewCrusherAdmin.Database.DatabaseConfiguration
{
  public class DatabaseConfiguration : IDatabaseConfiguration
  {
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }
}
