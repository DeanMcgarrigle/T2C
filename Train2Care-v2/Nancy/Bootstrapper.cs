using System;
using System.Diagnostics;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Configuration;
using Nancy.Conventions;
using Nancy.Diagnostics;
using Nancy.Responses.Negotiation;
using Nancy.TinyIoc;

namespace Train2Care.Nancy
{
  public class Bootstrapper : DefaultNancyBootstrapper
  {
    private readonly IServiceProvider services;
    private INancyEnvironment environment;


    public Bootstrapper()
    {

    }
    public Bootstrapper(IServiceProvider services)
    {
      this.services = services;
    }
    protected override Func<ITypeCatalog, NancyInternalConfiguration> InternalConfiguration
    {
      get
      {
        return NancyInternalConfiguration
            .WithOverrides(x =>
                x.ResponseProcessors = new[] {
                            typeof(ViewProcessor),
                            typeof(JsonProcessor),
                            typeof(XmlProcessor)
                });
      }
    }

    protected override void ConfigureApplicationContainer(TinyIoCContainer container)
    {
      base.ConfigureApplicationContainer(container);

      container.Register(services);
    }
    protected override void ConfigureConventions(NancyConventions nancyConventions)
    {
      nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Nancy/", "Views"));
      //base.ConfigureConventions(nancyConventions);
    }


  }
}
