using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class DegerlendirmeKriteriRepository : EfGenericRepository<DegerlendirmeKriteri>, IDegerlendirmeKriteriRepository
    {
        public DegerlendirmeKriteriRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
