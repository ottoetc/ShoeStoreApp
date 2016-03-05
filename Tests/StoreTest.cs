using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore
{
  public class StoreTest : IDisposable
  {
    public StoreTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=shoe_stores_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_StoreTableStartsEmpty()
    {
      int result = Store.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_EqualOverrideTrue()
    {
      Store firstStore = new Store("Fred Meyer");
      Store secondStore = new Store("Fred Meyer");

      Assert.Equal(firstStore, secondStore);
    }
    [Fact]
    public void Test_Save()
    {
      Store testStore = new Store("Fred Meyer");
      testStore.Save();

      List<Store> allStores = Store.GetAll();
      List<Store> testList = new List<Store>{testStore};

      Assert.Equal(testList, allStores);
    }
    [Fact]
    public void Test_SaveAssignsIdtoObject()
    {
      Store testStore = new Store("Fred Meyer");
      testStore.Save();

      Store savedStore = Store.GetAll()[0];

      int savedId = savedStore.GetId();
      int testId = testStore.GetId();

      Assert.Equal(savedId, testId);
    }
    public void Dispose()
    {
      Store.DeleteAll();
      Brand.DeleteAll();
    }
  }
}
