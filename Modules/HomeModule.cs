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
        List<Store> allStores = Store.GetAll();
        return View["index.cshtml", allStores];
      };
      Get["/stores/new"] = _ =>
      {
        List<Store> allStores = Store.GetAll();
        return View["index.cshtml", allStores];
      };
      Post["/stores/new"] = _ =>
      {
        Store newStore = new Store(Request.Form["store-name"]);
        newStore.Save();

        List<Store> allStores = Store.GetAll();
        return View["index.cshtml", allStores];
      };
    }
  }
}
