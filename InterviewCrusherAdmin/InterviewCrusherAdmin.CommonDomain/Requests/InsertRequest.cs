using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.Requests
{
  public class InsertRequest<T> : Request
    where T : IDtoRepresentation
  {
    public T? DocumentToInsert { get; set; }
  }
}
