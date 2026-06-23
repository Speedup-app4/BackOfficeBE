using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Coupon
{
    [Table("promo")]
    public class Promo
    {
        public Guid ClientId { get; set; }

        [Key]
        public int PROMONUM { get; set; }
        public string? DESCRIPT { get; set; }
        public double? AMOUNT { get; set; }
        public short? SECLEVEL { get; set; }
        public short ISACTIVE { get; set; } = 1;
        public short? PERCENT { get; set; }
        public short? ISMANUAL { get; set; }
        public short? TAX1 { get; set; }
        public short? TAX2 { get; set; }
        public short? TAX3 { get; set; }
        public short? TAX4 { get; set; }
        public short? TAX5 { get; set; }
        public short? MEMBERONLY { get; set; }
        public double? AMOUNTB { get; set; }
        public double? AMOUNTC { get; set; }
        public short? PERCENTB { get; set; }
        public short? PERCENTC { get; set; }
        public string? SCHEDULE { get; set; }
        public short? ISAMOUNT { get; set; }
        public string? SwipeStart { get; set; }
        public short? USEALLCATS { get; set; }
        public short? TWOFORONE { get; set; }
        public int? AccountCode { get; set; }
        public int? POINTREQ { get; set; }
        public short UpdateStatus { get; set; } = 1;
        public int? OneOnly { get; set; }
        public DateTime? RANGESTART { get; set; }
        public DateTime? RANGEEND { get; set; }
        public int? PRODNUM { get; set; }
        public int? ISAUTOPROD { get; set; }
        public int? AUTOPRODNUM { get; set; }
        public double AUTOPRODQUAN { get; set; } = 1;
        public int MEMBEREXIST { get; set; } = 0;
        public string? MarketingCode { get; set; }
        public short? EnableOnWeb { get; set; }
        public string? PLink { get; set; }
        public string? LongCDesc { get; set; }
        public int RevCenter { get; set; } = 0;
        public short? CouponKind { get; set; }
        public double? FixedPrice { get; set; }
        public double? MaxAmount { get; set; }
        public double? MinQuan { get; set; }
        public double? MinCost { get; set; }
        public short AutoCalc { get; set; } = 0;
        public string? DllName { get; set; }
        public short AutoApply { get; set; } = 0;
        public short RequireVoucher { get; set; } = 0;
        public short CalcMethod { get; set; } = 0;
        public short UseReqItems { get; set; } = 0;
        public int SecLock { get; set; } = 0;
        public int? XValue { get; set; }
        public int? YValue { get; set; }
        public short NoMemPoints { get; set; } = 0;
        public int PromoCatID { get; set; } = 0;
        public int SNum { get; set; } = -1;
        public long ReflectionUpdate { get; set; } = 0;

        [NotMapped]
        public List<PromoReportCat>? PromoReportCats { get; set; }
    }

    public class PromoUpdate
    {
        [NotMapped]
        public required int PROMONUM { get; set; }
        public string? DESCRIPT { get; set; }
        public double? AMOUNT { get; set; }
        public short? SECLEVEL { get; set; }
        public short? ISACTIVE { get; set; }
        public short? PERCENT { get; set; }
        public short? ISMANUAL { get; set; }
        public short? TAX1 { get; set; }
        public short? TAX2 { get; set; }
        public short? TAX3 { get; set; }
        public short? TAX4 { get; set; }
        public short? TAX5 { get; set; }
        public short? MEMBERONLY { get; set; }
        public double? AMOUNTB { get; set; }
        public double? AMOUNTC { get; set; }
        public short? PERCENTB { get; set; }
        public short? PERCENTC { get; set; }
        public string? SCHEDULE { get; set; }
        public short? ISAMOUNT { get; set; }
        public string? SwipeStart { get; set; }
        public short? USEALLCATS { get; set; }
        public short? TWOFORONE { get; set; }
        public int? AccountCode { get; set; }
        public int? POINTREQ { get; set; }
        public short? UpdateStatus { get; set; }
        public int? OneOnly { get; set; }
        public DateTime? RANGESTART { get; set; }
        public DateTime? RANGEEND { get; set; }
        public int? PRODNUM { get; set; }
        public int? ISAUTOPROD { get; set; }
        public int? AUTOPRODNUM { get; set; }
        public double? AUTOPRODQUAN { get; set; }
        public int? MEMBEREXIST { get; set; }
        public string? MarketingCode { get; set; }
        public short? EnableOnWeb { get; set; }
        public string? PLink { get; set; }
        public string? LongCDesc { get; set; }
        public int? RevCenter { get; set; }
        public short? CouponKind { get; set; }
        public double? FixedPrice { get; set; }
        public double? MaxAmount { get; set; }
        public double? MinQuan { get; set; }
        public double? MinCost { get; set; }
        public short? AutoCalc { get; set; }
        public string? DllName { get; set; }
        public short? AutoApply { get; set; }
        public short? RequireVoucher { get; set; }
        public short? CalcMethod { get; set; }
        public short? UseReqItems { get; set; }
        public int? SecLock { get; set; }
        public int? XValue { get; set; }
        public int? YValue { get; set; }
        public short? NoMemPoints { get; set; }
        public int? PromoCatID { get; set; }
        public int? SNum { get; set; }
        public long? ReflectionUpdate { get; set; }

        [NotMapped]
        public List<PromoReportCat>? PromoReportCats { get; set; }
    }
}
