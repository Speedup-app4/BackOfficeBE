using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Menu
{
    [Table("MENUORDERPOS")]
    public class MenuOrderPos
    {
        public Guid ClientId { get; set; }

        [Key]
        public int UNIQUEID { get; set; }
        public required int ORDERCAT { get; set; } //* OrderCat ID
        public required int MENUINDEX { get; set; } //* MultiMenuNames ID
        public required int ORDERPOS { get; set; } //* Thứ tự (Sequence)
        public short ISACTIVE { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public int? UpdateStatus { get; set; } = 1;
        public int? SNUM { get; set; } = -1;

        [NotMapped]
        public OrderCat? OrderCatData { get; set; }
    }
}
