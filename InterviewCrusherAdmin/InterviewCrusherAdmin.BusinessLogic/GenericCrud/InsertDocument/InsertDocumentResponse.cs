using InterviewCrusherAdmin.CommonDomain.Responses;
using InterviewCrusherAdmin.DataAbstraction.Extensions;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument
{
  public class InsertDocumentResponse : CreateResponse
  {
    public InsertDocumentResponse(string id)
    {
      Id = id;
      IsCreated = id.IsValidObjectId();
      Message = IsCreated ? "Document created successfully" : "Document creation failed";
    }
  }
}
