using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class RolModulYetkiRepository : EfGenericRepository<RolModulYetki>, IRolModulYetkiRepository
    {
        public RolModulYetkiRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
