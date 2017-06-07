using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;


namespace BestRestaurant
{
  public class CuisineTest : IDisposable
  {
    public CuisineTest()
    {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial   Catalog=BestRestaurant_test;Integrated Security=SSPI;";
    }
//==========================================================
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Cuisine.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
//==========================================================
    public void Dispose()
    {
     Cuisine.DeleteAll();
    }
//==========================================================
  }
}
