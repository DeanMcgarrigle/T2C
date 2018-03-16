using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;
using Nancy.Routing;

namespace Train2Care.Nancy.Modules
{
  public class HomeModule : NancyModule
  {
    private readonly IRouteCacheProvider routeCache;

    public HomeModule(IRouteCacheProvider routeCacheProvider)
    {
      routeCache = routeCacheProvider;
      Get("/Endpoints", args => GetIndex(args));
    }

    private dynamic GetIndex(dynamic args)
    {
      var response = new IndexModel();

      // get the cached routes
      var cache = routeCache.GetCache();

      response.Routes = cache.Values.SelectMany(t => t.Select(t1 => t1.Item2));

      return Response.AsJson(response);
    }

    public class IndexModel
    {
      public IEnumerable<RouteDescription> Routes { get; set; }
    }
  }
}
