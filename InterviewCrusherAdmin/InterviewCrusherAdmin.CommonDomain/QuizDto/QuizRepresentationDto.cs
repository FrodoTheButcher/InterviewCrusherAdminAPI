using InterviewCrusherAdmin.DataAbstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using InterviewCrusher.AbstractDomain.Quiz;

namespace InterviewCrusherAdmin.CommonDomain.QuizDto
{
  public class QuizRepresentationDto : BaseQuizDto, IDtoRepresentation
  {

    public List<QuizAnswersDto> QuizAnswers { get; set; } = new List<QuizAnswersDto>();

  }
}
