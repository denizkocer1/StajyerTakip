using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class DosyaKategoriRepository : EfGenericRepository<DosyaKategori>, IDosyaKategoriRepository
    {
        public DosyaKategoriRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
