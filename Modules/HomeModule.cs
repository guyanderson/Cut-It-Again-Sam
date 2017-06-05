using Nancy;
using System.Collections.Generic;
using Inventory.Objects;
using System;

namespace Inventory
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/inventory"] = _ => {
        List<MyLittlePony> allMyLittlePonies = MyLittlePony.GetAll();
        return View["inventory.cshtml", allMyLittlePonies];
      };

      Post["/inventory"] = _ =>  {
        MyLittlePony newMyLittlePony = new MyLittlePony(Request.Form["pony-name"], Request.Form["pony-color"]);
        Console.WriteLine("before GetAll");
        Console.WriteLine(newMyLittlePony.GetName());
        List<MyLittlePony> allMyLittlePonies = MyLittlePony.GetAll();
        Console.WriteLine("after GetAll");
        Console.WriteLine(allMyLittlePonies[0].GetName());
        return View["inventory.cshtml", allMyLittlePonies];
      };

      Get["/inventory/{id}"] = parameters => {
        MyLittlePony myLittlePony = MyLittlePony.Find(parameters.id);
        return View["pony.cshtml", myLittlePony];
      };


    }
  }
}
