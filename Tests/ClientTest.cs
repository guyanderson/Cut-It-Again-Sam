using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon;
using Stylist_Object;
using Client_Object;

namespace Client_Test
{
  [Collection("Stylist_Test")]
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
//===========================================================
    [Fact]
    public void GetAll_TestDatabaseEmpty_True()
    {
      int result = Client.GetAll().Count;

      Assert.Equal(0, result);
    }
//===========================================================
    [Fact]
    public void Equals_OverrideReturnsTrueIfNamesAreTheSame_True()
    {
      Client firstClient = new Client("Bob", 1);
      Client secondClient = new Client("Bob", 1);

      Assert.Equal(firstClient, secondClient);
    }
//==========================================================
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
//==========================================================
  }
}
