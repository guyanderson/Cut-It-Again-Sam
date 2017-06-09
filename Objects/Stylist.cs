using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using Hair_salon;

namespace Stylist_Object
{
  public class Stylist
  {
    private int _id;
    private string _name;
//===========================================
    public Stylist(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }
//===========================================
  }
}
