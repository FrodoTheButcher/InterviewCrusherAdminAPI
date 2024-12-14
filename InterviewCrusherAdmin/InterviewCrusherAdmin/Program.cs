
using AutoMapper;
using FluentValidation.AspNetCore;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;
using InterviewCrusherAdmin.DataAbstraction.Database;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using InterviewCrusherAdmin.Database;
using InterviewCrusherAdmin.Database.DatabaseConfiguration;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter;
using InterviewCrusherAdmin.Repositories.GenericCrudRepository;
using MediatR;
using System.Reflection;

namespace InterviewCrusherAdmin
{
  public class Program
  {
    private static Assembly[] assemblies;
    public static void Main(string[] args)
    {
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

      builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericCrudRepository<>));
      builder.Services.AddTransient<IRequestHandler<InsertDocumentRequest<GeneratedVideoDto, GenerateVideo>, InsertDocumentResponse>, InsertDocumentHandler<GeneratedVideoDto, GenerateVideo>>();

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
