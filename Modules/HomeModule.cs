using Nancy;
using System.Collections.Generic;
using System;
using Nancy.ViewEngines.Razor;
using Restaurant_Object;
using BestRestaurant;
using Cuisine_Object;


namespace BestRestaurant.Modules
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
//=======================================================
      Get["/"] = _ => {
        List<Cuisine> AllCuisine = Cuisine.GetAll();
        return View["index.cshtml", AllCuisine];
      };
//=======================================================
      Get["/restaurant"] = _ => {
        List<Restaurant> AllRestaurant = Restaurant.GetAll();
        return View["restaurant.cshtml", AllRestaurant];
      };
//=======================================================
      Get["/cuisine"] = _ => {
        List<Cuisine> AllCuisine = Cuisine.GetAll();
        return View["cuisine.cshtml", AllCuisine];
      };
//=======================================================
      Get["/cuisine/new"] = _ => {
        return View["cuisine_form.cshtml"];
      };
//=======================================================
      Post["/cuisine/new"] = _ => {
        Cuisine newCuisine = new Cuisine(Request.Form["cuisine-name"]);
        newCuisine.Save();
        return View["success.cshtml"];
      };
//=======================================================
      Get["/restaurant/new"] = _ => {
        List<Cuisine> AllCuisine = Cuisine.GetAll();
        return View["restaurant_form.cshtml", AllCuisine];
      };
//=======================================================
      Post["/restaurant/new"] = _ => {
        Restaurant newRestaurant = new Restaurant(Request.Form["restaurant-name"], Request.Form["cuisine-id"]);
        newRestaurant.Save();
        return View["success.cshtml"];
      };
//=======================================================
      Post["/restaurant/delete"] = _ => {
        Restaurant.DeleteAll();
        return View["cleared.cshtml"];
      };
//=======================================================
      Get["/cuisine/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
        List<Restaurant> CuisineRestaurant = SelectedCuisine.GetRestaurant();
        model.Add("cuisine", SelectedCuisine);
        model.Add("restaurant", CuisineRestaurant);
        return View["RestaurantsInCuisine.cshtml", model];
      };
//=======================================================
    }
  }
}
