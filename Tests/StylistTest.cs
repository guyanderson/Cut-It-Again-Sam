using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
//using Client_Object;
using HairSalon;
using Stylist_Object;

namespace Stylist_Test
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
      int result = Stylist.GetAll().Count;

      Assert.Equal(0, result);
    }
//===========================================================
    [Fact]
    public void Equals_OverrideReturnsTrueIfNamesAreTheSame_True()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Sam");
      Stylist secondStylist = new Stylist("Sam");

      //Assert
      Assert.Equal(firstStylist, secondStylist);
    }
//==========================================================
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
//==========================================================
  }
}
