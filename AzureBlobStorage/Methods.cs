using Azure.Storage.Blobs;
using AzureBlobStorage.Models;
using System.Text.Json;

namespace AzureBlobStorage
{
    public static class Methods
    {
        public static object GetSetting()
        {

            return new();
        }

        public static async Task<Supply> GetSupply()
        {
            return await CreateSupply();
        }

        public static async Task<Supply> GetBlob(BlobContainerClient containerClient)
        {
            BlobClient blobClient = containerClient.GetBlobClient("supply.json");

            var stream = await blobClient.OpenReadAsync();

            var result = JsonSerializer.Deserialize<Supply>(stream);

            if (result is not null)
                return result;

            return new Supply();
        }

        public static async Task<Supply> CreateSupply()
        {
            var costPerInvoice = new CostPerInvoice
            {
                Value = .08,
                Type = CostPerInvoiceType.PercentCost
            };

            var supply = new Supply
            {
                Description = "Shop Supplies",
                SaleCode = "TT",
                MaximumCharge = 8.88d,
                CostPerInvoice = costPerInvoice
            };

            // Force this into an async method:
            await Task.Delay(0);

            return supply;
        }
    }
}
