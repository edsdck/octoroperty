using Octo.SharedKernel;

namespace Octo.Core.Entities
{
    public class Address : BaseEntity
    {
        public string AddressLine { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Zip { get; set; }
    }
}