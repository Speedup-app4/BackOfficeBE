using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Employees
{
    [Table("ShiftRules")]
    public class ShiftRule
    {
        public Guid ClientId { get; set; }

        [Key]
        public int ShiftRuleId { get; set; }
        public required string Descript { get; set; }
        public short? EnableB { get; set; } = 0;
        public short? PaidB { get; set; } = 0;
        public short? MinReqDurationB { get; set; }
        public short? MaxDurationB { get; set; }
        public short? ReqFrequencyB { get; set; }
        public short? ReminderTimeB { get; set; }
        public short? ManOverrideEarlyB { get; set; } = 0;
        public short? WaiveB { get; set; }
        public short? NoOfWaivesB { get; set; }
        public short? SplitShiftTimeB { get; set; }
        public short? EnableM { get; set; } = 0;
        public short? PaidM { get; set; } = 0;
        public short? MinReqDurationM { get; set; }
        public short? MaxDurationM { get; set; }
        public short? ReqFrequencyM { get; set; }
        public short? ReminderTimeM { get; set; }
        public short? ManOverrideEarlyM { get; set; } = 0;
        public short? WaiveM { get; set; }
        public short? NoOfWaivesM { get; set; }
        public short? SplitShiftTimeM { get; set; }
        public short? ShowMessageOnClockIn { get; set; } = 0;
        public string? ClockInMessage { get; set; }
        public short? HasPunchMan { get; set; } = 0;
        public short? MinsBefore { get; set; }
        public short? MinsAfter { get; set; }
        public int? PunchRound { get; set; }
        public short? UpdateStatus { get; set; } = 1;
        public int? SNum { get; set; } = -1;
        public short? IsActive { get; set; } = 1;
        public double? OvertimeWarnHrs { get; set; }
        public short? SendAlertEmp { get; set; }
        public short? SendAlertMod { get; set; }
        public int? ExceedMaxDurB { get; set; } = 0;
        public int? ExceedMaxDurM { get; set; } = 0;
    }
}
