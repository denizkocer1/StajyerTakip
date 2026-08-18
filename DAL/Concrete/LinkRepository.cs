using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class LinkRepository : EfGenericRepository<Link>, ILinkRepository
    {
        public LinkRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
