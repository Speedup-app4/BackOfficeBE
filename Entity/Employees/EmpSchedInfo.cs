using System;
using System.ComponentModel.DataAnnotations;

namespace BackOffice.Entity.Employees
{
    public class EmpSchedInfo
    {
        public Guid ClientId { get; set; }

        [Key]
        public int EmpNum { get; set; }
        public string? Schedule { get; set; }
        public int? PreferredHours { get; set; }
        public int? ISActive { get; set; }
        public int? Skill { get; set; }
        public int? UpdateStatus { get; set; } = 1;
        public int? SNUM { get; set; } = -1;
    }
}
