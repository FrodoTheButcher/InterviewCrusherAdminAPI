namespace InterviewCrusherAdmin.CommonDomain.Responses
{
  public class CreateResponse : Response
  {
    public bool IsCreated { get; set; }

    public string Id { get; set; } = string.Empty;
  }
}
