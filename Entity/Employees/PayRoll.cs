using System.ComponentModel.DataAnnotations;

namespace BackOffice.Entity.Employees
{
    public class PayRoll
    {
        public Guid ClientId { get; set; }

        [Key]
        public int UNIQUEID { get; set; }
        public int? EMPNUM { get; set; }
        public int? JOBPOS { get; set; }
        public decimal? PAYRATE { get; set; }
        public short? ISACTIVE { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public string? PLink { get; set; }
        public short? IsPrimary { get; set; } = 0;
        public int? SNUM { get; set; } = -1;
    }
}
