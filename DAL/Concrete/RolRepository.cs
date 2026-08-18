using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class RolRepository : EfGenericRepository<Rol>, IRolRepository
    {
        public RolRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
