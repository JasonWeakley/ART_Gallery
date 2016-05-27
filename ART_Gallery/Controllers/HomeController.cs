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
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: Show inventory
        public ActionResult ShowInventory()
        {
            ArtGalleryContext _inventoryContext = new ArtGalleryContext();

            //var NorthGallery = (from p in _inventoryContext.Product
            //                       where p.GalleryId == 2 && p.Inventory > 0
            //                       select new MainViewModel
            //                       {
            //                           Name = p.Name,
            //                           Inventory = p.Inventory,
            //                           RetailPrice = p.RetailPrice,
            //                           PurchasePrice = p.PurchasePrice,
            //                           Image = p.Image
            //                       }).ToList();
            var q = (from p in _inventoryContext.Product
                    orderby p.GalleryId
                                    where p.Inventory > 0
                                    select new
                                    {
                                        Name = p.Name,
                                        Inventory = p.Inventory,
                                        RetailPrice = p.RetailPrice,
                                        PurchasePrice = p.PurchasePrice,
                                        Image = p.Image
                                    });

            var qq = q.AsEnumerable().Select(xx => new MainViewModel
            {
                Name = xx.Name,
                Inventory = xx.Inventory,
                RetailPrice = xx.RetailPrice,
                PurchasePrice = xx.PurchasePrice,
                Image = xx.Image
            });

            return View(qq);
        }
    }
}