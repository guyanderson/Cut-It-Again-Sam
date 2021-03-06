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
      Get["/stylist/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        List<Client> StylistClient = SelectedStylist.GetClient();
        model.Add("stylist", SelectedStylist);
        model.Add("client", StylistClient);
        return View["ClientsForStylist.cshtml", model];
      };
//=======================================================
      Post["/client/delete"] = _ => {
        Client.DeleteAll();
        return View["cleared.cshtml"];
      };
//=======================================================
      Post["/stylist/delete"] = _ => {
        Stylist.DeleteAll();
        return View["cleared.cshtml"];
      };
//=======================================================
      Get["client/update/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        return View["client_update.cshtml", SelectedClient];
      };
//=======================================================
      Patch["client/update/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.Update(Request.Form["client-name"]);
        return View["success.cshtml"];
      };
//=======================================================
      Get["client/delete/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        return View["client_delete.cshtml", SelectedClient];
      };
//=======================================================
      Delete["client/delete/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.Delete();
        return View["success.cshtml"];
      };
    }
  }
}
