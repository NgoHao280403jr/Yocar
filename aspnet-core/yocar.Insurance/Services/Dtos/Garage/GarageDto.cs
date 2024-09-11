namespace yocar.Insurance.Services.Dtos.Garage
{
    public class GarageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int InsuranceCompanyId { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public int? BrandID { get; set; } // Optional
        public int? TenantId { get; set; } // Optional
    }
}
