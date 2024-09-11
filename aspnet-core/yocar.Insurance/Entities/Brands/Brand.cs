using Volo.Abp.Domain.Entities.Auditing;

namespace yocar.Insurance.Entities.Brands
{
    public class Brand :FullAuditedAggregateRoot<Guid>
    {
        
        public  string Name { get; set; }

       
        public  string Slug { get; set; }

        
        public  string Description { get; set; }

        public  bool IsVerified { get; set; }
    }
}
