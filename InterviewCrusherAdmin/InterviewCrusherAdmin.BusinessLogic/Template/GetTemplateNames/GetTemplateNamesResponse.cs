using InterviewCrusherAdmin.CommonDomain.Responses;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames
{
  public class GetTemplateNamesResponse : GetAllResponse<TemplateNameDto>
  {
    public GetTemplateNamesResponse()
    {
    }
    public GetTemplateNamesResponse(List<TemplateNameDto> templateNames)
      : base(templateNames)
    {
    }
  }
}
