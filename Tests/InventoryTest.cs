using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Inventory.Objects;

namespace Inventory
{
  public class InventoryTest : IDisposable
  {
    public InventoryTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=inventory_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      MyLittlePony.DeleteAll();
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = MyLittlePony.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      MyLittlePony testMyLittlePony = new MyLittlePony("Applejack", "Orange");

      //Act
      testMyLittlePony.Save();
      List<MyLittlePony> result = MyLittlePony.GetAll();
      List<MyLittlePony> testList = new List<MyLittlePony>{testMyLittlePony};

      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      MyLittlePony testMyLittlePony = new MyLittlePony("Applejack", "Orange");

      //Act
      testMyLittlePony.Save();
      MyLittlePony savedMyLittlePony = MyLittlePony.GetAll()[0];

      int result = savedMyLittlePony.GetId();
      int testId = testMyLittlePony.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsMyLittlePonyInDatabase()
    {
      //Arrange
      MyLittlePony testMyLittlePony = new MyLittlePony("Applejack", "Orange");
      testMyLittlePony.Save();

      //Act
      MyLittlePony foundMyLittlePony = MyLittlePony.Find(testMyLittlePony.GetId());

      //Assert
      Assert.Equal(testMyLittlePony, foundMyLittlePony);
    }
  }
}
