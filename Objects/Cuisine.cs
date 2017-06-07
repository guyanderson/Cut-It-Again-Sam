using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BestRestaurant
{
  public class Cuisine
  {
    private int _id;
    private string _name;
    private int _restaurantId;
//===========================================
    public Cuisine(string Name, int RestaurantId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _restaurantId = RestaurantId;
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
    public int GetRestaurantId()
    {
      return _restaurantId;
    }
//===========================================
    public void SetRestaurantId(int newRestaurantId)
    {
      _restaurantId = newRestaurantId;
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
        int cuisineRestaurantId = rdr.GetInt32(2);
        Cuisine newCuisine = new Cuisine(cuisineName, cuisineRestaurantId, cuisineId);
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
    public override bool Equals(System.Object otherCuisine)
    {
      if (!(otherCuisine is Cuisine))
      {
        return false;
      }
      else
      {
        Cuisine newCuisine = (Cuisine) otherCuisine;
        bool idEquality = (this.GetId() == newCuisine.GetId());
        bool nameEquality = (this.GetName() == newCuisine.GetName());
        bool restaurantEquality = (this.GetRestaurantId() == newCuisine.GetRestaurantId());
        return (nameEquality);
      }
    }
//============================================
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO cuisineTable (name, restaurant_id) OUTPUT INSERTED.id VALUES (@CuisineName, @CuisineRestaurantId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@CuisineName";
      nameParameter.Value = this.GetName();

      SqlParameter restaurantIdParameter = new SqlParameter();
      restaurantIdParameter.ParameterName = "@CuisineRestaurantId";
      restaurantIdParameter.Value = this.GetRestaurantId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(restaurantIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
//============================================
    public static Cuisine Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM cuisineTable WHERE id = @cuisineId;", conn);
      SqlParameter cuisineIdParameter = new SqlParameter();
      cuisineIdParameter.ParameterName = "@cuisineId";
      cuisineIdParameter.Value = id.ToString();
      cmd.Parameters.Add(cuisineIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundCuisineId = 0;
      string foundCuisineName = null;
      int foundCuisineRestaurantId = 0;

      while(rdr.Read())
      {
        foundCuisineId = rdr.GetInt32(0);
        foundCuisineName = rdr.GetString(1);
        foundCuisineRestaurantId = rdr.GetInt32(2);
      }
      Cuisine foundCuisine = new Cuisine(foundCuisineName, foundCuisineId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundCuisine;
    }
//============================================
  }
}
