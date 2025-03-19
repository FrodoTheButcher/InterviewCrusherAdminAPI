using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.TemplateDto
{
  public class TemplateNameDto : IDatabaseEntitySerializer, IDtoRepresentation
  {
    public string Title { get; set; } = string.Empty;

  }
}
