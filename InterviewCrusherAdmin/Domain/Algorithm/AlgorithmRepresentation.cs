using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateAlgorithm;
using InterviewCrusher.AbstractDomain.Algorithm;

namespace InterviewCrusherAdmin.Domain.Algorithm
{
  public class AlgorithmRepresentation : BaseAlgorithm
  {
    public GenerateAlgorithmSolution AlgorithmSolution { get; set; } = new GenerateAlgorithmSolution();

    public List<GenerateTestCase> TestCases { get; set; } = new List<GenerateTestCase>();

    public List<GenerateAlgorithmRestrictions> AlgorithmRestrictions { get; set; } = new List<GenerateAlgorithmRestrictions>();
  
  }
}
