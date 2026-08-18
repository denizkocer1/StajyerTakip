using Microsoft.EntityFrameworkCore;
using StajyerTakip.DAL.Abstract.Base;
using System.Linq.Expressions; // Expression<Func<T, bool>> bu tip bu namespace in içinde
                              //ef core okur sql e çevirir.

namespace StajyerTakip.DAL.Concrete.Base    
{                                                 // IGenericRepository<T> - bu sınıf, interface te yazdığımız kurallara uyacak demek.
    //class
    public abstract class EfGenericRepository<T> : IGenericRepository<T> where T : class //bu sınıf interface i uygular. T yerine yalnızca sınıf türleri gelebilir.
    {                                                                                       // şimdilik hangi sınıf olduğu belli olmayan tip
        protected readonly AppDbContext _context; //veritabanı bağlantısı ve ef işlemlerinin yönetildiği yer
        protected readonly DbSet<T> _dbSet;  //Repository nin çalıştığı tabloyu temsil eder.

        // AppDbContext _context -  burası değişken tanımlıyor. AppDbContext tipinde bir değişkenim var diyor.
                                   //Veritabanı bağlantısını tutan nesne.
        
        //readonly - Bir kere değer ver, sonra değiştirme. repository oluşturulduktan sonra veritabanı bağlantsı değişmesin. hep aynı context ile çalışsın.

        //private - sadece aynı sınıf görebilir.
        //public - herkes görebilir.
        //protected - sadece aynı sınıf ve bu aynı sınıftan türeyen sınıflar görebilir.
        //başka bir sınıftan erişilebilsin diye


        //abstract class - bu sınıfı doğrudan kullanılmak yerine, bütün özel repository lere temel yapmak istiyoruz.
                       //- tek başına kullanılmak için değil, başka sınıflara temel olmak için yazılan sınıftır.
        
        //interface - sadece sözleşme
        //class - normal sınıf, nesne üretilebilir.


        public EfGenericRepository(AppDbContext context) //constructor-yapıcı
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        //Constructor - sınıftan bir nesne oluşturulurken otomatik çalışan özel metottur.
        //Contructor olduğu için adı sınıfla aynıdır.
        //Geri dönüş tipi yoktur. - void, int, Task
        //her class ın constructor ı vardır. yazmasan bile boş constructor gelir.



        public async Task<List<T>> GetAllAsync() //İlgili tablodaki tüm kayıtları getir.
        {
            return await _dbSet.ToListAsync(); //SELECT * FROM "Departmanlar";
        }


        public async Task<T?> GetByIdAsync(int id) //primary key değerine göre bir kayıt arar. <T?> olmasının nedeni aranan kayıt bulunamayabilir.
        {
            return await _dbSet.FindAsync(id);  //birleşik primary key kullanan entityler için uygun değil.
        }


        public virtual async Task<List<TResult>> GetSelectListAsync<TResult>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> selector)
        {
            return await _dbSet
                .Where(predicate)  //hangi satırları alacağız mesela x=>x.AktifMi dediğinde sadece aktif kayıtlar gelir.
                .Select(selector)  // hangi kolonları alacağımızı belirler mesela x=>x.Ad dediğinde sadece Ad alanı gelir.
                .ToListAsync();
        }



        //FindAsync içindeki predicate dışarıdan gönderilen filtre koşuludur.
        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {//koşula uyan kayıtları getir.
            return await _dbSet
                .Where(predicate) //ef core koşulu sql e çevirir.
                .ToListAsync();
            //predicate özel bir anahtal kelime değildir. Parametre adıdır. isterdiğini yazabilirsin.
        }

        public async Task AddAsync(T entity) //yeni entity yi ef core un takip sistemine ekler.
        {//entity bir anahtar kelime değil. T parametrenin tipi, entity parametrenin adı.
         //entity bir satırdır. 
            await _dbSet.AddAsync(entity);//bu noktada postgreye kayıt(insert) gitmez.
            //gerçek kayıt işlemi SaveChangesAsync() çalıştığında gerçekleşir. Bunu UnitOfWork yöneticek.
        }


        //async - metodun asenkron çalışabileceğini belirtir. Bu metodda await kullanılacak demek için.
        //await - uzun süren işlemin tamamlanmasını beklerken thread i gereksiz yere kilitlemez.
               // veritabanı işlemleri zaman alabilir. burada uygulama veritabanından cevap beklerken diğeri istekleri işlemeye devam edebilir.

        public void Update(T entity) // entity yi değiştirilmiş olarak işaretler.
        {
            _dbSet.Update(entity);
        }  //metod
        //

        public void Delete(T entity) // entity yi silinecek olarak işaretler.
        {
            _dbSet.Remove(entity);
        }







    }
}


