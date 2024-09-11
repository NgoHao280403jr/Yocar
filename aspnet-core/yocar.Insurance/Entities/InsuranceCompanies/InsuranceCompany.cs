using Volo.Abp.Domain.Entities.Auditing;
using yocar.Insurance.Entities.Garages;

namespace yocar.Insurance.Entities.InsuranceCompanies
{
    public class InsuranceCompany: FullAuditedAggregateRoot<Guid>
    {
        public string name { get; set; }   
        public int TenantId { get; set; }

        public ICollection<Garage> Garages { get; set; }
    }
}
