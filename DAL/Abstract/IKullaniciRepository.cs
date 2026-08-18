using StajyerTakip.DAL.Abstract.Base;
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL.Abstract
{
    public interface IKullaniciRepository : IGenericRepository<Kullanici>
    {
        Task<Kullanici?> GetByKullaniciAdiAsync(string kullaniciAdi); //login için kullanıcıyı Rol bilgisiyle birlikte getirir.
    }
}
