using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using System.Net;

namespace InterviewCrusherAdmin.CommonDomain.Responses
{
  public class GetAllResponse<T> : Response
    where T : IDtoRepresentation
  {
    public GetAllResponse() { }
    public List<T>? Data { get; set; }
    public GetAllResponse(List<T> data)
    {
      this.Data = data;
      this.StatusCode = data?.Count != null ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound;
      this.Message = data?.Count != null ? HttpStatusCode.OK.GetDescription() : HttpStatusCode.NotFound.GetDescription();
    }
  }
}
