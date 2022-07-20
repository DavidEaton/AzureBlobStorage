namespace AzureBlobStorage.Models
{
    public class Phone
    {
        public string Number { get; private set; }
        public PhoneType PhoneType { get; private set; }
        public bool IsPrimary { get; private set; }
    }

}
