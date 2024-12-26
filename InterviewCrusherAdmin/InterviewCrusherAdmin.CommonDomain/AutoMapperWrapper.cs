using AutoMapper;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;
using System;
using System.Linq;
using System.Reflection;
using GeneratedAlgorithm = InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateAlgorithm.GenerateAlgorithm;
namespace InterviewCrusherAdmin.CommonDomain
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

    public static IMapper ConfigureMapper()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<GeneratedVideoDto, GenerateVideo>().ReverseMap();
        cfg.CreateMap<GeneratedAlgorithmDto, GeneratedAlgorithm>().ReverseMap();
        cfg.CreateMap<GenerateTemplate, GenerateTemplateDto>().ReverseMap();
        cfg.CreateMap<GenerateQuiz, GeneratedQuizDto>().ReverseMap();
      });

      return config.CreateMapper();
    }
  }
}
