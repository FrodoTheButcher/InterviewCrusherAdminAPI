using InterviewCrusherAdmin.CommonDomain.Responses;
using InterviewCrusherAdmin.CommonDomain.TemplateDto.TemplateWithChapterNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateChapters
{
  public class GetTemplateChaptersResponse : GetResponse<TemplateWithChapterNamesDto>
  {
    public GetTemplateChaptersResponse()
    {
    }
    public GetTemplateChaptersResponse(TemplateWithChapterNamesDto templateWithChapterNames)
      : base(templateWithChapterNames)
    {
    }
  }
}
