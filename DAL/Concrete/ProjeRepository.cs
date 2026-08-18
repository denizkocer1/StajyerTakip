using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class ProjeRepository : EfGenericRepository<Proje>, IProjeRepository
    {
        public ProjeRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
