using InterviewCrusherAdmin.CommonDomain.Responses;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetAllDocuments
{
  public class GetAllDocumentsResponse<DtoRepresentation> : GetAllResponse<DtoRepresentation>
     where DtoRepresentation : IDtoRepresentation
  {
    public GetAllDocumentsResponse(List<DtoRepresentation> data) : base(data)
    {
    }
  }
}
