using AutoMapper;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm;
using InterviewCrusherAdmin.CommonDomain.ChapterDto;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain.Chapter;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateAlgorithm;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;
using System;
using System.Linq;
using System.Reflection;
using GeneratedAlgorithm = InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateAlgorithm.GenerateAlgorithm;
namespace InterviewCrusherAdmin.Domain
{
  public class AutoMapperWrapper : IDependencyRepresentation
  {
    private readonly IMapper _mapper;

    public AutoMapperWrapper(IMapper mapper)
    {
      _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public string ClassName => nameof(AutoMapperWrapper);

    public IMapper Mapper => _mapper;
    //todo -> restrict for the dtos to have IDtoRepresentation
    public static IMapper ConfigureMapper()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<GeneratedVideoDto, GenerateVideo>().ReverseMap();
        cfg.CreateMap<GeneratedAlgorithmDto, GeneratedAlgorithm>().ReverseMap();
        cfg.CreateMap<GenerateQuiz, GeneratedQuizDto>().ReverseMap();
        cfg.CreateMap<TemplateRepresentation, GenerateTemplate>();
        cfg.CreateMap<ChapterRepresentationDto, ChapterRepresentation>().ReverseMap();

        cfg.CreateMap<InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto.GenerateTemplateDto, GenerateTemplate>()
        .AfterMap((dto, doc) =>
     {
       doc.Chapters = dto.GeneratedChaptersDtos.Select(chapter =>
       {
         return new GenerateChapter
         {
           GenerateAlgorithms = chapter.GeneratedAlgorithmsDtos.Select(algo =>
           {
             return new GeneratedAlgorithm
             {
               AlgorithmRestrictions = algo.AlgorithmRestrictions.Select(restriction => { return new GenerateAlgorithmRestrictions { RestrictionDescription = restriction.RestrictionDescription, RestrictionName = restriction.RestrictionName }; }).ToList(),
               AlgorithmSolution = new GenerateAlgorithmSolution { SolutionB64 = algo.AlgorithmSolution },
               AllLanguagesAvailable = algo.AllLanguagesAvailable,
               CompletedCode = algo.CompletedCode,
               Description = algo.Description,
               Difficulty = algo.Difficulty,
               Examples = algo.Examples.Select(example => new GenerateAlgorithmExample { ExpectedOutput = example.ExpectedOutput, Explanation = example.Explanation, InputData = example.InputData }).ToList(),
               Hint = algo.Hint,
               Name = algo.Name,
               TestCases = algo.TestCases.Select(test => new GenerateTestCase { ExpectedOutput = test.ExpectedOutput, InputData = test.InputData, Tip = test.Tip }).ToList()
             };
           }).ToList(),
           ChapterNumber = chapter.ChapterNumber,
           GenerateQuizzes = chapter.GeneratedQuizesDtos.Select(quiz =>
           {
             return new GenerateQuiz
             {
               QuizAnswers = quiz.QuizAnswers.Select(answ => new GenerateQuizAnswer { IsCorrect = answ.IsCorrect, Explanation = answ.Explanation, Name = answ.Name }).ToList(),
               Description = quiz.Description,
               Difficulty = quiz.Difficulty,
               Name = quiz.Name,
               Hint = quiz.Hint
             };
           }).ToList(),
           Description = chapter.Description,
           Title = chapter.Name,
           GenerateVideos = chapter.GeneratedVideosDtos.Select(video => new GenerateVideo
           {
             Description = video.Description,
             Name = video.Name,
             Url = video.Url,
             Deleted = false,
             VideoLength = video.VideoLength
           }).ToList(),
         };

       }).ToList();
     });
        cfg.CreateMap<GenerateTemplate, InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto.GenerateTemplateDto>()
        .AfterMap((doc, dto) =>
{
  dto.GeneratedChaptersDtos = doc.Chapters.Select(chapter =>
  {
    return new GeneratedChapterDto
    {
      GeneratedAlgorithmsDtos = chapter.GenerateAlgorithms.Select(algo =>
      {
        return new GeneratedAlgorithmDto
        {
          AlgorithmRestrictions = algo.AlgorithmRestrictions.Select(restriction => new GenerateAlgorithmRestrictionsDto
          {
            RestrictionDescription = restriction.RestrictionDescription,
            RestrictionName = restriction.RestrictionName
          }).ToList(),
          AlgorithmSolution = algo.AlgorithmSolution.SolutionB64,
          AllLanguagesAvailable = algo.AllLanguagesAvailable,
          CompletedCode = algo.CompletedCode,
          Description = algo.Description,
          Difficulty = algo.Difficulty,
          Examples = algo.Examples.Select(example => new GenerateAlgorithmExampleDto
          {
            ExpectedOutput = example.ExpectedOutput,
            Explanation = example.Explanation,
            InputData = example.InputData
          }).ToList(),
          Hint = algo.Hint,
          Name = algo.Name,
          TestCases = algo.TestCases.Select(test => new GenerateTestCaseDto
          {
            ExpectedOutput = test.ExpectedOutput,
            InputData = test.InputData,
            Tip = test.Tip
          }).ToList()
        };
      }).ToList(),
      ChapterNumber = chapter.ChapterNumber,
      GeneratedQuizesDtos = chapter.GenerateQuizzes.Select(quiz =>
      {
        return new GeneratedQuizDto
        {
          QuizAnswers = quiz.QuizAnswers.Select(answ => new GenerateQuizAnswerDto
          {
            IsCorrect = answ.IsCorrect,
            Explanation = answ.Explanation,
            Name = answ.Name
          }).ToList(),
          Description = quiz.Description,
          Difficulty = quiz.Difficulty,
          Name = quiz.Name,
          Hint = quiz.Hint
        };
      }).ToList(),

      Description = chapter.Description,
      Name = chapter.Title,
      GeneratedVideosDtos = chapter.GenerateVideos.Select(video => new GeneratedVideoDto
      {
        Description = video.Description,
        Name = video.Name,
        Url = video.Url,
        VideoLength = video.VideoLength
      }).ToList()
    };
  }).ToList();
  dto.Id = doc.Id;
});


      });
      return config.CreateMapper();
    }
  }
}
