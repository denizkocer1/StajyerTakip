using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class BeceriRepository : EfGenericRepository<Beceri>, IBeceriRepository
    {
        public BeceriRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
