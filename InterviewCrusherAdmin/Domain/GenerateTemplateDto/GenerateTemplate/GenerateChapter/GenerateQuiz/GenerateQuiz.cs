using InterviewCrusher.AbstractDomain.Quiz;

namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz
{
  public class GenerateQuiz : BaseQuiz
  {
    public List<GenerateQuizAnswer> QuizAnswers { get; set; } = new List<GenerateQuizAnswer>();
   
  }
}
