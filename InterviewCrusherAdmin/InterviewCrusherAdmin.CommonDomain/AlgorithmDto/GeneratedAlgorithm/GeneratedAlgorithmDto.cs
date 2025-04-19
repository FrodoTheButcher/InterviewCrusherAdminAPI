using InterviewCrusher.AbstractDomain.Algorithm;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm
{
  public class GeneratedAlgorithmDto : BaseAlgorithmDto, IDtoRepresentation
  {
    public string AlgorithmSolution { get; set; } = string.Empty;

    public List<GenerateTestCaseDto> TestCases { get; set; } = new List<GenerateTestCaseDto>();

    public List<GenerateAlgorithmExampleDto> Examples { get; set; } = new List<GenerateAlgorithmExampleDto>();

    public List<GenerateAlgorithmRestrictionsDto> AlgorithmRestrictions { get; set; } = new List<GenerateAlgorithmRestrictionsDto>();
  }
}
