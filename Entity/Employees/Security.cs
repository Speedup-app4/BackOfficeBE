using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Employees
{
    public class Security
    {
        public Guid ClientId { get; set; }

        [Key]
        public int SEC_NUM { get; set; }
        public string? DESCRIPT { get; set; }
        public short? SECLEVEL { get; set; }
        public string? LOG_ACT { get; set; }
        public short? ISACTIVE { get; set; }
        public short AskForReason { get; set; } = 0;
        public int UpdateStatus { get; set; } = 1;
        public int SNUM { get; set; } = -1;
        public long ReflectionUpdate { get; set; } = 0;
    }

    public class SecurityUpdate
    {
        [NotMapped]
        public required int SEC_NUM { get; set; }
        public string? DESCRIPT { get; set; }
        public short? SECLEVEL { get; set; }
        public string? LOG_ACT { get; set; }
        public short? ISACTIVE { get; set; }
        public short? AskForReason { get; set; }
        public int? UpdateStatus { get; set; }
        public int? SNUM { get; set; }
        public long? ReflectionUpdate { get; set; }
    }
}
