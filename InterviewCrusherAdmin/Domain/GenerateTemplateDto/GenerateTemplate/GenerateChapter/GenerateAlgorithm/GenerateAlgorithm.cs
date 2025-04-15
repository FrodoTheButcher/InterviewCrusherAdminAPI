using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateAlgorithm
{
  public class GenerateAlgorithm : IDatabaseEntityRepresentation ,IAutoIncrementEntity
  {
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public string Hint { get; set; } = string.Empty;

    public bool AllLanguagesAvailable { get; set; } = false;

    public string CompletedCode { get; set; } = string.Empty;

    public GenerateAlgorithmSolution AlgorithmSolution { get; set; } = new GenerateAlgorithmSolution();

    public List<GenerateTestCase> TestCases { get; set; } = new List<GenerateTestCase>();

    public List<GenerateAlgorithmRestrictions> AlgorithmRestrictions { get; set; } = new List<GenerateAlgorithmRestrictions>();
    public string ParentId { get; set; } = string.Empty;
    public ushort ExerciseNumber {  get; set; } = ushort.MinValue;

  }
}
