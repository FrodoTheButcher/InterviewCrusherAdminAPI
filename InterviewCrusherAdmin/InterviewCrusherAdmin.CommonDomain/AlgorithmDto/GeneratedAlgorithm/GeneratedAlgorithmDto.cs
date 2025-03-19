using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm
{
  public class GeneratedAlgorithmDto : IDtoRepresentation
  {
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public bool AllLanguagesAvailable { get; set; } = false;

    public string CompletedCode { get; set; } = string.Empty;

    public String AlgorithmSolution { get; set; } = string.Empty;

    public List<GenerateTestCaseDto> TestCases { get; set; } = new List<GenerateTestCaseDto>();

    public List<GenerateAlgorithmExampleDto> Examples { get; set; } = new List<GenerateAlgorithmExampleDto>();

    public List<GenerateAlgorithmRestrictionsDto> AlgorithmRestrictions { get; set; } = new List<GenerateAlgorithmRestrictionsDto>();
  }
}
