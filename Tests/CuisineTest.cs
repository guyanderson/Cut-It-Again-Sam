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
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BestRestaurant_test;Integrated Security=SSPI;";
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
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange, Act
      Cuisine firstCuisine = new Cuisine("Italian");
      Cuisine secondCuisine = new Cuisine("Italian");

      //Assert
      Assert.Equal(firstCuisine, secondCuisine);
    }
//==========================================================
    public void Dispose()
    {
     Cuisine.DeleteAll();
    }
//==========================================================
  }
}
