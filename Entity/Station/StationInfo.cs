using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Station
{
    [Table("StationInfo")]
    public class StationInfo
    {
        public Guid ClientId { get; set; }

        [Key]
        public int StatNum { get; set; }
        public required string Descript { get; set; }
        public required int STATMULTIMENU { get; set; } //* Menu ID
        public required short AutoLogout { get; set; }
        public required int SALETYPEINDEX { get; set; } //* Default SaleType ID
        public required int ForcePrice { get; set; }
        public required int QuickOrderTable { get; set; }
        public required int REVCENTER { get; set; } //* RevCenter ID
        public required short ISACTIVE { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public int? Port0 { get; set; }
        public int? Port1 { get; set; }
        public int? Port2 { get; set; }
        public int? Port3 { get; set; }
        public int? Port4 { get; set; }
        public int? Port5 { get; set; }
        public int? Port6 { get; set; }
        public int? Port7 { get; set; }
        public int? Port8 { get; set; }
        public int? Port9 { get; set; }
        public int? Drawerport1 { get; set; }
        public int? Drawerport2 { get; set; }
        public int? Drawerport3 { get; set; }
        public int? Receiptport { get; set; }
        public int? Chargeport { get; set; }
        public int? ReportPort { get; set; }
        public short? DisplayPort { get; set; }
        public short? ForceRec { get; set; }
        public short? SwipeAttach { get; set; }
        public string? FloorFile { get; set; }
        public double? FloorZoom { get; set; }
        public short? PRINTSALETYPE { get; set; }
        public string? SmallFontName { get; set; }
        public short? SmallFontSize { get; set; }
        public string? MedFontName { get; set; }
        public short? MedFontSize { get; set; }
        public string? LargeFontName { get; set; }
        public short? LargeFontSize { get; set; }
        public short? PlayAnimation { get; set; }
        public short? ScreenDelay { get; set; }
        public int? WareHouseNum { get; set; }
        public short? DisableSaveCheck { get; set; }
        public short? DisableZoomOut { get; set; }
        public short? DisableMisc { get; set; }
        public string? Merchant { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public short? TaxinFeature { get; set; }
        public string? RECHEAD { get; set; }
        public string? RECFOOTER { get; set; }
        public int? CUSTOMREC { get; set; } = 0;
        public DateTime? LASTZTIME { get; set; }
        public int? LASTZHOWPAID { get; set; }
        public short? QOrderMulti { get; set; } = 0;
        public short? ShowSummary { get; set; } = 0;
        public short? NoTransView { get; set; } = 0;
        public byte[]? Data { get; set; }
        public short? NoAutoGrat { get; set; } = 0;
        public short? NoPreAuth { get; set; } = 0;
        public string? RemMsg { get; set; }
        public string? XMLPolicies { get; set; }
        public string? TechInfo { get; set; }
        public int? FinTmplNum { get; set; }
        public int? QstnTmplNum { get; set; }
        public int? CustDispTmplNum { get; set; }
        public int? KioskEmpNum { get; set; }
        public int? ScrnSavrTmplNum { get; set; }
        public int? KeybrdTmplNum { get; set; }
        public string? ReceiptLayout { get; set; }
        public int? OrdTmplNum { get; set; }
        public int? ThemeTmplNum { get; set; }
        public string? RECFOOTER2 { get; set; }
        public string? TCDllName { get; set; }
        public short? MagReaderType { get; set; } = 0;
        public int? SNUM { get; set; } = -1;
        public short? UseChkRecall { get; set; } = 0;
        public int? StartKioskNum { get; set; }

        [NotMapped]
        public int? SyncId { get; set; }
    }

    public class StationInfoUpdate
    {
        [NotMapped]
        public int StatNum { get; set; }
        public string? Descript { get; set; }
        public int? STATMULTIMENU { get; set; } //* Menu ID
        public short? AutoLogout { get; set; }
        public int? SALETYPEINDEX { get; set; } //* Default SaleType ID
        public int? ForcePrice { get; set; }
        public int? QuickOrderTable { get; set; }
        public int? REVCENTER { get; set; } //* RevCenter ID
        public short? ISACTIVE { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public int? Port0 { get; set; }
        public int? Port1 { get; set; }
        public int? Port2 { get; set; }
        public int? Port3 { get; set; }
        public int? Port4 { get; set; }
        public int? Port5 { get; set; }
        public int? Port6 { get; set; }
        public int? Port7 { get; set; }
        public int? Port8 { get; set; }
        public int? Port9 { get; set; }
        public int? Drawerport1 { get; set; }
        public int? Drawerport2 { get; set; }
        public int? Drawerport3 { get; set; }
        public int? Receiptport { get; set; }
        public int? Chargeport { get; set; }
        public int? ReportPort { get; set; }
        public short? DisplayPort { get; set; }
        public short? ForceRec { get; set; }
        public short? SwipeAttach { get; set; }
        public string? FloorFile { get; set; }
        public double? FloorZoom { get; set; }
        public short? PRINTSALETYPE { get; set; }
        public string? SmallFontName { get; set; }
        public short? SmallFontSize { get; set; }
        public string? MedFontName { get; set; }
        public short? MedFontSize { get; set; }
        public string? LargeFontName { get; set; }
        public short? LargeFontSize { get; set; }
        public short? PlayAnimation { get; set; }
        public short? ScreenDelay { get; set; }
        public int? WareHouseNum { get; set; }
        public short? DisableSaveCheck { get; set; }
        public short? DisableZoomOut { get; set; }
        public short? DisableMisc { get; set; }
        public string? Merchant { get; set; }
        public short? UpdateStatus { get; set; }
        public short? TaxinFeature { get; set; }
        public string? RECHEAD { get; set; }
        public string? RECFOOTER { get; set; }
        public int? CUSTOMREC { get; set; }
        public DateTime? LASTZTIME { get; set; }
        public int? LASTZHOWPAID { get; set; }
        public short? QOrderMulti { get; set; }
        public short? ShowSummary { get; set; }
        public short? NoTransView { get; set; }
        public byte[]? Data { get; set; }
        public short? NoAutoGrat { get; set; }
        public short? NoPreAuth { get; set; }
        public string? RemMsg { get; set; }
        public string? XMLPolicies { get; set; }
        public string? TechInfo { get; set; }
        public int? FinTmplNum { get; set; }
        public int? QstnTmplNum { get; set; }
        public int? CustDispTmplNum { get; set; }
        public int? KioskEmpNum { get; set; }
        public int? ScrnSavrTmplNum { get; set; }
        public int? KeybrdTmplNum { get; set; }
        public string? ReceiptLayout { get; set; }
        public int? OrdTmplNum { get; set; }
        public int? ThemeTmplNum { get; set; }
        public string? RECFOOTER2 { get; set; }
        public string? TCDllName { get; set; }
        public short? MagReaderType { get; set; }
        public int? SNUM { get; set; }
        public short? UseChkRecall { get; set; }
        public int? StartKioskNum { get; set; }
    }
}
