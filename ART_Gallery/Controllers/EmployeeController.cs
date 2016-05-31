using ART_Gallery.Models;
using ART_Gallery.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ART_Gallery.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Owner()
        {
            ArtGalleryContext _employeeContext = new ArtGalleryContext();

            var employeeAdmin = (from emp in _employeeContext.Employee
                                 join galy in _employeeContext.Gallery
                                 on emp.GalleryId equals galy.GalleryId
                                 join evnt in _employeeContext.Event
                                 on galy.GalleryId equals evnt.GalleryId
                                 orderby evnt.EventId
                                 select new MainViewModel
                                 {
                                     EventName = evnt.ExhibitName,
                                     EmployeeId = emp.EmployeeId
                                 }).ToList();
            MainViewModel employeeView = new MainViewModel
            {
                Events = employeeAdmin
            };

            return View(employeeView);

        }

        public ActionResult ShowInventory()
            // the return statement below where qq is passed allows this method to communicate 
            // with the cshtml file of the same name and "@model" this data
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
            var q = (from p in _inventoryContext.ProductDbSet
                    orderby p.GalleryId
                    where p.Inventory > 0
                    select new
                    {
                        Name = p.Name,
                        Inventory = p.Inventory,
                        RetailPrice = p.RetailPrice,
                        PurchasePrice = p.PurchasePrice,
                        Image = p.Image
                    }).ToList();

            var qq = q.AsEnumerable().Select(xx => new MainViewModel
            {
                Name = xx.Name,
                Inventory = xx.Inventory,
                RetailPrice = xx.RetailPrice,
                PurchasePrice = xx.PurchasePrice,
                Image = xx.Image
            }).ToList();

            return View(qq);
        }














        [HttpGet]
        public ActionResult CreateInventory()
        {
            return View();
        }

        [HttpPost] // must be here for it to work
        public ActionResult CreateInventory(MainViewModel productDetails)
        {
            using (ArtGalleryContext _context = new ArtGalleryContext())
            {
                if (ModelState.IsValid)
                {
                    Product product = new Product
                    {
                        Name = productDetails.Name,
                        Description = productDetails.Description,
                        Inventory = productDetails.Inventory,
                        Image = productDetails.Image,
                        RetailPrice = productDetails.RetailPrice,
                        PurchasePrice = productDetails.PurchasePrice,
                        Width = productDetails.Width,
                        Height = productDetails.Height,
                        Depth = productDetails.Depth,
                        Weight = productDetails.Weight
                    };
                    _context.ProductDbSet.Add(product); // "saves" in context to data in working memory
                    _context.SaveChanges(); // saves to the database
                    return RedirectToAction("Index");
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost] //must be here for it to work
        public ActionResult CreateEvent(MainViewModel eventDetails)
        {
            using (ArtGalleryContext _context = new ArtGalleryContext())
            {
                if (ModelState.IsValid)
                {
                    Event galevent = new Event
                    {
                        ExhibitName = eventDetails.ExhibitName,
                        Description = eventDetails.Description,
                        PercentSale = eventDetails.PercentSale,
                        DollarSale = eventDetails.DollarSale,
                        StartDate = eventDetails.StartDate,
                        EndDate = eventDetails.EndDate
                    };
                    _context.Event.Add(galevent);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(eventDetails);
        }
    }
}