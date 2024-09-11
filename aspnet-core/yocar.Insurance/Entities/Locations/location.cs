using Volo.Abp.Domain.Entities.Auditing;
using yocar.Insurance.Entities.Garages;

namespace yocar.Insurance.Entities.Locations
{
    public class location: FullAuditedAggregateRoot<Guid>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
    }
}
