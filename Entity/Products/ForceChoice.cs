using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Products
{
    [Table("ForcedChoices")]
    public class ForceChoice
    {
        public Guid ClientId { get; set; }

        [Key]
        public int UNIQUEID { get; set; }
        public required int OPTIONINDEX { get; set; } //* Question ID
        public required int CHOICE { get; set; } //* PRODNUM
        public required short PriceMode { get; set; } = 0;
        public required decimal FixedPrice { get; set; } = 0;
        public required short Sequence { get; set; }
        public required short IsActive { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public string? PLink { get; set; }
        public int? UpdateStatus { get; set; } = 1;
        public int? SNUM { get; set; } = -1;
    }
}
