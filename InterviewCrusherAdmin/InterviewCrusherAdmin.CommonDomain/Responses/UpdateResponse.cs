using InterviewCrusherAdmin.DataAbstraction.Extensions;
using System.Net;

namespace InterviewCrusherAdmin.CommonDomain.Responses
{
  public class UpdateResponse : Response
  {
    public bool IsUpdated { get; set; }
    public UpdateResponse(bool isUpdated)
    {
      IsUpdated = isUpdated;
      this.StatusCode = isUpdated ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.BadRequest;
      this.Message = isUpdated ? HttpStatusCode.OK.GetDescription() : HttpStatusCode.BadRequest.GetDescription();
    }
  }
}
