using InterviewCrusherAdmin.CommonDomain.TemplateDto.TemplateWithChapterNames;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
namespace InterviewCrusherAdmin.Domain.Template
{
  public interface ITemplateRepository : IRepository<GenerateTemplateDto.GenerateTemplate.GenerateTemplate>
  {
    Task<List<InterviewCrusherAdmin.CommonDomain.TemplateDto.TemplateNameDto>> GetTemplateNames(CancellationToken cancellationToken);

    Task<TemplateWithChapterNamesDto> GetTemplateWithChapterNames(string id, CancellationToken cancellationToken);

  }
}
