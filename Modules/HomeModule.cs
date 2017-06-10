using Nancy;
using System.Collections.Generic;
using System;
using Nancy.ViewEngines.Razor;
using Stylist_Object;
using HairSalon;
using Client_Object;

namespace Salon_Modules
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
//=======================================================
    Get["/"] = _ => {
      return View["index.cshtml"];
    };
//=======================================================
    Get["/stylist"] = _ => {
      List<Stylist> AllStylist = Stylist.GetAll();
      return View["stylist.cshtml", AllStylist];
    };
//=======================================================

    }
  }
}
