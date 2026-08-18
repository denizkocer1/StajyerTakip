using Microsoft.EntityFrameworkCore;
using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Concrete
{
    public class KullaniciRepository : EfGenericRepository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<Kullanici?> GetByKullaniciAdiAsync(string kullaniciAdi)
        {
            return await _dbSet
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(k => k.KullaniciAdi == kullaniciAdi);
        }
    }
}
