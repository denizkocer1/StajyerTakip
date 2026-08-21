namespace StajyerTakip.Models.DbModels
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }

        public DateTime Created { get; set; }

        public int? KullaniciId { get; set; }

        public string? TableName { get; set; }

        public int? RecordId { get; set; }

        public int LogTypeId { get; set; }

        public string? Description { get; set; }

        public string? Data { get; set; }
    }
}