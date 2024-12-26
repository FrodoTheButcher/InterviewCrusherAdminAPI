using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm;
using InterviewCrusherAdmin.CommonDomain.ChapterDto;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;

namespace InterviewCrusher.Console.Singleton
{
  internal class TemplateDataStorage
  {
    private List<GeneratedAlgorithmDto> GeneratedAlgorithmDtos { get; set; }

    private List<GeneratedVideoDto> GeneratedVideoDtos { get; set; }

    private List<GeneratedQuizDto> GeneratedQuizDtos { get; set; }
     
    private List<GeneratedChapterDto> GeneratedChapterDtos { get; set; }

    public void AddGeneratedAlgorithmDto(GeneratedAlgorithmDto generatedAlgorithmDto)
    {
      GeneratedAlgorithmDtos.Add(generatedAlgorithmDto);
    }
    public void AddGeneratedVideoDto(GeneratedVideoDto generatedVideoDto)
    {
      GeneratedVideoDtos.Add(generatedVideoDto);
    }

    public void AddGeneratedQuizDto(GeneratedQuizDto generatedQuizDto)
    {
      GeneratedQuizDtos.Add(generatedQuizDto);
    }

    public void AddGeneratedChapterDtoWithPreviousDataAndCleanIt(string name, string description)
    {
      this.GeneratedChapterDtos.Add(new GeneratedChapterDto(GeneratedAlgorithmDtos, GeneratedVideoDtos, GeneratedQuizDtos, name, description));
      GeneratedAlgorithmDtos = new List<GeneratedAlgorithmDto>();
      GeneratedVideoDtos = new List<GeneratedVideoDto>();
      GeneratedQuizDtos = new List<GeneratedQuizDto>();
    }

    public List<GeneratedChapterDto> GetGeneratedChaptersAndClearEverything()
    {
      List<GeneratedChapterDto> copy = this.GeneratedChapterDtos;
      this.GeneratedChapterDtos = new List<GeneratedChapterDto>();
      return copy;
    }

    private static TemplateDataStorage _instance= null;

    private TemplateDataStorage()
    {
      GeneratedAlgorithmDtos = new List<GeneratedAlgorithmDto>();
      GeneratedVideoDtos = new List<GeneratedVideoDto>();
      GeneratedQuizDtos = new List<GeneratedQuizDto>();
      GeneratedChapterDtos = new List<GeneratedChapterDto>();
    }

    public static TemplateDataStorage Instance
    {
      get
      {
        if(_instance == null)
        {
          _instance = new TemplateDataStorage();
        }
        return _instance;
      }
    }

  }
}
