using System.Linq.Expressions;  //using- bu namespace içindeki classları kullanacağım.

namespace StajyerTakip.DAL.Abstract.Base //namespace- classları gruplamak için kullanılan klasör gibi yapı.
{
    public interface IGenericRepository<T> where T : class // T hangi entity ile çalışacağımızı temsil ediyor ve T bir class olabilir.
    {
        Task<List<T>> GetAllAsync(); //ilgili tablodaki bütün kayıtları getir
        Task<T?> GetByIdAsync(int id); //ilgili tablodaki id ye göre tek bir kayıt getir. ? nedeni verilen id ye ait kayıt bulunamayabilir.
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate); //koşula göre kayıt arar.
        Task AddAsync(T entity); //yeni kayıt ekler
        void Update(T entity); //var olan kaydı güncellenecek olarak işaretler
        void Delete(T entity); //kaydı silinecek olarak işaretler

        Task<List<TResult>> GetSelectListAsync<TResult>(  //TResult bir stringtir ve geri dönüşü string oluyor.
            Expression<Func<T, bool>> predicate,  //Hangi kayıtlar arasından seçeceğim?  - Aktif stajyerlerin
            Expression<Func<T, TResult>> selector);  //Hangi alanı/alanları seçmek istiyorsun?  - Sadece adını getir.



    }
}

//interface bu classın yapılacaklar listesidir.
//bu classta update delete add olacak diyor.


/*Class = Kalıp (Şablon) - public class Kullanici
{
    public string Ad { get; set; }
public string Soyad { get; set; }
} */

//Object(Nesne) = O kalıptan üretilmiş gerçek şey - var kullanici = new Kullanici();


