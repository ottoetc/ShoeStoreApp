using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore
{
  public class BrandTest : IDisposable
  {
    public BrandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=shoe_stores_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_BrandTableStartsEmpty()
    {
      int result = Brand.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_EqualOverrideTrue()
    {
      Brand firstBrand = new Brand("Nike");
      Brand secondBrand = new Brand("Nike");

      Assert.Equal(firstBrand, secondBrand);
    }
    [Fact]
    public void Test_Save()
    {
      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      List<Brand> allBrands = Brand.GetAll();
      List<Brand> testList = new List<Brand>{testBrand};

      Assert.Equal(testList, allBrands);
    }
    [Fact]
    public void Test_SaveAssignsIdtoObject()
    {
      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      Brand savedBrand = Brand.GetAll()[0];

      int savedId = savedBrand.GetId();
      int testId = testBrand.GetId();

      Assert.Equal(savedId, testId);
    }
    [Fact]
    public void Test_FindMethodWorksForBrands()
    {
      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      Brand foundBrand = Brand.Find(testBrand.GetId());

      Assert.Equal(testBrand, foundBrand);
    }
    [Fact]
    public void Test_GetStores()
    {
      Store newStore = new Store("Target", 1);
      newStore.Save();

      Brand newBrand = new Brand("Nike", 1);
      newBrand.Save();

      newBrand.AddStore(newStore);

      List<Store> stores = newBrand.GetStores();
      Assert.Equal(newStore.GetName(), stores[0].GetName());
    }
    public void Dispose()
    {
      Store.DeleteAll();
      Brand.DeleteAll();
    }
  }
}
