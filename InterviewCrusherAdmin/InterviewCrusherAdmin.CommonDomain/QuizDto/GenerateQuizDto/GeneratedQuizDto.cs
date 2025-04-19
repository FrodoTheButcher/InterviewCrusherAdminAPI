using InterviewCrusher.AbstractDomain.Quiz;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto
{
  public class GeneratedQuizDto : BaseQuizDto, IDtoRepresentation
  {
    public List<GenerateQuizAnswerDto> QuizAnswers { get; set; } = new List<GenerateQuizAnswerDto>();
  }
}
