using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using System.Net;

namespace InterviewCrusherAdmin.CommonDomain.Responses
{
  public class GetResponse<T> :Response
    where T : IDtoRepresentation
  {
    public T? Data { get; set; }

    public GetResponse() { }
    public GetResponse(T data) {
    this.Data = data;
    this.StatusCode = data != null ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound;
    this.Message = data != null ? HttpStatusCode.OK.GetDescription() : HttpStatusCode.NotFound.GetDescription();
    }
  }
}
