namespace yocar.Insurance.Services.Dtos.Garage
{
    public interface IGarageAppService
    {
        Task<GarageDto> GetByIdAsync(int id);
        Task<IEnumerable<GarageDto>> GetAllAsync();
        Task CreateAsync(CreateGarageDto input);
        Task UpdateAsync(UpdateGarageDto input);
        Task DeleteAsync(int id);
    }
}
