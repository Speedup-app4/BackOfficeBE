using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Products
{
    public class ProductCombo
    {
        public Guid ClientId { get; set; }

        [Key]
        public int ProductComboID { get; set; }
        public int ProdLinkNum { get; set; } //* PRODNUM cha
        public int ProdNum { get; set; } //* PRODNUM con
        public short ReqItem { get; set; } = 0;
        public short PriceMode { get; set; } = 11;
        public decimal FixedPrice { get; set; } = 0;
        public short Sequence { get; set; } = 0;
        public short IsActive { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public int? OptionIndex { get; set; } = -1;
        public short? UpdateStatus { get; set; } = 1;
        public int? SNum { get; set; } = -1;
        public string? SuggestDes { get; set; }
    }

    public class ProductComboUpdate
    {
        [NotMapped]
        public required int ProductComboID { get; set; }
        public int? ProdLinkNum { get; set; } //* PRODNUM cha
        public int? ProdNum { get; set; } //* PRODNUM con
        public short? ReqItem { get; set; }
        public short? PriceMode { get; set; }
        public decimal? FixedPrice { get; set; }
        public short? Sequence { get; set; }
        public short? IsActive { get; set; }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public int? OptionIndex { get; set; }
        public short? UpdateStatus { get; set; }
        public int? SNum { get; set; }
        public string? SuggestDes { get; set; }
    }
}
