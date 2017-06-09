using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
//using Client_Object;
using Hair_salon;
using Stylist_Object;

namespace Stylist_Test
{
  [Collection("hair_salon")]
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
      int result = Stylist.GetAll().Count;

      Assert.Equal(0, result);
    }
//===========================================================
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
//==========================================================
  }
}
