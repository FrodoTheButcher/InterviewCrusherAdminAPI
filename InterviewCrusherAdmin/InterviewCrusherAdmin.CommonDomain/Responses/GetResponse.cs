using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.Responses
{
  public class GetResponse<T> 
    where T : IDtoRepresentation
  {
    public T? Data { get; set; }
  }
}
