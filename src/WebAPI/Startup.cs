using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebAPI.Core.Base;
using WebAPI.Features.ContactPerson;
using WebAPI.Features.Container;
using WebAPI.Features.Customer;
using WebAPI.Features.Rental;
using Table = WebAPI.Features.Customer.Table;

namespace WebAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; private set; }
    public ILifetimeScope AutofacContainer { get; private set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
        c.CustomSchemaIds(type => type.FullName);
      });
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
      var connectionString = Configuration.GetConnectionString("SQLite");
      builder.Register(_ => new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider))
        .As<IDbConnectionFactory>();
      
      builder.RegisterType<ContainerRepository>().AsSelf();
      builder.RegisterType<BaseRepository<Table>>().AsSelf();
      builder.RegisterType<Repository>().AsSelf();
      builder.RegisterType<BaseRepository<Features.ContactPerson.Table>>().AsSelf();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      AutofacContainer = app.ApplicationServices.GetAutofacRoot();
      
      using (var dbConnection = AutofacContainer.Resolve<IDbConnectionFactory>().Open())
      {
        dbConnection.CreateTableIfNotExists(typeof(Features.Container.Table), typeof(Features.ContactPerson.Table), typeof(Table), typeof(Features.Rental.Table));
      }

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
          c.DocExpansion(DocExpansion.None);
        });
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}