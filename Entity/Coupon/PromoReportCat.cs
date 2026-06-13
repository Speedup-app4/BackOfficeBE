using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Coupon
{
    [Table("PromoReportCats")]
    public class PromoReportCat
    {
        public Guid ClientId { get; set; }

        [Key]
        public int UNIQUEID { get; set; }
        public int? PROMONUM { get; set; }
        public int? REPORTNO { get; set; }
        public int? ProdNum { get; set; }
        public short? IsActive { get; set; } = 1;
        public short? RequiredItem { get; set; } = 0;
        public int? UpdateStatus { get; set; } = 1;
        public int? SNUM { get; set; } = -1;
    }

    public class PromoReportCatUpdate
    {
        [NotMapped]
        public required int UNIQUEID { get; set; }
        public int? PROMONUM { get; set; }
        public int? REPORTNO { get; set; }
        public int? ProdNum { get; set; }
        public short? IsActive { get; set; }
        public short? RequiredItem { get; set; }
        public int? UpdateStatus { get; set; }
        public int? SNUM { get; set; }
    }
}
