namespace yocar.Insurance.Services.Dtos.Location
{
    public interface ILocationAppService
    {
        Task<LocationDto> GetByIdAsync(int id);
        Task<IEnumerable<LocationDto>> GetAllAsync();
        Task CreateAsync(CreateLocationDto input);
        Task UpdateAsync(UpdateLocationDto input);
        Task DeleteAsync(int id);
    }
}
