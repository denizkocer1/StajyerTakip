using Microsoft.EntityFrameworkCore.Storage;
using StajyerTakip.DAL.Abstract;
using StajyerTakip.DAL.Abstract.Base;


namespace StajyerTakip.DAL.Concrete.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable //UnitOfWork, az önce yazdığımız IUnitOfWork sözleşmesini uygulayacak
    {


        public IStajyerRepository StajyerRepository { get; } //UnitOfWork içinde bir StajyerRepository olacak. Property nin tipi interface

        public IBeceriRepository BeceriRepository { get; }

        public IBeceriKategoriRepository BeceriKategoriRepository { get; }

        public IDegerlendirmeRepository DegerlendirmeRepository { get; }

        public IDegerlendirmeKriteriRepository DegerlendirmeKriteriRepository { get; }

        public IDepartmanRepository DepartmanRepository { get; }

        public IDosyaRepository DosyaRepository { get; }

        public IDosyaKategoriRepository DosyaKategoriRepository { get; }

        public IKullaniciRepository KullaniciRepository { get; }

        public ILinkRepository LinkRepository { get; }

        public IModulRepository ModulRepository { get; }

        public IProjeRepository ProjeRepository { get; }

        public IReferansRepository ReferansRepository { get; }

        public IRolRepository RolRepository { get; }

        public IRolModulYetkiRepository RolModulYetkiRepository { get; }

        public IStajyerBeceriRepository StajyerBeceriRepository { get; }

        public IYorumRepository YorumRepository { get; }



        private readonly AppDbContext _context; //private çünkü başka repo sınıfları kullanmayacak sadece unitofwork kullanacak. readonly çünkü contructorda verilen bu context sonradan değiştirilemesin.
        private IDbContextTransaction? _transaction; //bu değişken o anda açık olan transactionı tutar.

        public UnitOfWork(
            AppDbContext context,
            IStajyerRepository stajyerRepository,
            IBeceriRepository beceriRepository,
            IBeceriKategoriRepository beceriKategoriRepository,
            IDegerlendirmeRepository degerlendirmeRepository,
            IDegerlendirmeKriteriRepository degerlendirmeKriteriRepository,
            IDepartmanRepository departmanRepository,
            IDosyaRepository dosyaRepository,
            IDosyaKategoriRepository dosyaKategoriRepository,
            IKullaniciRepository kullaniciRepository,
            ILinkRepository linkRepository,
            IModulRepository modulRepository,
            IProjeRepository projeRepository,
            IReferansRepository referansRepository,
            IRolRepository rolRepository,
            IRolModulYetkiRepository rolModulYetkiRepository,
            IStajyerBeceriRepository stajyerBeceriRepository,
            IYorumRepository yorumRepository)  //UnitOfWork nesnesi oluşturulurken AppDbContext dışarıdan alınır ve _context içine koyulur.
        {

            _context = context;


            StajyerRepository = stajyerRepository;
            BeceriRepository = beceriRepository;
            BeceriKategoriRepository = beceriKategoriRepository;
            DegerlendirmeRepository = degerlendirmeRepository;
            DegerlendirmeKriteriRepository = degerlendirmeKriteriRepository;
            DepartmanRepository = departmanRepository;
            DosyaRepository = dosyaRepository;
            DosyaKategoriRepository = dosyaKategoriRepository;
            KullaniciRepository = kullaniciRepository;
            LinkRepository = linkRepository;
            ModulRepository = modulRepository;
            ProjeRepository = projeRepository;
            ReferansRepository = referansRepository;
            RolRepository = rolRepository;
            RolModulYetkiRepository = rolModulYetkiRepository;
            StajyerBeceriRepository = stajyerBeceriRepository;
            YorumRepository = yorumRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync(); //EF Core'un takip ettiği ekleme, güncelleme ve silme değişikliklerini veritabanına kaydeder.
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync(); //EF Core üzerinden veritabanı bağlantısına erişiyoruz.
        }   //veritabanında yeni bir transaction başlatıyor. - Yani artık _transaction içinde aktif transaction tutuluyor.


        public async Task CommitTransactionAsync()
        {
            try
            {
                // EF Core'un takip ettiği ekleme, güncelleme ve silme değişikliklerini
                // veritabanına kaydetmeye çalışıyoruz.
                await _context.SaveChangesAsync();

                if (_transaction is not null) // Aktif bir transaction var mı diye kontrol ediyoruz.
                {
                    // SaveChangesAsync başarılı olduysa transaction içindeki işlemleri kalıcı hale getir.
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                // SaveChangesAsync veya CommitAsync sırasında hata oluşursa
                // transaction başladıktan sonra yapılan işlemleri geri al.
                await RollbackTransactionAsync();

                // Hatayı burada yok etmiyoruz.
                // Aynı hatayı yukarıya, yani bu metodu çağıran Service katmanına gönderiyoruz.
                throw;
            }
            finally
            {
                // Hata olsa da olmasa da burası çalışır.
                // Transaction hâlâ varsa kaynaklarını bırakıyoruz.
                if (_transaction is not null)
                {
                    await _transaction.DisposeAsync();
                }

                // Artık aktif transaction olmadığını belirtiyoruz.
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction is not null) //Aktif bir transaction var mı diye kontrol ediyoruz.
            {
                await _transaction.RollbackAsync(); //Transaction başladıktan sonra yapılan işlemleri geri al.
                await _transaction.DisposeAsync(); //kaynakları bırak
                _transaction = null; //boşa çıkar
            }
        }


        // buradaki bu transaction metodları hata var mı yok mu kontrol etmiyor,
        // sadece hata varsa olacakları yazıyor.
        // Hata var mı yok mu kontrolünü service katmanında try catch ile yakalayacağız.
        // Burada direkt metodları yazarken içlerinde try catch yapmama nedenimiz,
        // serviste daha bu komutlar çağırılmadan bir hata oluştuysa onu yakalayamayız.
        // ve rollback yapılamamış olur.

        //Hata olup olmadığına ve commit mi rollback mi yapılacağına Service karar versin.



        public void Dispose()
        {
            _context.Dispose();  //UnitOfWork'un işi bittiyse onun kullandığı DbContext'in de kaynaklarını serbest bırak
        }


    }
}
