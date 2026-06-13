using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Coupon
{
    public class PromoGrp
    {
        public Guid ClientId { get; set; }

        [Key]
        public int PromoGrpID { get; set; }
        public string? Descript { get; set; }
        public short? SecLevel { get; set; }
        public int? RevCenter { get; set; }
        public DateTime? RangeStart { get; set; }
        public DateTime? RangeEnd { get; set; }
        public string? Schedule { get; set; }
        public short? AutoApply { get; set; }
        public short? AutoCalc { get; set; }
        public string? SwipeStart { get; set; }
        public short? MemberOnly { get; set; }
        public int? PointReq { get; set; }
        public int? MemberExist { get; set; }
        public short? IsActive { get; set; } = 1;
        public short? UpdateStatus { get; set; } = 1;
        public int? SNum { get; set; } = -1;
        public int? PromoCatID { get; set; } = 0;

        [NotMapped]
        public List<PromoGrpDetail>? PromoGrpDetails { get; set; }

        [NotMapped]
        public PromoCat? PromoCat { get; set; }
    }

    public class PromoGrpUpdate
    {
        [NotMapped]
        public required int PromoGrpID { get; set; }
        public string? Descript { get; set; }
        public short? SecLevel { get; set; }
        public int? RevCenter { get; set; }
        public DateTime? RangeStart { get; set; }
        public DateTime? RangeEnd { get; set; }
        public string? Schedule { get; set; }
        public short? AutoApply { get; set; }
        public short? AutoCalc { get; set; }
        public string? SwipeStart { get; set; }
        public short? MemberOnly { get; set; }
        public int? PointReq { get; set; }
        public int? MemberExist { get; set; }
        public short? IsActive { get; set; }
        public short? UpdateStatus { get; set; }
        public int? SNum { get; set; }
        public int? PromoCatID { get; set; }

        [NotMapped]
        public List<PromoGrpDetail>? PromoGrpDetails { get; set; }

        [NotMapped]
        public PromoCat? PromoCat { get; set; }
    }
}
