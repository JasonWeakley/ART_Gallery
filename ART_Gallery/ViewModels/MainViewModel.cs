using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ART_Gallery.ViewModels
{
    public class MainViewModel
    {
        [Key]
        public int ProductId { get; set; }
        public int GalleryId { get; set; }
        public int CustomerId { get; set; }
        public int ArtistId { get; set; }
        public string Image { get; set; }
        public Decimal RetailPrice { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public int MediumId { get; set; }
        public int EventId { get; set; }
        public Decimal Total { get; set; }
        public Decimal PurchasePrice { get; set; }
        public int InvoiceId { get; set; }
        public int InvoiceLineId { get; set; }
        public int agentId { get; set; }
        public string Description { get; set; }
        public double PercentSale { get; set; }
        public Decimal DollarSale { get; set; }
        public string ExhibitName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public int Inventory { get; set; }
        public string EventName { get; set; }
        public int EmployeeId { get; set; }
        public List<MainViewModel> Events { get; set; }
        public List<CurrentInventoryViewModel> CurrentInventory { get; set; }
    }
}