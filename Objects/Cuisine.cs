using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BestRestaurant
{
  public class Cuisine
  {
    private int _id;
    private string _name;
//===========================================
    public Cuisine(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
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
//===========================================
    public static List<Cuisine> GetAll()
    {
      List<Cuisine> allCuisine = new List<Cuisine>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM cuisineTable;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int cuisineId = rdr.GetInt32(0);
        string cuisineName = rdr.GetString(1);
        Cuisine newCuisine = new Cuisine(cuisineName, cuisineId);
        allCuisine.Add(newCuisine);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allCuisine;
    }
//============================================
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM cuisineTable;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
//============================================
  }
}
