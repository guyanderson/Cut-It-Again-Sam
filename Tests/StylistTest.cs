using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon;
using Stylist_Object;
using Client_Object;

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
      Stylist firstStylist = new Stylist("Sam");
      Stylist secondStylist = new Stylist("Sam");

      Assert.Equal(firstStylist, secondStylist);
    }
//==========================================================
    [Fact]
    public void Save_SavesToDatabase_True()
    {
      Stylist testStylist = new Stylist("Sam");

      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      Assert.Equal(testList, result);
    }
//==========================================================
    [Fact]
    public void GetId_AssignsIdToStylist_True()
    {
      Stylist testStylist = new Stylist("Sam");

      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      Assert.Equal(testId, result);
    }
//==========================================================
    [Fact]
    public void Find_FindsStylistInDatabase_True()
    {
      Stylist testStylist = new Stylist("Sam");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
    }
//==========================================================
    [Fact]
    public void GetClient_RetrievesAllClientWithStylist_True()
    {
      Stylist testStylist = new Stylist("Sam");
      testStylist.Save();

      Client firstClient = new Client("Bob", testStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client("Bobby", testStylist.GetId());
      secondClient.Save();


      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClient();
      Assert.Equal(testClientList, resultClientList);
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
