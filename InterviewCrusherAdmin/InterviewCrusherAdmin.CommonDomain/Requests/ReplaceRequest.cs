using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.Requests
{
  public class ReplaceRequest<DatabaseEntityRepresentation> : Request
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
    public DatabaseEntityRepresentation? DocumentToReplace { get; set; }
  }
}
