using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Coupon
{
    public class PromoGrpDetail
    {
        public Guid ClientId { get; set; }

        [Key]
        public int PromoGrpDetailID { get; set; }
        public int? PromoGrpID { get; set; }
        public int? PromoNum { get; set; }
        public int? Sequence { get; set; }
        public short? IsActive { get; set; } = 1;
        public short? UpdateStatus { get; set; } = 1;
        public int? SNum { get; set; } = -1;
    }

    public class PromoGrpDetailUpdate
    {
        [NotMapped]
        public required int PromoGrpDetailID { get; set; }
        public int? PromoGrpID { get; set; }
        public int? PromoNum { get; set; }
        public int? Sequence { get; set; }
        public short? IsActive { get; set; }
        public short? UpdateStatus { get; set; }
        public int? SNum { get; set; }
    }
}
