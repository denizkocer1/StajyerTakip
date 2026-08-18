using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class ModulRepository : EfGenericRepository<Modul>, IModulRepository
    {
        public ModulRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
