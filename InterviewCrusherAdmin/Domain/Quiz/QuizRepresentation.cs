using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;

namespace InterviewCrusherAdmin.Domain.Quiz
{
  using InterviewCrusher.AbstractDomain.Quiz;
  using MongoDB.Bson.Serialization.Attributes;
  using MongoDB.Bson;

  public class QuizRepresentation : BaseQuiz, IAutoIncrementEntity
  {

    public List<GenerateQuizAnswer> QuizAnswers { get; set; } = new List<GenerateQuizAnswer>();
   
  }
}
