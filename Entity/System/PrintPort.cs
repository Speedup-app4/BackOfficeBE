using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.System
{
    [Table("PrintPorts")]
    public class PrintPort
    {
        public Guid ClientId { get; set; }

        [Key]
        public required int PortNum { get; set; }
        public required string Descr { get; set; }
        public short? IsActive { get; set; } = 1;
        public short? UpdateStatus { get; set; } = 1;
        public int? SNum { get; set; } = -1;
    }
}
