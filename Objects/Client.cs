using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using HairSalon;

namespace Client_Object
{
  public class Stylist
  {
    private int _id;
    private string _name;
    private int _stylistId;
//===========================================
public Restaurant(string Name, int StylistId, int Id = 0)
{
  _id = Id;
  _name = Name;
  _cuisineId = StylistId;
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
    public int GetStylistId()
    {
      return _cuisineId;
    }
//===========================================
    public void SetStylisttId(int newStylistId)
    {
      _cuisineId = newStylistId;
    }
//===========================================
  }
}
