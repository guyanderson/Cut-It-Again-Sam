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
    [Fact]
    public void Save_SavesToDatabase_True()
    {

      Client testClient = new Client("Bob", 1);

      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      Assert.Equal(testList, result);
    }
//==========================================================
    [Fact]
    public void Find_FindsClientInDatabase_True()
    {
      Client testClient = new Client("Bob", 1);
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetId());

      Assert.Equal(testClient, foundClient);
    }
//==========================================================
    [Fact]
    public void GetId_AssignsIdToClient_True()
    {
      Client testClient = new Client("Bob", 1);

      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      Assert.Equal(testId, result);
    }
//==========================================================
    [Fact]
    public void Update_UpdatesClientInDatabase_True()
    {
      string name = "Bob";
      int StylistId = 1;
      int id = 1;
      Client testClient = new Client(name, StylistId, id);
      testClient.Save();
      string newName = "Bobby";

      testClient.Update(newName);

      string result = testClient.GetName();

      Assert.Equal(newName, result);
    }
//==========================================================
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
//==========================================================
    [Fact]
    public void Delete_DeletesClientFromDatabase_True()
    {
      Client testClient1 = new Client("Bob", 1, 1);
      testClient1.Save();


      Client testClient2 = new Client("Bobby", 2, 1);
      testClient2.Save();

      testClient1.Delete();

      List<Client> resultClients = Client.GetAll();
      List<Client> testClientList = new List<Client> {testClient2};


      Assert.Equal(testClientList, resultClients);
    }
//==========================================================
  }
}
