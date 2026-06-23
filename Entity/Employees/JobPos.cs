using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Employees
{
    [Table("Jobpos")]
    public class JobPos
    {
        public Guid ClientId { get; set; }

        [Key]
        public int JOBPOS { get; set; }
        public string? DESCRIPT { get; set; }
        public short? SECLEVEL { get; set; }
        public short? DISCOUNT { get; set; }
        public short ISACTIVE { get; set; } = 1;
        public double? DEFAULTPAY { get; set; }
        public int UpdateStatus { get; set; } = 1;
        public int? DeptNum { get; set; }
        public short ForceTips { get; set; } = 0;
        public short FloatType { get; set; } = 0;
        public double AutoFloat { get; set; } = 0;
        public string? CashOutRept { get; set; }
        public string? PLink { get; set; }
        public short NoMessages { get; set; } = 0;
        public double MinPayRate { get; set; } = 0;
        public double MaxPayRate { get; set; } = 0;
        public int ShiftRuleId { get; set; } = 0;
        public double MinAmount { get; set; } = 0;
        public int EmpCount { get; set; } = 0;
        public int AuthByBio { get; set; } = 0;
        public int SNum { get; set; } = -1;
        public long ReflectionUpdate { get; set; } = 0;
    }

    public class JobPosUpdate
    {
        [NotMapped]
        public required int JOBPOS { get; set; }
        public string? DESCRIPT { get; set; }
        public short? SECLEVEL { get; set; }
        public short? DISCOUNT { get; set; }
        public short? ISACTIVE { get; set; }
        public double? DEFAULTPAY { get; set; }
        public int? UpdateStatus { get; set; }
        public int? DeptNum { get; set; }
        public short? ForceTips { get; set; }
        public short? FloatType { get; set; }
        public double? AutoFloat { get; set; }
        public string? CashOutRept { get; set; }
        public string? PLink { get; set; }
        public short? NoMessages { get; set; }
        public double? MinPayRate { get; set; }
        public double? MaxPayRate { get; set; }
        public int? ShiftRuleId { get; set; }
        public double? MinAmount { get; set; }
        public int? EmpCount { get; set; }
        public int? AuthByBio { get; set; }
        public int? SNum { get; set; }
        public long? ReflectionUpdate { get; set; }
    }
}
