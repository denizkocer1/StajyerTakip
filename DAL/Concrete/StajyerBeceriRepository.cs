using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class StajyerBeceriRepository : EfGenericRepository<StajyerBeceri>, IStajyerBeceriRepository
    {
        public StajyerBeceriRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
