using StajyerTakip.Models.DbModels;
using StajyerTakip.Models.DtoModels;
using StajyerTakip.Results;

namespace StajyerTakip.Services.InternalServices.Interfaces
{
    public interface IStajyerService
    {
        Task<DataResult<List<StajyerListResponseDto>>> GetAllAsync();

        Task<DataResult<Stajyer>> GetStajyer(int id);

        Task<DataResult<StajyerCreateResponseDto>> CreateAsync(StajyerCreateDto dto);
    }
}