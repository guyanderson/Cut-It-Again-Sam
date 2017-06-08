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
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Italian");

      //Act
      testCuisine.Save();
      List<Cuisine> result = Cuisine.GetAll();
      List<Cuisine> testList = new List<Cuisine>{testCuisine};

      //Assert
      Assert.Equal(testList, result);
    }
//==========================================================
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Italian");

      //Act
      testCuisine.Save();
      Cuisine savedCuisine = Cuisine.GetAll()[0];

      int result = savedCuisine.GetId();
      int testId = testCuisine.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
//==========================================================
    [Fact]
    public void Find_FindsTaskInDatabase_True()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Italian");
      testCuisine.Save();

      //Act
      Cuisine foundCuisine = Cuisine.Find(testCuisine.GetId());

      //Assert
      Assert.Equal(testCuisine, foundCuisine);
    }
//==========================================================
    public void Dispose()
    {
      Cuisine.DeleteAll();
    }
//==========================================================
  }
}
