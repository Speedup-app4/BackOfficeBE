using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Payment
{
    [Table("MethodPay")]
    public class MethodPay
    {
        public Guid ClientId { get; set; }

        [Key]
        public int METHODNUM { get; set; }
        public required string DESCRIPT { get; set; }
        public short ISACTIVE { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public short? CURRENCY { get; set; }
        public short? AUTHREQR { get; set; }
        public double? EXCHANGE { get; set; }
        public short? SecLevel { get; set; }
        public short? NumDecimals { get; set; }
        public string? SwipeStarts { get; set; }
        public int? AccountCode { get; set; }
        public short UpdateStatus { get; set; } = 1;
        public int? AccountCodeChange { get; set; }
        public short? AskForTip { get; set; }
        public short? PreAuth { get; set; }
        public short? PrintOnRec { get; set; }
        public double? TipCharge { get; set; }
        public int? PAYIN { get; set; }
        public int TenderSettlement { get; set; } = 0;
        public int ShowCalculatedPayment { get; set; } = 0;
        public double CurBankBalance { get; set; } = 0;
        public int? AccCodePayInOut { get; set; }
        public int? AccCodeOverShort { get; set; }
        public string? PLink { get; set; }
        public short? ForbidOnWeb { get; set; }
        public string? DllName { get; set; }
        public short NoDrawer { get; set; } = 0;
        public short CanRetip { get; set; } = 0;
        public short NoSwipe { get; set; } = 0;
        public short IsEFT { get; set; } = 0;
        public short HasDenoms { get; set; } = 0;
        public byte[]? Picture { get; set; }
        public short AskCashBack { get; set; } = 0;
        public short KeepChange { get; set; } = 0;
        public short DisableExpiry { get; set; } = 0;
        public short CardNumFormat { get; set; } = 0;
        public short AuthSlipWithReceipt { get; set; } = 0;
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public short AuthSlipReprint { get; set; } = 0;
        public short AskCVV { get; set; } = 0;
        public int LCU { get; set; } = 0;
        public int LCURoundUp { get; set; } = 0;
        public short MemGiftOnly { get; set; } = 0;
        public short NotInPaymtList { get; set; } = 0;
        public int SNUM { get; set; } = -1;
        public long ReflectionUpdate { get; set; } = 0;
        public short PromptNote { get; set; } = 0;
        public int? PMReportNum { get; set; }
        public short AllowVoids { get; set; } = 1;
        public short NotInGiftCardList { get; set; } = 0;
        public short NoAuthSlip { get; set; } = 0;
        public short AskSignature { get; set; } = 0;
    }

    public class MethodPayUpdate
    {
        [NotMapped]
        public required int METHODNUM { get; set; }
        public string? DESCRIPT { get; set; }
        public short? ISACTIVE { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public short? CURRENCY { get; set; }
        public short? AUTHREQR { get; set; }
        public double? EXCHANGE { get; set; }
        public short? SecLevel { get; set; }
        public short? NumDecimals { get; set; }
        public string? SwipeStarts { get; set; }
        public int? AccountCode { get; set; }
        public short? UpdateStatus { get; set; }
        public int? AccountCodeChange { get; set; }
        public short? AskForTip { get; set; }
        public short? PreAuth { get; set; }
        public short? PrintOnRec { get; set; }
        public double? TipCharge { get; set; }
        public int? PAYIN { get; set; }
        public int? TenderSettlement { get; set; }
        public int? ShowCalculatedPayment { get; set; }
        public double? CurBankBalance { get; set; }
        public int? AccCodePayInOut { get; set; }
        public int? AccCodeOverShort { get; set; }
        public string? PLink { get; set; }
        public short? ForbidOnWeb { get; set; }
        public string? DllName { get; set; }
        public short? NoDrawer { get; set; }
        public short? CanRetip { get; set; }
        public short? NoSwipe { get; set; }
        public short? IsEFT { get; set; }
        public short? HasDenoms { get; set; }
        public byte[]? Picture { get; set; }
        public short? AskCashBack { get; set; }
        public short? KeepChange { get; set; }
        public short? DisableExpiry { get; set; }
        public short? CardNumFormat { get; set; }
        public short? AuthSlipWithReceipt { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public short? AuthSlipReprint { get; set; }
        public short? AskCVV { get; set; }
        public int? LCU { get; set; }
        public int? LCURoundUp { get; set; }
        public short? MemGiftOnly { get; set; }
        public short? NotInPaymtList { get; set; }
        public int? SNUM { get; set; }
        public long? ReflectionUpdate { get; set; }
        public short? PromptNote { get; set; }
        public int? PMReportNum { get; set; }
        public short? AllowVoids { get; set; }
        public short? NotInGiftCardList { get; set; }
        public short? NoAuthSlip { get; set; }
        public short? AskSignature { get; set; }
    }
}
