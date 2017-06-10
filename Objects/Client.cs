using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using HairSalon;
using Stylist_Object;

namespace Client_Object
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylistId;
//===========================================
    public Client(string Name, int StylistId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _stylistId = StylistId;
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
      return _stylistId;
    }
//===========================================
    public void SetStylisttId(int newStylistId)
    {
      _stylistId = newStylistId;
    }
//============================================
    public static List<Client> GetAll()
    {
      List<Client> allClient = new List<Client>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int clientStylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientName, clientStylistId, clientId);
        allClient.Add(newClient);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allClient;
    }
//============================================
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
//============================================
    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
        return (nameEquality && idEquality && stylistEquality);
      }
    }
//============================================
  }
}
