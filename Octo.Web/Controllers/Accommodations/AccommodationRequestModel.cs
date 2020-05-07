namespace Octo.Web.Controllers.Accommodations
{
    public class AccommodationRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public AddressModel Address { get; set; }
        
        public class AddressModel
        {
            public string AddressLine { get; set; }

            public string City { get; set; }

            public string Country { get; set; }

            public string Zip { get; set; }
        }
    }
}