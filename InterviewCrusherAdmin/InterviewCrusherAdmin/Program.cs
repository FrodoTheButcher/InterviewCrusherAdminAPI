
using AutoMapper;
using FluentValidation.AspNetCore;
using InterviewCrusherAdmin.DataAbstraction.Database;
using InterviewCrusherAdmin.Database;
using InterviewCrusherAdmin.Database.Database;
using InterviewCrusherAdmin.Database.DatabaseConfiguration;
using Microsoft.Extensions.DependencyInjection;
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

      var app = builder.Build();

      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      IDatabaseConfiguration databaseConfig = new Database.DatabaseConfiguration.DatabaseConfiguration();
      builder.Configuration.GetSection("DatabaseConfiguration").Bind(databaseConfig);
      builder.Services.AddSingleton<IDatabaseConfiguration>(databaseConfig);
      builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblies(assemblies));
      builder.Services.AddSingleton<IMapper>(provider =>
      {
        var config = new MapperConfiguration(cfg =>
        {
          cfg.AddProfile<CommonDomain.AutoMapper>();
        });

        return config.CreateMapper();
      });
      builder.Services.AddMediatR(x=>x.RegisterServicesFromAssemblies(assemblies));
      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
    private static Assembly[] RegisterServices(IServiceCollection services)
    {
      var assemblies = AppDomain.CurrentDomain.GetAssemblies()
          .Where(assembly => assembly.GetName().Name.Contains("InterviewCrusherAdmin"))
          .ToArray();
      return assemblies;
    }
  }
}
