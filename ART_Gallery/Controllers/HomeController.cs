using ART_Gallery.Models;
using ART_Gallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ART_Gallery.Controllers
{
    public class HomeController : Controller
    {
        ///
        /// Do not delete Index() method below, see notes from EmployeeController.cs
        ///

        // GET: Home
        //public ActionResult Index()
        //{
        //    ArtGalleryContext _testContext = new ArtGalleryContext();

        //    List<MainViewModel> test = (from p in _testContext.ProductDbSet
        //                                select new MainViewModel
        //                                {
        //                                    Name = p.Name,
        //                                    Inventory = p.Inventory,
        //                                }).ToList();

        //    // Cannot pass a list of ViewModels to a view, but you can pass a list of
        //    // Models to a view, as long as its a property of a different ViewModel.
        //    TestViewModel batman = new TestViewModel
        //    {
        //        AllInventory = test
        //    };

        //    return View(batman);
        //}
    }
}