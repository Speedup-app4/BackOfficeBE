using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackOffice.Entity.Products
{
    public class Product
    {
        public Guid ClientId { get; set; }

        [Key]
        public int PRODNUM { get; set; }
        public required int REPORTNO { get; set; } //* REPORTNO ID
        public required string DESCRIPT { get; set; }
        public required decimal PRICEA { get; set; }
        public required decimal PRICEB { get; set; }
        public required decimal PRICEC { get; set; }
        public required decimal PRICED { get; set; }
        public required decimal PRICEE { get; set; }
        public required decimal PRICEF { get; set; }
        public required decimal PRICEG { get; set; }
        public required decimal PRICEH { get; set; }
        public required decimal PRICEI { get; set; }
        public required decimal PRICEJ { get; set; }
        public short TAX1 { get; set; } = 0;
        public short TAX2 { get; set; } = 0;
        public short TAX3 { get; set; } = 0;
        public short TAX4 { get; set; } = 0;
        public short TAX5 { get; set; } = 0;
        public required short PRODTYPE { get; set; }
        public int? QUESTION1 { get; set; }
        public int? QUESTION2 { get; set; }
        public int? QUESTION3 { get; set; }
        public int? QUESTION4 { get; set; }
        public int? QUESTION5 { get; set; }
        public required int COUNTDOWN { get; set; }
        public required int FORCOLOR { get; set; }
        public required int BACKCOLOR { get; set; }
        public required short ManualPrice { get; set; }
        public short USEITEMCAT { get; set; } = 1;
        public short ISACTIVE { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public DateTime? ENTDATE { get; set; }
        public required int PRINTLOC { get; set; }
        public short? SECLEVEL { get; set; }
        public short? TEXEMPT { get; set; }
        public string? MENUSCHED { get; set; }
        public string? BUTTON1 { get; set; }
        public string? BUTTON2 { get; set; }
        public string? BUTTON3 { get; set; }
        public int? MODIFYSCR1 { get; set; }
        public int? MODIFYSCR2 { get; set; }
        public int? MODIFYSCR3 { get; set; }
        public int? MODIFYSCR4 { get; set; }
        public int? MODIFYSCR5 { get; set; }
        public string? PRINTDES { get; set; }
        public string? REFCODE { get; set; }
        public short? ISWEIGHED { get; set; }
        public double? ServeTime { get; set; }
        public short? SPECIAL { get; set; }
        public decimal? PRICEMODE { get; set; }
        public decimal? ManualRecipeCost { get; set; }
        public decimal? RecipeCost { get; set; }
        public int? AccountCode { get; set; }
        public int? MemPoints { get; set; }
        public short? PrintZero { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public double? FeatureCode { get; set; }
        public int? COSTACCOUNTCODE { get; set; }
        public int? PRINTCONSOLIDATE { get; set; }
        public int? INVACCOUNTCODE { get; set; }
        public DateTime? RANGESTART { get; set; }
        public DateTime? RANGEEND { get; set; }
        public int? COURSETYPE { get; set; }
        public int? PRINTPRIORITY { get; set; }
        public double? TearWeight { get; set; }
        public string? PLink { get; set; }
        public int? WebUseWebModifyScr { get; set; }
        public int? WebModifyScr1 { get; set; }
        public int? WebModifyScr2 { get; set; }
        public int? WebModifyScr3 { get; set; }
        public int? WebModifyScr4 { get; set; }
        public int? WebModifyScr5 { get; set; }
        public int? WebUseWebQuestion { get; set; }
        public int? WebQuestion1 { get; set; }
        public int? WebQuestion2 { get; set; }
        public int? WebQuestion3 { get; set; }
        public int? WebQuestion4 { get; set; }
        public int? WebQuestion5 { get; set; }
        public int? WebQuestion6 { get; set; }
        public int? WebQuestion7 { get; set; }
        public int? WebQuestion8 { get; set; }
        public int? SizeUp { get; set; }
        public int? SizeDown { get; set; }
        public int? LabelCapacity { get; set; }
        public int? PrepLocation { get; set; }
        public double? Covers { get; set; }
        public int? ReportProdNum { get; set; }
        public int? Shift1 { get; set; }
        public int? Shift2 { get; set; }
        public int? Shift3 { get; set; }
        public int? Shift4 { get; set; }
        public int? Shift5 { get; set; }
        public int? Shift6 { get; set; }
        public int? Shift7 { get; set; }
        public int? Shift8 { get; set; }
        public int? Shift9 { get; set; }
        public int? Shift10 { get; set; }
        public string? FontName { get; set; }
        public short? FontSize { get; set; }
        public int? FontStyle { get; set; }
        public int? ConfigNum { get; set; }
        public int? KioskModifyScr1 { get; set; }
        public int? KioskModifyScr2 { get; set; }
        public int? KioskModifyScr3 { get; set; }
        public int? KioskModifyScr4 { get; set; }
        public int? KioskModifyScr5 { get; set; }
        public int? KioskQuestion1 { get; set; }
        public int? KioskQuestion2 { get; set; }
        public int? KioskQuestion3 { get; set; }
        public int? KioskQuestion4 { get; set; }
        public int? KioskQuestion5 { get; set; }
        public int? KioskQuestion6 { get; set; }
        public int? KioskQuestion7 { get; set; }
        public int? KioskQuestion8 { get; set; }
        public string? UnitDes { get; set; }
        public int? EmpPoints { get; set; }
        public int SNum { get; set; } = -1;
        public short? GratExempt { get; set; }
        public short? PrepTemp { get; set; }
        public string? PDllName { get; set; }
        public int? CanCombine { get; set; }
        public double? Tax1Quan { get; set; }
        public double? Tax2Quan { get; set; }
        public double? Tax3Quan { get; set; }
        public double? Tax4Quan { get; set; }
        public double? Tax5Quan { get; set; }
        public string? PrintDes2 { get; set; }
        public short? MemberProduct { get; set; }
        public long? ReflectionUpdate { get; set; }

        [NotMapped]
        [JsonPropertyName("productComboes")] //* Khổ quá sai chính tả phải map lại
        public List<ProductCombo>? ProductCombos { get; set; }
    }

    public class ProductUpdate
    {
        [NotMapped]
        public required int PRODNUM { get; set; }
        public int? REPORTNO { get; set; } //* REPORTNO ID
        public string? DESCRIPT { get; set; }
        public decimal? PRICEA { get; set; }
        public decimal? PRICEB { get; set; }
        public decimal? PRICEC { get; set; }
        public decimal? PRICED { get; set; }
        public decimal? PRICEE { get; set; }
        public decimal? PRICEF { get; set; }
        public decimal? PRICEG { get; set; }
        public decimal? PRICEH { get; set; }
        public decimal? PRICEI { get; set; }
        public decimal? PRICEJ { get; set; }
        public short? TAX1 { get; set; }
        public short? TAX2 { get; set; }
        public short? TAX3 { get; set; }
        public short? TAX4 { get; set; }
        public short? TAX5 { get; set; }
        public short? PRODTYPE { get; set; }
        public int? QUESTION1 { get; set; }
        public int? QUESTION2 { get; set; }
        public int? QUESTION3 { get; set; }
        public int? QUESTION4 { get; set; }
        public int? QUESTION5 { get; set; }
        public int? COUNTDOWN { get; set; }
        public int? FORCOLOR { get; set; }
        public int? BACKCOLOR { get; set; }
        public short? ManualPrice { get; set; }
        public short? USEITEMCAT { get; set; }
        public short? ISACTIVE { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public DateTime? ENTDATE { get; set; }
        public int? PRINTLOC { get; set; }
        public short? SECLEVEL { get; set; }
        public short? TEXEMPT { get; set; }
        public string? MENUSCHED { get; set; }
        public string? BUTTON1 { get; set; }
        public string? BUTTON2 { get; set; }
        public string? BUTTON3 { get; set; }
        public int? MODIFYSCR1 { get; set; }
        public int? MODIFYSCR2 { get; set; }
        public int? MODIFYSCR3 { get; set; }
        public int? MODIFYSCR4 { get; set; }
        public int? MODIFYSCR5 { get; set; }
        public string? PRINTDES { get; set; }
        public string? REFCODE { get; set; }
        public short? ISWEIGHED { get; set; }
        public double? ServeTime { get; set; }
        public short? SPECIAL { get; set; }
        public decimal? PRICEMODE { get; set; }
        public decimal? ManualRecipeCost { get; set; }
        public decimal? RecipeCost { get; set; }
        public int? AccountCode { get; set; }
        public int? MemPoints { get; set; }
        public short? PrintZero { get; set; }
        public short? UpdateStatus { get; set; }
        public double? FeatureCode { get; set; }
        public int? COSTACCOUNTCODE { get; set; }
        public int? PRINTCONSOLIDATE { get; set; }
        public int? INVACCOUNTCODE { get; set; }
        public DateTime? RANGESTART { get; set; }
        public DateTime? RANGEEND { get; set; }
        public int? COURSETYPE { get; set; }
        public int? PRINTPRIORITY { get; set; }
        public double? TearWeight { get; set; }
        public string? PLink { get; set; }
        public int? WebUseWebModifyScr { get; set; }
        public int? WebModifyScr1 { get; set; }
        public int? WebModifyScr2 { get; set; }
        public int? WebModifyScr3 { get; set; }
        public int? WebModifyScr4 { get; set; }
        public int? WebModifyScr5 { get; set; }
        public int? WebUseWebQuestion { get; set; }
        public int? WebQuestion1 { get; set; }
        public int? WebQuestion2 { get; set; }
        public int? WebQuestion3 { get; set; }
        public int? WebQuestion4 { get; set; }
        public int? WebQuestion5 { get; set; }
        public int? WebQuestion6 { get; set; }
        public int? WebQuestion7 { get; set; }
        public int? WebQuestion8 { get; set; }
        public int? SizeUp { get; set; }
        public int? SizeDown { get; set; }
        public int? LabelCapacity { get; set; }
        public int? PrepLocation { get; set; }
        public double? Covers { get; set; }
        public int? ReportProdNum { get; set; }
        public int? Shift1 { get; set; }
        public int? Shift2 { get; set; }
        public int? Shift3 { get; set; }
        public int? Shift4 { get; set; }
        public int? Shift5 { get; set; }
        public int? Shift6 { get; set; }
        public int? Shift7 { get; set; }
        public int? Shift8 { get; set; }
        public int? Shift9 { get; set; }
        public int? Shift10 { get; set; }
        public string? FontName { get; set; }
        public short? FontSize { get; set; }
        public int? FontStyle { get; set; }
        public int? ConfigNum { get; set; }
        public int? KioskModifyScr1 { get; set; }
        public int? KioskModifyScr2 { get; set; }
        public int? KioskModifyScr3 { get; set; }
        public int? KioskModifyScr4 { get; set; }
        public int? KioskModifyScr5 { get; set; }
        public int? KioskQuestion1 { get; set; }
        public int? KioskQuestion2 { get; set; }
        public int? KioskQuestion3 { get; set; }
        public int? KioskQuestion4 { get; set; }
        public int? KioskQuestion5 { get; set; }
        public int? KioskQuestion6 { get; set; }
        public int? KioskQuestion7 { get; set; }
        public int? KioskQuestion8 { get; set; }
        public string? UnitDes { get; set; }
        public int? EmpPoints { get; set; }
        public int? SNum { get; set; }
        public short? GratExempt { get; set; }
        public short? PrepTemp { get; set; }
        public string? PDllName { get; set; }
        public int? CanCombine { get; set; }
        public double? Tax1Quan { get; set; }
        public double? Tax2Quan { get; set; }
        public double? Tax3Quan { get; set; }
        public double? Tax4Quan { get; set; }
        public double? Tax5Quan { get; set; }
        public string? PrintDes2 { get; set; }
        public short? MemberProduct { get; set; }
        public long? ReflectionUpdate { get; set; }

        [NotMapped]
        [JsonPropertyName("productComboes")]
        public List<ProductCombo>? ProductCombos { get; set; }
    }
}
