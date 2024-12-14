using InterviewCrusherAdmin.DataAbstraction.Extensions;
using System.Net;

namespace InterviewCrusherAdmin.CommonDomain.Responses
{
  public class Response
  {
    public HttpStatusCode StatusCode { get; set; }

    public string Message { get; set; } = string.Empty;
  }
}
