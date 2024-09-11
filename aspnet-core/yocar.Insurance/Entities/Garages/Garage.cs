using Volo.Abp.Domain.Entities.Auditing;
using yocar.Insurance.Entities.Brands;
using yocar.Insurance.Entities.InsuranceCompanies;
using yocar.Insurance.Entities.Locations;

namespace yocar.Insurance.Entities.Garages
{
    public class Garage: FullAuditedAggregateRoot<Guid>
    {
        
        public string Name { get; set; }
        public string Address { get; set; }
        public int InsuranceCompanyId { get; set; } // Foreign key
        public InsuranceCompany InsuranceCompany { get; set; } // Navigation property
        public string ContactPersonName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public int? BrandId { get; set; } // Optional foreign key
        public Brand Brand { get; set; } // Optional navigation property
        public int? TenantId { get; set; }

        public virtual ICollection<location> Locations { get; set; }
    }
}
