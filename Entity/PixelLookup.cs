using System.ComponentModel.DataAnnotations;

namespace BackOffice.Entity
{
    public class PixelLookup
    {
        public Guid ClientId { get; set; }

        [Key]
        public int UniqueId { get; set; }
        public required string LookupDescript { get; set; }
        public int? LookUpType { get; set; }
        public short? IsActive { get; set; } = 1;
        public short? UpdateStatus { get; set; } = 1;
        public int? SNum { get; set; } = -1;
    }
}
