using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART_Gallery.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public object GalleryId { get; internal set; }
    }
}