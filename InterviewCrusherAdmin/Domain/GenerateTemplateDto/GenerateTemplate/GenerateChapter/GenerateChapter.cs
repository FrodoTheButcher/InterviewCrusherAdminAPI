namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter
{
  public class GenerateChapter
  {
    public string Title { get; set; } = string.Empty;

    public List<GenerateAlgorithm.GenerateAlgorithm> GenerateAlgorithms { get; set; } = new List<GenerateAlgorithm.GenerateAlgorithm>();
  
    public List<GenerateQuiz.GenerateQuiz> GenerateQuizzes { get; set; } = new List<GenerateQuiz.GenerateQuiz>();

    public List<GenerateVideo> GenerateVideos { get; set; } = new List<GenerateVideo>();
  }
}
