namespace InterviewCrusherAdmin.CommonDomain.Requests
{
  public class GetRequest : Request
  {
    public string Id { get; set; } = string.Empty;

    public GetRequest() { }
    public GetRequest(string id)
    {
      Id = id;
    }
  }
}
