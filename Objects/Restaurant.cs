using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BestRestaurant
{
  public class Restaurant
  {
    private int _id;
    private string _name;
    private int _cuisineId;
//==========================================
    public Restaurant(string Name, int CuisineId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _cuisineId = CuisineId;
    }
//===========================================
    public int GetId()
    {
      return _id;
    }
//===========================================
    public string GetName()
    {
      return _name;
    }
//===========================================
    public void SetName(string newName)
    {
      _name =newName;
    }
//============================================
    public int GetCuisineId()
    {
      return _cuisineId;
    }
//===========================================
    public void SetCuisinetId(int newCuisineIdtId)
    {
      _cuisineId = newCuisineId;
    }
//===========================================
  }
}
