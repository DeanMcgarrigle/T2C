using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;
using Train2Care.Nancy;

namespace Train2Care
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      services.AddCors(x => x.AddPolicy("myPolicy", builder =>
      {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
      }));
      return services.BuildServiceProvider();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
    {
      app.UseCors("myPolicy");
      app.ApplicationServices = serviceProvider;
      app.UseOwin(x => x.UseNancy(opt => opt.Bootstrapper = new Bootstrapper(serviceProvider)));
    }
  }
}
