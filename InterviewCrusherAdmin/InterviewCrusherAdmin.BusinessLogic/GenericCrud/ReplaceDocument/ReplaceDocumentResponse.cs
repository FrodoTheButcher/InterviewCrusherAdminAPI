using InterviewCrusherAdmin.CommonDomain.Responses;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.ReplaceDocument
{
  public class ReplaceDocumentResponse : UpdateResponse
  {
    public ReplaceDocumentResponse(bool DocumentUpdated)
      : base(DocumentUpdated)
    {
    }
  }
}
