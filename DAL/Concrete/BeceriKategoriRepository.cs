using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class BeceriKategoriRepository : EfGenericRepository<BeceriKategori>, IBeceriKategoriRepository
    {
        public BeceriKategoriRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
