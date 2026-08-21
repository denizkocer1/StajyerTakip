using StajyerTakip.DAL.Abstract.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Abstract
{
    public interface IAuditLogRepository : IGenericRepository<AuditLog>
    {
    }
}