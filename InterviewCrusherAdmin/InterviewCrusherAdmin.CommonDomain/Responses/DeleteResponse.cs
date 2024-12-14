using InterviewCrusherAdmin.DataAbstraction.Extensions;
using System.Net;

namespace InterviewCrusherAdmin.CommonDomain.Responses
{
  public class DeleteResponse : Response
  {
    public DeleteResponse(bool DocumentDeleted)
    {
      this.StatusCode = DocumentDeleted ? HttpStatusCode.OK : HttpStatusCode.NotFound;
      this.Message = DocumentDeleted ? HttpStatusCode.OK.GetDescription() : HttpStatusCode.NotFound.GetDescription();
    }
  }
}
