using Microsoft.EntityFrameworkCore;
using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Concrete.Base;
using StajyerTakip.Models.DbModels;



namespace StajyerTakip.DAL
{
    public class StajyerRepository : EfGenericRepository<Stajyer>, IStajyerRepository
    {
        //EfGenericRepository<Stajyer> - Stajyer için ortak CRUD kodlarını hazır al.
        //IStajyerRepository - Stajyer repository sözleşmesine uy.
        public StajyerRepository(AppDbContext context)  //Constructor
        : base(context) //AppDbContext geliyor ve üst sınıfı olanEfGenericRepository<Stajyer> constructor ına gönderiliyor.
        {
        }

        public async Task<List<Stajyer>> GetAllWithRelationsAsync()
        {
            return await _dbSet
                .Include(s => s.Departman)
                .Include(s => s.Mentor)
                .ToListAsync();
        }

    }
}



// yani üst sınıfındaki
// _context = context; ve
// _dbSet = context.Set<T>();
// miras alındı ve T = Stajyer olduğu için
// _dbSet artık DbSet<Stajyer> oluyor