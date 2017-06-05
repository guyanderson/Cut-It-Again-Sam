using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Inventory.Objects
{
  public class MyLittlePony
  {
    private int _id;
    private string _name;
    private string _color;
    // private string _birthday;

    public MyLittlePony(string Name, string Color, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _color = Color;
      // _birthday = Birthday;
    }

    public override bool Equals(System.Object otherMyLittlePony)
    {
      if (!(otherMyLittlePony is MyLittlePony))
      {
        return false;
      }
      else
      {
        MyLittlePony newMyLittlePony = (MyLittlePony) otherMyLittlePony;
        bool idEquality = (this.GetId() == newMyLittlePony.GetId());
        bool nameEquality = (this.GetName() == newMyLittlePony.GetName());
        bool colorEquality = (this.GetColor() == newMyLittlePony.GetColor());
        // bool birthdayEquality = (this.GetBirthday() == newMyLittlePony.GetBirthday());
        return (idEquality && nameEquality && colorEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void  SetName(string newName)
    {
      _name = newName;
    }
    public string GetColor()
    {
      return _color;
    }
    public void  SetColor(string newColor)
    {
      _color = newColor;
    }
    // public string GetBirthday()
    // {
    //   return _birthday;
    // }
    // public void  SetBirthday(string newBirthday)
    // {
    //   _birthday = newBirthday;
    // }
    public static List<MyLittlePony> GetAll()
    {
      Console.WriteLine("beginning");
      List<MyLittlePony> allMyLittlePonies = new List<MyLittlePony>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM my_little_pony;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      Console.WriteLine("middle");

      while(rdr.Read())
      {
        int myLittlePonyId = rdr.GetInt32(0);
        string myLittlePonyName = rdr.GetString(1);
        string myLittlePonyColor = rdr.GetString(2);
        // string myLittlePonyBirthday = rdr.GetString(3);
        MyLittlePony newMyLittlePony = new MyLittlePony(myLittlePonyName, myLittlePonyColor, myLittlePonyId);
        allMyLittlePonies.Add(newMyLittlePony);
      }

      Console.WriteLine("end");

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allMyLittlePonies;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM my_little_pony;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO my_little_pony (name, color) OUTPUT INSERTED.id VALUES (@MyLittlePonyName, @MyLittlePonyColor);", conn);

      SqlParameter nameParameter = new SqlParameter();
      SqlParameter colorParameter = new SqlParameter();
      nameParameter.ParameterName = "@MyLittlePonyName";
      nameParameter.Value = this.GetName();
      colorParameter.ParameterName = "@MyLittlePonyColor";
      colorParameter.Value = this.GetColor();
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(colorParameter);


      // SqlParameter birthdayParameter = new SqlParameter();
      // birthdayParameter.ParameterBirthday = "@MyLittlePonyBirthday";
      // birthdayParameter.Value = this.GetBirthday();
      // cmd.Parameters.Add(birthdayParameter);
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
    public static MyLittlePony Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM my_little_pony WHERE id = @MyLittlePonyId;", conn);
      SqlParameter myLittlePonyIdParameter = new SqlParameter();
      myLittlePonyIdParameter.ParameterName = "@MyLittlePonyId";
      myLittlePonyIdParameter.Value = id.ToString();
      cmd.Parameters.Add(myLittlePonyIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundMyLittlePonyId = 0;
      string foundMyLittlePonyName = null;
      string foundMyLittlePonyColor = null;
      while(rdr.Read())
      {
        foundMyLittlePonyId = rdr.GetInt32(0);
        foundMyLittlePonyName = rdr.GetString(1);
        foundMyLittlePonyColor = rdr.GetString(2);
      }
      MyLittlePony foundMyLittlePony = new MyLittlePony(foundMyLittlePonyName, foundMyLittlePonyColor, foundMyLittlePonyId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundMyLittlePony;
    }
  }
}
