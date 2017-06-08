using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant_Object;
using BestRestaurant;

namespace RestaurantTest_Test
{
  public class RestaurantTest : IDisposable
  {
    public RestaurantTest()
    {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BestRestaurant_test;Integrated Security=SSPI;";
    }
//========================================================
    // [Fact]
    // public void Test_DatabaseEmptyAtFirst()
    // {
    //   //Arrange, Act
    //   int result = Restaurant.GetAll().Count;
    //
    //   //Assert
    //   Assert.Equal(0, result);
    // }
//========================================================
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange, Act
      Restaurant firstRestaurant = new Restaurant("Pastini", 1);
      Restaurant secondRestaurant = new Restaurant("Pastini", 1);

      //Assert
      Assert.Equal(firstRestaurant, secondRestaurant);
    }
//==========================================================
    // [Fact] -bring back
    // public void Test_Save_SavesToDatabase()
    // {
    //   //Arrange
    //   Restaurant testRestaurant = new Restaurant("Pastini", 1);
    //
    //   //Act
    //   testRestaurant.Save();
    //   List<Restaurant> result = Restaurant.GetAll();
    //   List<Restaurant> testList = new List<Restaurant> {testRestaurant};
    //
    //   //Assert
    //   Assert.Equal(testList, result);
    // }
//==========================================================
    // [Fact]
    // public void Test_Save_AssignsIdToObject()
    // {
    //   //Arrange
    //   Restaurant testRestaurant = new Restaurant("Italian");
    //
    //   //Act
    //   testRestaurant.Save();
    //   Restaurant savedRestaurant = Restaurant.GetAll()[0];
    //
    //   int result = savedRestaurant.GetId();
    //   int testId = testRestaurant.GetId();
    //
    //   //Assert
    //   Assert.Equal(testId, result);
    // }
//==========================================================
    // [Fact] -bring back
    // public void Find_FindsTaskInDatabase_True()
    // {
    //   //Arrange
    //   Restaurant testRestaurant = new Restaurant("Pastini", 1);
    //   testRestaurant.Save();
    //
    //   //Act
    //   Restaurant foundRestaurant = Restaurant.Find(testRestaurant.GetId());
    //   //Assert
    //   Assert.Equal(testRestaurant, foundRestaurant);
    // }
//===========================================================
    // [Fact]
    // public void GetCuisine_RetrievesAllCuisineWithRestaurant()
    // {
    //   Restaurant testRestaurant = new Restaurant("Pastini");
    //   testRestaurant.Save();
    //
    //   Cuisine firstCuisine = new Cuisine("Italian", testRestaurant.GetId());
    //   firstCuisine.Save();
    //   Cuisine secondCuisine = new Cuisine("Mexican")
    // }
//==========================================================
    public void Dispose()
    {
      Restaurant.DeleteAll();
    }
//===========================================================
  }
}
