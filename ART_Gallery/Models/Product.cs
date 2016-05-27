using ART_Gallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART_Gallery.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int GalleryId { get; set; }
        public int MediumId { get; set; }
        public int AgentId { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }
        public string Image { get; set; }
        public Decimal RetailPrice { get; set; }
        public Decimal PurchasePrice { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public List<MainViewModel> CurrentInventory { get; set; }

    }
}