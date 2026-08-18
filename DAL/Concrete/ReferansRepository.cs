using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class ReferansRepository : EfGenericRepository<Referans>, IReferansRepository
    {
        public ReferansRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
