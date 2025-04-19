using InterviewCrusher.AbstractDomain.Algorithm;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateAlgorithm
{
  public class GenerateAlgorithm : BaseAlgorithm, IDatabaseEntityRepresentation ,IAutoIncrementEntity
  {
    public GenerateAlgorithmSolution AlgorithmSolution { get; set; } = new GenerateAlgorithmSolution();

    public List<GenerateTestCase> TestCases { get; set; } = new List<GenerateTestCase>();

    public List<GenerateAlgorithmRestrictions> AlgorithmRestrictions { get; set; } = new List<GenerateAlgorithmRestrictions>();

  }
}
