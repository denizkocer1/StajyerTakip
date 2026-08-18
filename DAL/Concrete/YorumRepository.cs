using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class YorumRepository : EfGenericRepository<Yorum>, IYorumRepository
    {
        public YorumRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
