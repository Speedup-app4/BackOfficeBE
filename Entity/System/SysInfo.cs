using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.System
{
    [Table("Sysinfo")]
    public class SysInfo
    {
        public Guid ClientId { get; set; }

        [Key]
        public required string COMPANY { get; set; }
        public required string TAXDES1 { get; set; }
        public required string TAXDES2 { get; set; }
        public required string TAXDES3 { get; set; }
        public required string TAXDES4 { get; set; }
        public required string TAXDES5 { get; set; }
        public required short TAXRATE1 { get; set; }
        public required short TAXRATE2 { get; set; }
        public required short TAXRATE3 { get; set; }
        public required short TAXRATE4 { get; set; }
        public required short TAXRATE5 { get; set; }
        public required short UseVAT { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public double? TEXEMPT1 { get; set; }
        public double? TEXEMPT2 { get; set; }
        public double? TEXEMPT3 { get; set; }
        public double? TEXEMPT4 { get; set; }
        public double? TEXEMPT5 { get; set; }
        public int? STORENUM { get; set; }
        public short? NUMSTATIONS { get; set; }
        public short? OPENALLTIME { get; set; }
        public string? RECHEAD { get; set; }
        public string? RECFOOTER { get; set; }
        public short? LOCKOUTSTATS { get; set; }
        public short? LOCKOUTTABS { get; set; }
        public short? HASAUTHORIZE { get; set; }
        public string? BillBoardMes { get; set; }
        public short? USEWeather { get; set; }
        public string? CashOutReport { get; set; }
        public string? EndofDayReport { get; set; }
        public short? DualPlyPaper { get; set; }
        public short? HASSTOCKMAN { get; set; }
        public short? SortReceipt { get; set; }
        public short? AutoShutDown { get; set; }
        public DateTime? AutoShutTime { get; set; }

        // Print Channels
        public string? PrintChannel1 { get; set; }
        public string? PrintChannel2 { get; set; }
        public string? PrintChannel3 { get; set; }
        public string? PrintChannel4 { get; set; }
        public string? PrintChannel5 { get; set; }
        public string? PrintChannel6 { get; set; }
        public string? PrintChannel7 { get; set; }
        public string? PrintChannel8 { get; set; }
        public string? PrintChannel9 { get; set; }

        public short? AskWeather { get; set; }
        public short? AskTemperature { get; set; }
        public short? ExportSales { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public int? Reportlink { get; set; } = -5454151;
        public string? TelephoneMask { get; set; }
        public int? LASTSQL { get; set; }
        public int? HASRESERVATION { get; set; } = 0;

        // Preset Payments
        public double? PRESETPAY1 { get; set; }
        public double? PRESETPAY2 { get; set; }
        public double? PRESETPAY3 { get; set; }
        public double? PRESETPAY4 { get; set; }
        public double? PRESETPAY5 { get; set; }
        public double? PRESETPAY6 { get; set; }
        public int? APPLYPRESET { get; set; }

        public string? TILLREPORT { get; set; }
        public int? ALLOWPAYOUT { get; set; }
        public int? TENDERBALANCE { get; set; }
        public int? MEMBERPOSTSETUP { get; set; }
        public double? FOMinHours { get; set; }
        public double? FOMaxHours { get; set; }
        public short? FOMinBefore { get; set; }
        public int? DefSplitProd { get; set; }
        public string? CoursePrefixes { get; set; }

        // Gratuity & Coupon
        public double? AutoGratPercent { get; set; } = 0;
        public short? AutoGratPersons { get; set; } = 0;
        public short? AutoGratAmount { get; set; } = 0;
        public short? EnforceGratAmount { get; set; } = 0;
        public int? DefSeatProd { get; set; }
        public short? NoAutoMemberCoupon { get; set; }
        public short? UsePLink { get; set; }

        // Collaboration
        public string? ColaborationURL { get; set; }
        public short? ColaborationAutoLogon { get; set; } = 0;
        public short? ColaborationAutoAccess { get; set; } = 0;
        public DateTime? HoldStockDepl { get; set; }
        public DateTime? LastRAPTest { get; set; }

        // SMTP / Email Settings
        public string? SMTPServer { get; set; }
        public string? SMTPUser { get; set; }
        public string? SMTPPassword { get; set; }
        public short? SMTPOnSchedule { get; set; } = 0;
        public short? SMTPOnWebToGo { get; set; } = 0;
        public string? SMTPScheduleSubject { get; set; }
        public string? SMTPScheduleBody { get; set; }
        public string? SMTPSender { get; set; }
        public int? ShiftRuleId { get; set; } = 0;
        public short? SMTPOnOrderConfirm { get; set; } = 0;
        public short? SMTPConfirmOnInternet { get; set; } = 0;
        public string? SMTPConfirmOnSaleTypes { get; set; }
        public short? SMTPConfirmByClose { get; set; } = 0;
        public string? SMTPConfirmSubject { get; set; }
        public string? SMTPConfirmBody { get; set; }

        // Company Profile
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Postal { get; set; }
        public string? Prov { get; set; }
        public string? Phone { get; set; }
        public string? Owner { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? RptComment { get; set; }
        public string? XMLPolicies { get; set; }
        public string? Fax { get; set; }
        public string? TechInfo { get; set; }

        // Operational Settings
        public double? timezoneshift { get; set; } = 0;
        public int? LCUCash { get; set; }
        public int? LCUCharge { get; set; }
        public double? RoundMOD { get; set; }
        public int? RepLastSQL { get; set; } = 0;
        public int? IsDBUseKeyServer { get; set; } = 0;
        public int? HOManID { get; set; } = 0;

        public double? Royalty1 { get; set; } = 0;
        public double? Royalty2 { get; set; } = 0;
        public double? Royalty3 { get; set; } = 0;
        public double? Royalty4 { get; set; } = 0;
        public double? Royalty5 { get; set; } = 0;

        public int? ScrnSavrTmplNum { get; set; }
        public int? CustDispTmplNum { get; set; }
        public string? ReceiptLayout { get; set; }

        public short? ApplyTaxGrat1 { get; set; } = 0;
        public short? ApplyTaxGrat2 { get; set; } = 0;
        public short? ApplyTaxGrat3 { get; set; } = 0;
        public short? ApplyTaxGrat4 { get; set; } = 0;
        public short? ApplyTaxGrat5 { get; set; } = 0;

        public short? GratTaxBefore { get; set; } = 0;
        public short? GratNoCoupon { get; set; } = 1;
        public int? ThemeTmplNum { get; set; }
        public string? RECFOOTER2 { get; set; }
        public short? SMTPOnReportViewer { get; set; } = 0;
        public string? SMTPDisplayName { get; set; }
        public int? SMTPPort { get; set; } = 0;
        public short? SMTPSSL { get; set; } = 0;
        public short? SMTPOnAlertManager { get; set; } = 0;

        public short? MemPointsSys { get; set; } = 0;
        public int? MemNumPoints { get; set; } = 0;
        public double? MemDollarPoints { get; set; } = 0;
        public int? DefCpnGrpId { get; set; } = 0;

        // System / Auth
        public string? TCDllName { get; set; }
        public string? ClockOutReport { get; set; }
        public short? PWDExpireDays { get; set; }
        public short? PWDMinChars { get; set; }
        public short? PWDRetry { get; set; }
        public short? PWDHistUse { get; set; }
        public short? PWDAlphaNum { get; set; }
        public short? FileBasedAuths { get; set; }
        public short? EnableEmpPWD { get; set; }
        public short? MemRoundPoints { get; set; }
        public int? DefOnFinProd { get; set; } = 0;

        public short? TaxData1 { get; set; }
        public short? TaxData2 { get; set; }
        public short? TaxData3 { get; set; }
        public short? TaxData4 { get; set; }
        public short? TaxData5 { get; set; }
        public short? PrintXCpnReceipt { get; set; } = 1;
        public int? HoTestMode { get; set; } = 0;
        public int? LASTUPDATE { get; set; }
        public int? SNUM { get; set; } = -1;
        public int? STOREUPDATE { get; set; }
        public string? TPRDllName { get; set; }
        public int? EOIEmpNum { get; set; }
        public int? AutoMenu { get; set; }
        public int? AutoKiosk { get; set; }
    }
}
