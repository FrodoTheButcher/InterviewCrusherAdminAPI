using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCrusherAdmin.CommonDomain.AlgorithmDto.AlgorithmRepresentation
{
  public class AlgorithmRepresentationDto : IDtoRepresentation
  {
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public bool AllLanguagesAvailable { get; set; } = false;

    public string CompletedCode { get; set; } = string.Empty;

    public SolutionB64Dto AlgorithmSolution { get; set; } = new SolutionB64Dto();

    public List<GenerateTestCaseDto> TestCases { get; set; } = new List<GenerateTestCaseDto>();

    public List<GenerateAlgorithmRestrictionsDto> AlgorithmRestrictions { get; set; } = new List<GenerateAlgorithmRestrictionsDto>();
    public string ParentId { get; set; } = string.Empty;
  }
}
