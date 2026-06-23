using System;
using System.ComponentModel.DataAnnotations;

namespace BackOffice.Entity.Payment
{
    public class PayMethReportCat
    {
        public Guid ClientId { get; set; }

        [Key]
        public required int PMReportNum { get; set; }
        public string? Descript { get; set; }
        public short? IsActive { get; set; } = 1;
        public short? UpdateStatus { get; set; } = 1;
        public int? SNum { get; set; } = -1;
    }
}
