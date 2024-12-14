using InterviewCrusherAdmin.DataAbstraction.Extensions;
using System.Net;

namespace InterviewCrusherAdmin.CommonDomain.Responses
{
  public class CreateResponse : Response
  {
    public CreateResponse(string id)
      : base()
    {
      Id = id;
      IsCreated = id.IsValidObjectId();
      Message = IsCreated ? HttpStatusCode.Created.GetDescription() : HttpStatusCode.BadRequest.GetDescription();
      this.StatusCode = IsCreated ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
    }

    public bool IsCreated { get; set; }

    public string Id { get; set; } = string.Empty;
  }
}
