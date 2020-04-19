using Octo.SharedKernel;

namespace Octo.Core.Entities
{
    public class Accommodation : BaseEntity
    {
        public string Name { get; set; }

        public string OwnerId { get; set; }

        public OctoUser Owner { get; set; }
    }
}