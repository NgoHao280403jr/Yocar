namespace yocar.Insurance.Services.Dtos.InsuranceCompany
{
    public interface IInsuranceCompanyAppService
    {
        Task<InsuranceCompanyDto> GetByIdAsync(int id);
        Task<IEnumerable<InsuranceCompanyDto>> GetAllAsync();
        Task CreateAsync(CreateInsuranceCompanyDto input);
        Task UpdateAsync(UpdateInsuranceCompanyDto input);
        Task DeleteAsync(int id);
    }
}
