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
      Get["/"] = _ => {
        List<Cuisine> AllCuisine = Cuisine.GetAll();
        return View["index.cshtml", AllCuisine];
      };
      Get["/restaurant"] = _ => {
        List<Restaurant> AllRestaurant = Restaurant.GetAll();
        return View["restaurant.cshtml", AllRestaurant];
      };
      Get["/cuisine"] = _ => {
        List<Cuisine> AllCuisine = Cuisine.GetAll();
        return View["cuisine.cshtml", AllCuisine];
      };

    }
  }
}
