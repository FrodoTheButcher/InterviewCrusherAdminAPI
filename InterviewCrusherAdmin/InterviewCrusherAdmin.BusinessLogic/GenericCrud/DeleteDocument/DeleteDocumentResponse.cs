using InterviewCrusherAdmin.CommonDomain.Responses;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.DeleteDocument
{
  public class DeleteDocumentResponse : DeleteResponse
  {
    public DeleteDocumentResponse(bool DocumentDeleted)
      : base(DocumentDeleted)
    {
    }
  }
}
