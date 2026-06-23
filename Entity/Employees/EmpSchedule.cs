using System;
using System.ComponentModel.DataAnnotations;

namespace BackOffice.Entity.Employees
{
    public class EmpSchedule
    {
        public Guid ClientId { get; set; }

        [Key]
        public int ShiftIndex { get; set; }
        public required int EmpNum { get; set; }
        public required DateTime TimeStart { get; set; }
        public required DateTime TimeEnd { get; set; }
        public required int ShiftType { get; set; }
        public int? IsActive { get; set; }
        public required int JobPos { get; set; }
        public int? AllowBreaks { get; set; }
        public double? PayRate { get; set; }
        public int? Status { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public int? SNUM { get; set; } = -1;
    }
}
