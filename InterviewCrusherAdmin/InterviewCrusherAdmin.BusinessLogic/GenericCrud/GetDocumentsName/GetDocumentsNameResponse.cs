using InterviewCrusherAdmin.CommonDomain.AbstractImplementations;
using InterviewCrusherAdmin.CommonDomain.Responses;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsName
{
  public class GetDocumentsNameResponse : GetAllResponse<BaseDataEntity>
  {
    public GetDocumentsNameResponse(List<BaseDataEntity> baseDataEntities):base(baseDataEntities) { }
  }
}
