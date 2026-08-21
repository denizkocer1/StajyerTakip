using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class AuditLogRepository
        : EfGenericRepository<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}