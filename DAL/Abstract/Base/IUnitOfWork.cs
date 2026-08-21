namespace StajyerTakip.DAL.Abstract.Base
{
    public interface IUnitOfWork : IDisposable
    {

        Task<int> CommitAsync(); //Repository’lerde hazırlanan ekleme, güncelleme ve silme işlemlerini veritabanına gönderir.

        //await repository.AddAsync(stajyer); -  kaydı EF Core’a eklenmek üzere verir.
        //await unitOfWork.CommitAsync(); - gerçek INSERT işlemini çalıştırır. Dönen int, etkilenen kayıt sayısıdır.
        //EF Core’daki değişiklikleri veritabanına gönderir. Yani içeride SaveChangesAsync() çalıştıracağız.

        Task BeginTransactionAsync(); //Bundan sonraki işlemleri tek bir bütün olarak değerlendir.



        Task CommitTransactionAsync(); //Transaction içindeki bütün işlemler başarılıysa kalıcı hâle getirir.

        Task RollbackTransactionAsync(); //Transaction sırasında hata oluşursa yapılan işlemleri geri alır.






        IStajyerRepository StajyerRepository { get; }  //property

        //UnitOfWork üzerinden StajyerRepository ye erişebileyim.

        IBeceriRepository BeceriRepository { get; }

        IBeceriKategoriRepository BeceriKategoriRepository { get; }

        IDegerlendirmeRepository DegerlendirmeRepository { get; }

        IDegerlendirmeKriteriRepository DegerlendirmeKriteriRepository { get; }

        IDepartmanRepository DepartmanRepository { get; }

        IDosyaRepository DosyaRepository { get; }

        IDosyaKategoriRepository DosyaKategoriRepository { get; }

        IKullaniciRepository KullaniciRepository { get; }

        ILinkRepository LinkRepository { get; }

        IModulRepository ModulRepository { get; }

        IProjeRepository ProjeRepository { get; }

        IReferansRepository ReferansRepository { get; }

        IRolRepository RolRepository { get; }

        IRolModulYetkiRepository RolModulYetkiRepository { get; }

        IStajyerBeceriRepository StajyerBeceriRepository { get; }

        IYorumRepository YorumRepository { get; }

        IAuditLogRepository AuditLogRepository { get; }




    }
}
