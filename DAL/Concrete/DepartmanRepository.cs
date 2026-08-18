using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class DepartmanRepository : EfGenericRepository<Departman>, IDepartmanRepository
    {
        public DepartmanRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
