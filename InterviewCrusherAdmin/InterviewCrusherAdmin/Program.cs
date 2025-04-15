
using AutoMapper;
using FluentValidation.AspNetCore;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetAllDocuments;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocument;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsByTemplateId;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsName;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertAutoIncrementDocument;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.AlgorithmRepresentation;
using InterviewCrusherAdmin.CommonDomain.QuizDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;
using InterviewCrusherAdmin.DataAbstraction.Database;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using InterviewCrusherAdmin.Database.DatabaseConfiguration;
using InterviewCrusherAdmin.Domain;
using InterviewCrusherAdmin.Domain.Algorithm;
using InterviewCrusherAdmin.Domain.Chapter;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter;
using InterviewCrusherAdmin.Domain.Quiz;
using InterviewCrusherAdmin.Domain.Template;
using InterviewCrusherAdmin.Domain.VideoRepresentation;
using InterviewCrusherAdmin.Repositories.AutoIncrementRepository;
using InterviewCrusherAdmin.Repositories.GenericCrudRepository;
using InterviewCrusherAdmin.Repositories.Template;
using MediatR;
using System.Reflection;

namespace InterviewCrusherAdmin
{
  public class Program
  {
    private static Assembly[] assemblies;
    public static void Main(string[] args)
    {
      MongoMappings.RegisterMappings();
      var builder = WebApplication.CreateBuilder(args);
      assemblies = RegisterServices(builder.Services);
      builder.Services.AddControllers();
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      IDatabaseConfiguration databaseConfig = new DatabaseConfiguration();
      builder.Configuration.GetSection("DatabaseConfiguration").Bind(databaseConfig);
      builder.Services.AddFluentValidation(fv =>
      {
        fv.RegisterValidatorsFromAssemblies(assemblies);
      });
      builder.Services.AddSingleton<IDatabase>(e =>
      {
        return new Database.Database(databaseConfig);
      });
      builder.Services.AddScoped(typeof(IGenericCrudRepository<>), typeof(GenericCrudRepository<>));
      builder.Services.AddScoped(typeof(IAutoIncrementRepository<>), typeof(AutoIncrementRepository<>));
      builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();

      builder.Services.AddTransient<IRequestHandler<InsertAutoIncrementDocumentRequest<VideoRepresentationDto, VideoRepresentation>, InsertAutoIncrementDocumentResponse>, InsertAutoIncrementDocumentHandler<VideoRepresentationDto, VideoRepresentation>>();
      builder.Services.AddTransient<IRequestHandler<InsertAutoIncrementDocumentRequest<ChapterRepresentationDto, ChapterRepresentation>, InsertAutoIncrementDocumentResponse>, InsertAutoIncrementDocumentHandler<ChapterRepresentationDto, ChapterRepresentation>>();
      builder.Services.AddTransient<IRequestHandler<InsertAutoIncrementDocumentRequest<QuizRepresentationDto, QuizRepresentation>, InsertAutoIncrementDocumentResponse>, InsertAutoIncrementDocumentHandler<QuizRepresentationDto, QuizRepresentation>>();
      builder.Services.AddTransient<IRequestHandler<InsertAutoIncrementDocumentRequest<AlgorithmRepresentationDto, AlgorithmRepresentation>, InsertAutoIncrementDocumentResponse>, InsertAutoIncrementDocumentHandler<AlgorithmRepresentationDto, AlgorithmRepresentation>>();

      builder.Services.AddTransient<IRequestHandler<GetDocumentsByTemplateIdRequest<ChapterRepresentation>, GetDocumentsByTemplateIdResponse>, GetDocumentsByTemplateIdHandler<ChapterRepresentation>>();

      builder.Services.AddTransient<IRequestHandler<GetDocumentsNameRequest<GenerateTemplate>, GetDocumentsNameResponse>, GetDocumentsNameHandler<GenerateTemplate>>();
      builder.Services.AddTransient<IRequestHandler<GetDocumentsNameRequest<ChapterRepresentation>, GetDocumentsNameResponse>, GetDocumentsNameHandler<ChapterRepresentation>>();
      builder.Services.AddTransient<IRequestHandler<GetDocumentsNameRequest<QuizRepresentation>, GetDocumentsNameResponse>, GetDocumentsNameHandler<QuizRepresentation>>();
      builder.Services.AddTransient<IRequestHandler<GetDocumentsNameRequest<VideoRepresentation>, GetDocumentsNameResponse>, GetDocumentsNameHandler<VideoRepresentation>>();
      builder.Services.AddTransient<IRequestHandler<GetDocumentsNameRequest<AlgorithmRepresentation>, GetDocumentsNameResponse>, GetDocumentsNameHandler<AlgorithmRepresentation>>();

      builder.Services.AddTransient<IRequestHandler<InsertDocumentRequest<GeneratedVideoDto, GenerateVideo>, InsertDocumentResponse>, InsertDocumentHandler<GeneratedVideoDto, GenerateVideo>>();
      builder.Services.AddTransient<IRequestHandler<InsertDocumentRequest<GenerateTemplateDto, GenerateTemplate>, InsertDocumentResponse>, InsertDocumentHandler<GenerateTemplateDto, GenerateTemplate>>();
      builder.Services.AddTransient<IRequestHandler<InsertDocumentRequest<TemplateRepresentation, GenerateTemplate>, InsertDocumentResponse>, InsertDocumentHandler<TemplateRepresentation, GenerateTemplate>>();
      builder.Services.AddTransient<IRequestHandler<InsertDocumentRequest<ChapterRepresentationDto, ChapterRepresentation>, InsertDocumentResponse>, InsertDocumentHandler<ChapterRepresentationDto, ChapterRepresentation>>();

      builder.Services.AddTransient<IRequestHandler<InsertDocumentRequest<GeneratedVideoDto, GenerateVideo>, InsertDocumentResponse>, InsertDocumentHandler<GeneratedVideoDto, GenerateVideo>>();
      builder.Services.AddTransient<IRequestHandler<GetDocumentRequest<GenerateTemplateDto, GenerateTemplate>, GetDocumentResponse<GenerateTemplateDto>>, GetDocumentHandler<GenerateTemplateDto, GenerateTemplate>>();
      builder.Services.AddTransient<IRequestHandler<GetAllDocumentsRequest<GenerateTemplateDto, GenerateTemplate>, GetAllDocumentsResponse<GenerateTemplateDto>>, GetAllDocumentsHandler<GenerateTemplateDto, GenerateTemplate>>();


      var mapper = AutoMapperWrapper.ConfigureMapper();
      builder.Services.AddSingleton<IMapper>(mapper);
      builder.Services.AddSingleton<AutoMapperWrapper>(sp => new AutoMapperWrapper(sp.GetRequiredService<IMapper>()));
      builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(assemblies));

      var app = builder.Build();

      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
    private static Assembly[] RegisterServices(IServiceCollection services)
    {
      var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
          .Where(assembly => assembly.GetName().Name.Contains("InterviewCrusherAdmin") ||
                             assembly.GetName().Name.Contains("CommonDomain"))
          .ToList();

      var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

      var allAssemblyFiles = Directory.GetFiles(assemblyPath, "*.dll");

      foreach (var assemblyFile in allAssemblyFiles)
      {
        var assemblyName = Path.GetFileNameWithoutExtension(assemblyFile);

        if (!loadedAssemblies.Any(a => a.GetName().Name.Equals(assemblyName, StringComparison.OrdinalIgnoreCase)))
        {
          if (assemblyName.Contains("InterviewCrusherAdmin") || assemblyName.Contains("CommonDomain"))
          {
            try
            {
              var assembly = Assembly.LoadFrom(assemblyFile);
              loadedAssemblies.Add(assembly);
            }
            catch (Exception ex)
            {
              Console.WriteLine($"Could not load assembly {assemblyFile}: {ex.Message}");
            }
          }
        }
      }

      return loadedAssemblies.ToArray();
    }


  }
}
