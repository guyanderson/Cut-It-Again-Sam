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
      Get["/client"] = _ => {
        List<Client> AllClient = Client.GetAll();
        return View["client.cshtml", AllClient];
      };
//=======================================================
      Get["/stylist/new"] = _ => {
         return View["stylist_form.cshtml"];
       };
  //=======================================================
      Post["/stylist/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["success.cshtml"];
      };
//=======================================================
      Get["/client/new"] = _ => {
         List<Stylist> AllStylist = Stylist.GetAll();
         return View["client_form.cshtml", AllStylist];
       };
 //=======================================================
       Post["/client/new"] = _ => {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["stylistid"]);
        newClient.Save();
        return View["success.cshtml"];
      };
//=======================================================
    }
  }
}
