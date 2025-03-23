using InterviewCrusherAdmin.CommonDomain.Responses;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsByTemplateId
{
  public class GetDocumentsByTemplateIdResponse : GetAllResponse<AutoIncrementEntityResponse>
  {
    public GetDocumentsByTemplateIdResponse(List<AutoIncrementEntityResponse> data) : base(data)
    {
    }
  }
}
