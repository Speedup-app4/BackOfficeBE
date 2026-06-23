using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackOffice.Entity.Employees
{
    [Table("employee")]
    public class Employee
    {
        public Guid ClientId { get; set; }

        [Key]
        public int EMPNUM { get; set; }
        public required string EMPNAME { get; set; }
        public DateTime? DateEntered { get; set; }
        public string? ADRESS1 { get; set; }
        public string? ADRESS2 { get; set; }
        public string? CITY { get; set; }
        public string? PROV { get; set; }
        public string? POSTAL { get; set; }
        public string? HOMETELE { get; set; }
        public string? BUSTELE { get; set; }
        public DateTime? STARTWORK { get; set; }
        public DateTime? ENDWORK { get; set; }
        public short ISACTIVE { get; set; } = 1;
        public string? POSNAME { get; set; }
        public int? EMPPOSITION { get; set; }
        public short? SECLEVEL { get; set; }
        public short? LOGINCODE { get; set; }
        public short? PASSKEY { get; set; }
        public required string SWIPE { get; set; }
        public short? OPENDRAWER { get; set; }
        public short? INTRFACE { get; set; }
        public short? LASTPOSX { get; set; }
        public short? LASTPOSY { get; set; }
        public short? LASTACTION { get; set; }
        public short? ISCLOCKEDIN { get; set; }
        public decimal? HOURLYWAGE { get; set; }
        public decimal? YEARLYWAGE { get; set; }
        public int? AVGHOURS { get; set; }
        public string? SIN { get; set; }
        public int? STARTTRANS { get; set; }
        public int? ENDTRANS { get; set; }
        public int? PUNCHINDEX { get; set; }
        public int? CURBREAKINDEX { get; set; }
        public short? Gratuity { get; set; }
        public int? StoreNum { get; set; }
        public double? EmpPoints { get; set; }
        public short? InTraining { get; set; }
        public double? TrainingSales { get; set; }
        public DateTime? BIRTH { get; set; }
        public string? EmpLastName { get; set; }
        public int? ShiftType { get; set; }
        public int? UpdateStatus { get; set; } = 1;
        public int? PagerNum { get; set; }
        public int? NeedsCashOut { get; set; }
        public int? SalaryTypeNum { get; set; }
        public string? EMAIL { get; set; }
        public int TILLLOCKED { get; set; } = 0;
        public int LASTSTAT { get; set; } = 0;
        public int? REVCENTER { get; set; }
        public DateTime? ENDDATE { get; set; }
        public string? REFCODE { get; set; }
        public string? WebCode { get; set; }
        public short WebAccess { get; set; } = 0;
        public string? PLink { get; set; }
        public string? RepSrvTreeView { get; set; }
        public int? TripId { get; set; }
        public string? CellPhone { get; set; }
        public int ShiftRuleId { get; set; } = 0;
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? HireStatus { get; set; }
        public string? DLNumber { get; set; }
        public DateTime? DLExpiry { get; set; }
        public int? IgnoreEmpHrs { get; set; }
        public short? MOD { get; set; }
        public short HasBioReg { get; set; } = 0;
        public short TillEmp { get; set; } = 0;
        public int? TillEmpStatNum { get; set; }
        public short PWDMustChge { get; set; } = 0;
        public short PWDCannotChge { get; set; } = 0;
        public short PWDNeverExp { get; set; } = 0;
        public short PWDLockedOut { get; set; } = 0;
        public int? PWDChgeDate { get; set; }
        public byte[]? PWDSalt { get; set; }
        public byte[]? PWDHash { get; set; }
        public int SNum { get; set; } = -1;
        public int LastTrans { get; set; } = 0;
        public long ReflectionUpdate { get; set; } = 0;

        [NotMapped]
        [JsonPropertyName("payRoll")]
        public List<PayRoll> PayRolls { get; set; } = [];

        [NotMapped]
        public EmpSchedInfo? EmpSchedInfo { get; set; }
    }

    public class EmployeeUpdate
    {
        [NotMapped]
        public required int EMPNUM { get; set; }
        public required string EMPNAME { get; set; }
        public DateTime? DateEntered { get; set; }
        public string? ADRESS1 { get; set; }
        public string? ADRESS2 { get; set; }
        public string? CITY { get; set; }
        public string? PROV { get; set; }
        public string? POSTAL { get; set; }
        public string? HOMETELE { get; set; }
        public string? BUSTELE { get; set; }
        public DateTime? STARTWORK { get; set; }
        public DateTime? ENDWORK { get; set; }
        public short? ISACTIVE { get; set; }
        public string? POSNAME { get; set; }
        public int? EMPPOSITION { get; set; }
        public short? SECLEVEL { get; set; }
        public short? LOGINCODE { get; set; }
        public short? PASSKEY { get; set; }
        public required string SWIPE { get; set; }
        public short? OPENDRAWER { get; set; }
        public short? INTRFACE { get; set; }
        public short? LASTPOSX { get; set; }
        public short? LASTPOSY { get; set; }
        public short? LASTACTION { get; set; }
        public short? ISCLOCKEDIN { get; set; }
        public decimal? HOURLYWAGE { get; set; }
        public decimal? YEARLYWAGE { get; set; }
        public int? AVGHOURS { get; set; }
        public string? SIN { get; set; }
        public int? STARTTRANS { get; set; }
        public int? ENDTRANS { get; set; }
        public int? PUNCHINDEX { get; set; }
        public int? CURBREAKINDEX { get; set; }
        public short? Gratuity { get; set; }
        public int? StoreNum { get; set; }
        public double? EmpPoints { get; set; }
        public short? InTraining { get; set; }
        public double? TrainingSales { get; set; }
        public DateTime? BIRTH { get; set; }
        public string? EmpLastName { get; set; }
        public int? ShiftType { get; set; }
        public int? UpdateStatus { get; set; }
        public int? PagerNum { get; set; }
        public int? NeedsCashOut { get; set; }
        public int? SalaryTypeNum { get; set; }
        public string? EMAIL { get; set; }
        public int? TILLLOCKED { get; set; }
        public int? LASTSTAT { get; set; }
        public int? REVCENTER { get; set; }
        public DateTime? ENDDATE { get; set; }
        public string? REFCODE { get; set; }
        public string? WebCode { get; set; }
        public short? WebAccess { get; set; }
        public string? PLink { get; set; }
        public string? RepSrvTreeView { get; set; }
        public int? TripId { get; set; }
        public string? CellPhone { get; set; }
        public int? ShiftRuleId { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? HireStatus { get; set; }
        public string? DLNumber { get; set; }
        public DateTime? DLExpiry { get; set; }
        public int? IgnoreEmpHrs { get; set; }
        public short? MOD { get; set; }
        public short? HasBioReg { get; set; }
        public short? TillEmp { get; set; }
        public int? TillEmpStatNum { get; set; }
        public short? PWDMustChge { get; set; }
        public short? PWDCannotChge { get; set; }
        public short? PWDNeverExp { get; set; }
        public short? PWDLockedOut { get; set; }
        public int? PWDChgeDate { get; set; }
        public byte[]? PWDSalt { get; set; }
        public byte[]? PWDHash { get; set; }
        public int? SNum { get; set; }
        public int? LastTrans { get; set; }
        public long? ReflectionUpdate { get; set; }

        [NotMapped]
        [JsonPropertyName("payRoll")]
        public List<PayRoll> PayRolls { get; set; } = [];

        [NotMapped]
        public EmpSchedInfo? EmpSchedInfo { get; set; }
    }
}
