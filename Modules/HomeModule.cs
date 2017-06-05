using Nancy;
using System.Collections.Generic;
using Inventory.Objects;

namespace Inventory
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];

      Post["/inventory"] = _ =>
      {
        MyLittlePony newMyLittlePony = new MyLittlePony(Request.Form["pony-name"], Request.Form["pony-color"]);
        return View["/inventory.cshtml"];
        }
      };
    }
  }
}
