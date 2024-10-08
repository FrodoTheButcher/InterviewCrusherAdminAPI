namespace InterviewCrusherAdmin.CommonDomain.Responses
{
  public class GetAllResponse<T>
    where T : class
  {
    public List<T>? Data { get; set; }
  }
}
