using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackOffice.Entity.Employees
{
    [Table("EmpDepartments")]
    public class EmpDepartment
    {
        public Guid ClientId { get; set; }

        [Key]
        public int DeptNum { get; set; }
        public string? Descript { get; set; }
        public required int ISActive { get; set; }
        public int? reporttype { get; set; }
        public string? PLink { get; set; }
        public int? UpdateStatus { get; set; } = 1;
        public int? SNUM { get; set; } = -1;
    }

    public class EmpDepartmentUpdate
    {
        [NotMapped]
        public required int DeptNum { get; set; }
        public string? Descript { get; set; }
        public int? ISActive { get; set; }
        public int? reporttype { get; set; }
        public string? PLink { get; set; }
        public int? UpdateStatus { get; set; }
        public int? SNUM { get; set; }
    }
}
