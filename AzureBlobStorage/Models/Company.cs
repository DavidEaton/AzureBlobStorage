namespace AzureBlobStorage.Models
{
    public class Company
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Country Country { get; set; } = Country.US;
        public Phone Phone { get; set; }
        public Email Email { get; set; }
        public Franchise Franchise { get; set; }
        public string LogoUrl { get; set; } // =$"{BlobPath}/{CompanyName}/{LogoFileName}";
    }
}
