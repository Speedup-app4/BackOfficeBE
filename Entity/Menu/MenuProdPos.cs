using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackOffice.Entity.Products;

namespace BackOffice.Entity.Menu
{
    public class MenuProdPos
    {
        public Guid ClientId { get; set; }

        [Key]
        public int UniqueID { get; set; }
        public required int ORDERCAT { get; set; } //* OrderCat ID
        public required int PRODNUM { get; set; } //* Product ID
        public required int PRODPOS { get; set; } //* Thứ tự (Sequence)
        public short ISACTIVE { get; set; } = 1;

        // ---------------------------------------------------------
        // ---------------------------------------------------------
        public int? SNum { get; set; } = -1;
        public int? UpdateStatus { get; set; } = 1;

        [NotMapped]
        public Product? ProductData { get; set; }
    }
}
