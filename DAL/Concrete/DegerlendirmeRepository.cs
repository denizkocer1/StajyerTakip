using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class DegerlendirmeRepository : EfGenericRepository<Degerlendirme>, IDegerlendirmeRepository
    {
        public DegerlendirmeRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
