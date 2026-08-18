using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class DosyaRepository : EfGenericRepository<Dosya>, IDosyaRepository
    {
        public DosyaRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
