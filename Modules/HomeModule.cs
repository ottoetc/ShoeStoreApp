using Nancy;
using ShoeStore;
using System.Collections.Generic;
using System;

namespace ShoeStore
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        return View["index.cshtml"];
      };
      Get["/stores"] = _ =>
      {
        List<Store> allStores = Store.GetAll();
        return View["stores.cshtml", allStores];
      };
      Get["/stores/new"] = _ =>
      {
        List<Store> allStores = Store.GetAll();
        return View["stores.cshtml", allStores];
      };
      Post["/stores/new"] = _ =>
      {
        Store newStore = new Store(Request.Form["store-name"]);
        newStore.Save();

        List<Store> allStores = Store.GetAll();
        return View["stores.cshtml", allStores];
      };
      Get["/brands"] = _ =>
      {
        List<Brand> allBrands = Brand.GetAll();
        return View["brands.cshtml", allBrands];
      };
      Get["/brands/new"] = _ =>
      {
        List<Brand> allBrands = Brand.GetAll();
        return View["brands.cshtml", allBrands];
      };
      Post["/brands/new"] = _ =>
      {
        Brand newBrand = new Brand(Request.Form["brand-name"]);
        newBrand.Save();

        List<Brand> allBrands = Brand.GetAll();
        return View["brands.cshtml", allBrands];
      };
      Get["/store/delete/{id}"] = parameters =>
      {
        Store selectedStore = Store.Find(parameters.id);
        return View["store_delete.cshtml", selectedStore];
      };
      Delete["/store/delete/{id}"] = parameters =>
      {
        Store selectedStore = Store.Find(parameters.id);
        selectedStore.Delete();
        List<Store> allStores = Store.GetAll();
        return View["stores.cshtml", allStores];
      };
      Get["/store/edit/{id}"] = parameters =>
      {
        Store selectedStore = Store.Find(parameters.id);
        return View["store_edit.cshtml", selectedStore];
      };
      Patch["/store/edit/{id}"] = parameters =>
      {
        Store selectedStore = Store.Find(parameters.id);
        selectedStore.Update(Request.Form["store-name"]);
        List<Store> allStores = Store.GetAll();
        return View["stores.cshtml", allStores];
      };
      Get["stores/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Store selectedStore = Store.Find(parameters.id);
        List<Brand> storesBrands = selectedStore.GetBrands();
        List<Brand> allBrands = Brand.GetAll();
        model.Add("store", selectedStore);
        model.Add("storesBrands", storesBrands);
        model.Add("allBrands", allBrands);
        return View["store.cshtml", model];
      };
      Get["brands/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Brand selectedBrand = Brand.Find(parameters.id);
        List<Store> brandsStores = selectedBrand.GetStores();
        List<Store> allStores = Store.GetAll();
        model.Add("brand", selectedBrand);
        model.Add("brandsStores", brandsStores);
        model.Add("allStores", allStores);
        return View["brand.cshtml", model];
      };
      Post["/store/add_brand"] = _ =>
      {
        Brand brand = Brand.Find(Request.Form["brand-id"]);
        Store store = Store.Find(Request.Form["store-id"]);
        store.AddBrand(brand);
        List<Store> allStores = Store.GetAll();
        return View["stores.cshtml", allStores];
      };
      Post["/brand/add_store"] = _ =>
      {
        Brand brand = Brand.Find(Request.Form["brand-id"]);
        Store store = Store.Find(Request.Form["store-id"]);
        brand.AddStore(store);
        List<Brand> allBrands = Brand.GetAll();
        return View["brands.cshtml", allBrands];
      };
    }
  }
}
