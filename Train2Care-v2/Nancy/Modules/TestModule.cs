using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;

namespace Train2Care.Nancy.Modules
{
    public class TestModule : NancyModule
    {
      public TestModule() : base ("/api")
      {
        Get("/test", args => Response.AsJson("test works"));
      }
    }
}
