using ART_Gallery.Models;
using ART_Gallery.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ART_Gallery.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
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
                    _context.Product.Add(product); // "saves" in context to data in working memory
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