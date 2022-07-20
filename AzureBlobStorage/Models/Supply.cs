﻿namespace AzureBlobStorage.Models
{
    public class Supply
    {
        public string Description { get; set; } = "Shop Supplies";
        public string SaleCode { get; set; }
        public double MaximumCharge { get; set; }
        public CostPerInvoice CostPerInvoice { get; set; }
    }
}
