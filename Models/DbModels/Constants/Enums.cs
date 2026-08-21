namespace StajyerTakip.Models.DbModels.Constants
{
    public class Enums
    {
        public enum AuditLogType
        {
            // Giriş / çıkış
            Login = 1,
            Logout = 2,
            LoginFailed = 3,

            // Yetkilendirme
            AuthorizationFailed = 10,

            // Veri işlemleri
            Create = 20,
            Update = 21,
            Delete = 22,

            RoleChanged = 30,

            // LDAP işlemleri
            LdapLogin = 40,
            LdapLoginFailed = 41,
            LdapUserNotFound = 42,

            // Özel audit işlemleri
            Audit = 50
        }
    }
}