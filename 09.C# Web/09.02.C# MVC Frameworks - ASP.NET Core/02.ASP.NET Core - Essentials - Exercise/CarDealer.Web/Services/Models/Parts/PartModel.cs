﻿namespace CarDealer.Web.Services.Models.Parts
{
    public class PartModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }

        public string SupplierName { get; set; }
    }
}