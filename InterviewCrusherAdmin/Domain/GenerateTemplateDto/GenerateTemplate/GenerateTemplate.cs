using InterviewCrusher.AbstractDomain.Template;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter;

namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate
{
  public class GenerateTemplate : BaseTemplate, IDatabaseEntityRepresentation
  {
    public List<GenerateChapter.GenerateChapter> Chapters { get; set; } = new List<GenerateChapter.GenerateChapter>();
  }
}
