using InterviewCrusher.AbstractDomain.Algorithm;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.AlgorithmDto.AlgorithmRepresentation
{
  public class AlgorithmRepresentationDto : BaseAlgorithmDto, IDtoRepresentation
  {
    public SolutionB64Dto AlgorithmSolution { get; set; } = new SolutionB64Dto();

    public List<GenerateTestCaseRepresentationDto> TestCases { get; set; } = new List<GenerateTestCaseRepresentationDto>();

    public List<GenerateAlgorithmRestrictionsRepresentationDto> AlgorithmRestrictions { get; set; } = new List<GenerateAlgorithmRestrictionsRepresentationDto>();
  }
}
