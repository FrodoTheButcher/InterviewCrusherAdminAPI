using InterviewCrusher.AbstractDomain.Chapter;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.CommonDomain.ChapterDto
{
  public class GeneratedChapterDto : BaseChapterDto, IAutoIncrementEntity
  {
    public List<GeneratedAlgorithmDto> GeneratedAlgorithmsDtos { get; set; } = new List<GeneratedAlgorithmDto>();

    public List<GeneratedVideoDto> GeneratedVideosDtos { get; set; } = new List<GeneratedVideoDto>();

    public List<GeneratedQuizDto> GeneratedQuizesDtos { get; set; } = new List<GeneratedQuizDto>();

    public GeneratedChapterDto()
    {

    }

    public GeneratedChapterDto(string name, string description)
    {
      Title = name;
      Description = description;
    }

    public GeneratedChapterDto(List<GeneratedAlgorithmDto> generatedAlgorithmsDtos, List<GeneratedVideoDto> generatedVideosDtos, List<GeneratedQuizDto> generatedQuizesDtos, string name, string description)
    {
      GeneratedAlgorithmsDtos = generatedAlgorithmsDtos;
      GeneratedVideosDtos = generatedVideosDtos;
      GeneratedQuizesDtos = generatedQuizesDtos;
      Title = name;
      Description = description;
    }
  }
}
