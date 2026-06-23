using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Products
{
    [Table("TYPEOFPROD")]
    public class TypeOfProd
    {
        public Guid ClientId { get; set; }

        [Key]
        public int PRODTYPE { get; set; }
        public required string DESCRIPT { get; set; }
    }

    public class TypeOfProdUpdate
    {
        [Key]
        public required int PRODTYPE { get; set; }
        public string? DESCRIPT { get; set; }
    }
}
