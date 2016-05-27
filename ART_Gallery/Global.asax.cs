using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ART_Gallery.Models;

namespace ART_Gallery
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Database.SetInitializer<ArtGalleryContext>(null);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
