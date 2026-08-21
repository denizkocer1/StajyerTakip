using StajyerTakip.Models.DtoModels;
using StajyerTakip.Results;


namespace StajyerTakip.Services.InternalServices.Interfaces
{
    public interface IDegerlendirmeService
    {
        Task<DataResult<DegerlendirmeCreateResponseDto>> CreateAsync(
            DegerlendirmeCreateDto dto
        );
    }
}
