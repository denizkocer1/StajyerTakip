using StajyerTakip.DAL.Abstract.Base;
using StajyerTakip.Models.DbModels;


namespace StajyerTakip.DAL.Abstract
{
    public interface IStajyerRepository : IGenericRepository<Stajyer> //IStajyerRepository, Generic Repository’deki bütün ortak işlemleri Stajyer için kullanacak.
    {
        Task<List<Stajyer>> GetAllWithRelationsAsync(); //listeleme için Departman ve Mentor bilgisiyle birlikte stajyerleri getirir.
    }


}
