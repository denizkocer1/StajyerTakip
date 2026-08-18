using StajyerTakip.Models.DbModels; //
using StajyerTakip.Models.DtoModels;

namespace StajyerTakip.Services.InternalServices.Interfaces
{
    public interface IStajyerService
    {
        Task<List<StajyerListResponseDto>> GetAllAsync(); //

        Task<Stajyer> CreateAsync(StajyerCreateDto dto);
    }
}
