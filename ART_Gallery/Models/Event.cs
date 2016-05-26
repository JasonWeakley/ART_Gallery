using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART_Gallery.Models
{
    public class Event
    {
        public string Description { get; set; }
        public Decimal DollarSale { get; set; }
        public DateTime EndDate { get; set; }
        public int EventId { get; set; }
        public string ExhibitName { get; set; }
        public int GalleryId { get; set; }
        public double PercentSale { get; set; }
        public DateTime StartDate { get; set; }
    }
}