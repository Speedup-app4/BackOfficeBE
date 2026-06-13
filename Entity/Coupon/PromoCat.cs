using System.ComponentModel.DataAnnotations;

namespace BackOffice.Entity.Coupon
{
    public class PromoCat
    {
        public Guid ClientId { get; set; }

        [Key]
        public int PromoCatID { get; set; }
        public string? Descript { get; set; }
        public short? IsActive { get; set; } = 1;
        public int? UPDATESTATUS { get; set; } = 1;
        public int? SNUM { get; set; } = -1;
    }
}
