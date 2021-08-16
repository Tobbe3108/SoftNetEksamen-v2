using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.Core.Interfaces;
using WebAPI.Features.Containers;
using WebAPI.Features.Customers;
using WebAPI.Features.Rentals;

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
      services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" }); });
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
      var connectionString = Configuration.GetConnectionString("SQLite");
      builder.Register(_ => new ContainerRepository(connectionString)).As(typeof(BaseRepository<Container>));
      builder.Register(_ => new CustomerRepository(connectionString)).As(typeof(BaseRepository<Customer>));
      builder.Register(_ => new RentalRepository(connectionString)).As(typeof(BaseRepository<Rental>));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      AutofacContainer = app.ApplicationServices.GetAutofacRoot();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}