using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;

namespace InterviewCrusherAdmin.CommonDomain.ChapterDto
{
  public class GeneratedChapterDto
  {
    public List<GeneratedAlgorithmDto> GeneratedAlgorithmsDtos { get; set; } = new List<GeneratedAlgorithmDto>();

    public List<GeneratedVideoDto> GeneratedVideosDtos { get; set; } = new List<GeneratedVideoDto>();

    public List<GeneratedQuizDto> GeneratedQuizesDtos { get; set; } = new List<GeneratedQuizDto>();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public GeneratedChapterDto()
    {

    }

    public GeneratedChapterDto(string name, string description)
    {
      Name = name;
      Description = description;
    }

    public GeneratedChapterDto(List<GeneratedAlgorithmDto> generatedAlgorithmsDtos, List<GeneratedVideoDto> generatedVideosDtos, List<GeneratedQuizDto> generatedQuizesDtos, string name, string description)
    {
      GeneratedAlgorithmsDtos = generatedAlgorithmsDtos;
      GeneratedVideosDtos = generatedVideosDtos;
      GeneratedQuizesDtos = generatedQuizesDtos;
      Name = name;
      Description = description;
    }
  }
}
