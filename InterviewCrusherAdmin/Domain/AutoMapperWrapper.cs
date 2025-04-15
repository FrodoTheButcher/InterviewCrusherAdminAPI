using AutoMapper;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.AlgorithmRepresentation;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm;
using InterviewCrusherAdmin.CommonDomain.ChapterDto;
using InterviewCrusherAdmin.CommonDomain.QuizDto;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain.Algorithm;
using InterviewCrusherAdmin.Domain.Chapter;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateAlgorithm;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;
using InterviewCrusherAdmin.Domain.Quiz;
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
        cfg.CreateMap<QuizRepresentationDto, QuizRepresentation>().ReverseMap();
        cfg.CreateMap<QuizAnswersDto, GenerateQuizAnswer>().ReverseMap();
        cfg.CreateMap<AlgorithmRepresentationDto, AlgorithmRepresentation>().ReverseMap();
        cfg.CreateMap<SolutionB64Dto, GenerateAlgorithmSolution>().ReverseMap();
        cfg.CreateMap<GenerateTestCaseRepresentationDto, GenerateTestCase>().ReverseMap();
        cfg.CreateMap<GenerateAlgorithmRestrictionsRepresentationDto, GenerateAlgorithmRestrictions>().ReverseMap();

        cfg.CreateMap<VideoRepresentationDto, VideoRepresentation.VideoRepresentation>().ReverseMap();
        cfg.CreateMap<SolutionB64Dto, GenerateAlgorithmSolution>()
   .ForMember(dest => dest.SolutionB64, opt => opt.MapFrom(src => src.SolutionB64));

        cfg.CreateMap<GenerateAlgorithmRestrictionsDto, GenerateAlgorithmRestrictions>()
           .ForMember(dest => dest.RestrictionName, opt => opt.MapFrom(src => src.RestrictionName))
           .ForMember(dest => dest.RestrictionDescription, opt => opt.MapFrom(src => src.RestrictionDescription));

        cfg.CreateMap<GenerateTestCaseDto, GenerateTestCase>()
           .ForMember(dest => dest.InputData, opt => opt.MapFrom(src => src.InputData))
           .ForMember(dest => dest.ExpectedOutput, opt => opt.MapFrom(src => src.ExpectedOutput))
           .ForMember(dest => dest.Tip, opt => opt.MapFrom(src => src.Tip));

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
               Hint = algo.Hint,
               Title = algo.Name,
               TestCases = algo.TestCases.Select(test => new GenerateTestCase { ExpectedOutput = test.ExpectedOutput, InputData = test.InputData, Tip = test.Tip }).ToList()
             };
           }).ToList(),
           GenerateQuizzes = chapter.GeneratedQuizesDtos.Select(quiz =>
           {
             return new GenerateQuiz
             {
               QuizAnswers = quiz.QuizAnswers.Select(answ => new GenerateQuizAnswer { IsCorrect = answ.IsCorrect, Explanation = answ.Explanation, Name = answ.Name }).ToList(),
               Description = quiz.Description,
               Difficulty = quiz.Difficulty,
               Title = quiz.Title,
               Hint = quiz.Hint
             };
           }).ToList(),
           Description = chapter.Description,
           Title = chapter.Title,
           GenerateVideos = chapter.GeneratedVideosDtos.Select(video => new GenerateVideo
           {
             Description = video.Description,
             Title = video.Name,
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
          AlgorithmRestrictions = algo.AlgorithmRestrictions.Select(restriction => new CommonDomain.AlgorithmDto.GeneratedAlgorithm.GenerateAlgorithmRestrictionsDto
          {
            RestrictionDescription = restriction.RestrictionDescription,
            RestrictionName = restriction.RestrictionName
          }).ToList(),
          AlgorithmSolution = algo.AlgorithmSolution.SolutionB64,
          AllLanguagesAvailable = algo.AllLanguagesAvailable,
          CompletedCode = algo.CompletedCode,
          Description = algo.Description,
          Difficulty = algo.Difficulty,
          Hint = algo.Hint,
          Name = algo.Title,
          TestCases = algo.TestCases.Select(test => new CommonDomain.AlgorithmDto.GeneratedAlgorithm.GenerateTestCaseDto
          {
            ExpectedOutput = test.ExpectedOutput,
            InputData = test.InputData,
            Tip = test.Tip
          }).ToList()
        };
      }).ToList(),
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
          Title = quiz.Title,
          Hint = quiz.Hint
        };
      }).ToList(),

      Description = chapter.Description,
      Title = chapter.Title,
      GeneratedVideosDtos = chapter.GenerateVideos.Select(video => new GeneratedVideoDto
      {
        Description = video.Description,
        Name = video.Title,
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
