using BackOffice.Entity.Employees;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class EmployeeService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<Employee>> Get(Guid clientId, int? EmpNum = null)
        {
            var employeeList = new List<Employee>();
            var payRollList = new List<PayRoll>();
            var empSchedList = new List<EmpSchedInfo>();

            if (EmpNum.HasValue)
            {
                var employee =
                    await _uow.Employee.GetByIdAsync(EmpNum.Value, true, clientId)
                    ?? throw new Exception("Không tìm thấy mã nhân viên");

                employeeList.Add(employee);

                var payrolls = await _uow.PayRoll.GetByEmpNum(clientId, EmpNum.Value);

                if (payrolls != null)
                    payRollList.Add(payrolls);

                var scheds = await _uow.EmpSchedInfo.GetByEmpNum(clientId, EmpNum.Value);
                if (scheds != null)
                    empSchedList.Add(scheds);
            }
            else
            {
                var employees = await _uow.Employee.GetAllAsync(true, clientId);
                employeeList.AddRange(employees);

                var payrolls = await _uow.PayRoll.GetAllAsync(true, clientId);
                payRollList.AddRange(payrolls);

                var scheds = await _uow.EmpSchedInfo.GetAllAsync(true, clientId);
                empSchedList.AddRange(scheds);
            }

            var joinData = employeeList.Select(e =>
            {
                e.PayRoll = payRollList.FirstOrDefault(p => p.EMPNUM == e.EMPNUM);
                e.EmpSchedInfo = empSchedList.FirstOrDefault(s => s.EmpNum == e.EMPNUM);
                return e;
            });

            return joinData;
        }

        public async Task<Employee> Create(Guid clientId, Employee employee)
        {
            try
            {
                _uow.BeginTransaction();

                var existingPass = await _uow.Employee.GetBySwipeAsync(clientId, employee.SWIPE);

                if (existingPass != null)
                    throw new Exception("Password already exists");

                var EMPNUM = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_EMPNO,
                    clientId
                );

                employee.EMPNUM = EMPNUM;
                employee.ClientId = clientId;
                employee.ISACTIVE = 1;
                employee.UpdateStatus = 1;
                employee.SNum = -1;

                if (employee.PayRoll != null)
                {
                    var nextSequence = await _uow.AutoInc.GetNextSequenceAsync(
                        AutoIncType.GETNEXT_PAYROLL,
                        clientId,
                        null
                    );

                    employee.PayRoll.ClientId = clientId;
                    employee.PayRoll.EMPNUM = EMPNUM;
                    employee.PayRoll.UNIQUEID = nextSequence;
                    employee.PayRoll.ISACTIVE = 1;
                    employee.PayRoll.UpdateStatus = 1;
                }

                if (employee.EmpSchedInfo != null)
                {
                    employee.EmpSchedInfo.EmpNum = EMPNUM;
                    employee.EmpSchedInfo.ClientId = clientId;
                }

                var createdEmployee = await _uow.Employee.AddAsync(employee);

                if (employee.PayRoll != null)
                    await _uow.PayRoll.AddAsync(employee.PayRoll);

                if (employee.EmpSchedInfo != null)
                    await _uow.EmpSchedInfo.AddAsync(employee.EmpSchedInfo);

                _uow.Commit();
                return createdEmployee;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        // public async Task<Employee> Update(Guid clientId, EmployeeUpdate updateDto)
        // {
        //     try
        //     {
        //         _uow.BeginTransaction();

        //         if (!string.IsNullOrEmpty(updateDto.SWIPE))
        //         {
        //             var existingPass = await _uow.Employee.GetByConditionAsync(e =>
        //                 e.SWIPE == updateDto.SWIPE && e.ClientId == clientId
        //             );
        //             if (existingPass != null && existingPass.EMPNUM != updateDto.EMPNUM)
        //             {
        //                 throw new Exception("Password already exists");
        //             }
        //         }

        //         // 2. Cập nhật Employee (Partial)
        //         updateDto.UpdateStatus = 1;
        //         var updatedEmployee = await _uow.Employee.UpdatePartialAsync(
        //             updateDto,
        //             updateDto.EMPNUM,
        //             clientId
        //         );

        //         // 3. Xử lý danh sách PayRoll
        //         if (updateDto.PayRoll != null)
        //         {
        //             var oldPayRolls = await _uow.PayRoll.FindAsync(p =>
        //                 p.EMPNUM == updateDto.EMPNUM && p.ClientId == clientId
        //             );

        //             var paysToInsert = new List<PayRoll>();
        //             var paysToUpdate = new List<PayRoll>();
        //             var paysToDelete = new List<PayRoll>();

        //             // Phân loại Update và Delete
        //             foreach (var oldPay in oldPayRolls)
        //             {
        //                 var incomingPay = updateDto.PayRoll.FirstOrDefault(p =>
        //                     p.UNIQUEID == oldPay.UNIQUEID
        //                 );

        //                 if (incomingPay != null)
        //                 {
        //                     incomingPay.UpdateStatus = 1;
        //                     paysToUpdate.Add(incomingPay);
        //                 }
        //                 else
        //                 {
        //                     paysToDelete.Add(oldPay);
        //                 }
        //             }

        //             // Phân loại Insert (Các PayRoll có UNIQUEID = 0)
        //             var newPays = updateDto.PayRoll.Where(p => p.UNIQUEID == 0).ToList();

        //             if (newPays.Count > 0)
        //             {
        //                 var currentNextNumFromDb = await _uow.AutoInc.GetNextSequenceAsync(
        //                     AutoIncType.GETNEXT_PAYROLL,
        //                     clientId,
        //                     null,
        //                     newPays.Count
        //                 );

        //                 int startSequence = currentNextNumFromDb - newPays.Count + 1;

        //                 foreach (var newPay in newPays)
        //                 {
        //                     var payEntity = new PayRoll
        //                     {
        //                         ClientId = clientId,
        //                         UNIQUEID = startSequence++,
        //                         EMPNUM = updateDto.EMPNUM,
        //                         JOBPOS = newPay.JOBPOS,
        //                         PAYRATE = newPay.PAYRATE,
        //                         ISACTIVE = 1,
        //                         UpdateStatus = 1,
        //                         IsPrimary = newPay.IsPrimary,
        //                         PLink = newPay.PLink,
        //                         SNUM = newPay.SNUM ?? -1,
        //                     };
        //                     paysToInsert.Add(payEntity);
        //                 }
        //             }

        //             // Thực thi Insert / Update / Soft Delete cho PayRoll
        //             if (paysToInsert.Count > 0)
        //                 await _uow.PayRoll.AddRangeAsync(paysToInsert);

        //             if (paysToUpdate.Count > 0)
        //             {
        //                 foreach (var upd in paysToUpdate)
        //                 {
        //                     await _uow.PayRoll.UpdatePartialAsync(upd, upd.UNIQUEID, clientId);
        //                 }
        //             }

        //             if (paysToDelete.Count > 0)
        //             {
        //                 foreach (var del in paysToDelete)
        //                 {
        //                     await _uow.PayRoll.UpdatePartialAsync(
        //                         new { ISACTIVE = (short)0, UpdateStatus = (short)1 },
        //                         del.UNIQUEID,
        //                         clientId
        //                     );
        //                 }
        //             }
        //         }

        //         // 4. Xử lý cập nhật EmpSchedule (Giả định 1-1 Update)
        //         if (updateDto.EmpSchedule != null)
        //         {
        //             updateDto.EmpSchedule.UpdateStatus = 1;

        //             if (updateDto.EmpSchedule.ShiftIndex > 0)
        //             {
        //                 // Đã có sẵn -> Cập nhật
        //                 await _uow.EmpSchedule.UpdatePartialAsync(
        //                     updateDto.EmpSchedule,
        //                     updateDto.EmpSchedule.ShiftIndex,
        //                     clientId
        //                 );
        //             }
        //             else
        //             {
        //                 // Chưa có -> Tạo mới
        //                 var shiftIndex = await _uow.AutoInc.GetNextSequenceAsync(
        //                     AutoIncType.GETNEXT_EMPSCHEDULE,
        //                     clientId
        //                 );
        //                 var newSched = new EmpSchedule
        //                 {
        //                     ClientId = clientId,
        //                     ShiftIndex = shiftIndex,
        //                     EmpNum = updateDto.EMPNUM,
        //                     TimeStart = updateDto.EmpSchedule.TimeStart ?? DateTime.Now,
        //                     TimeEnd = updateDto.EmpSchedule.TimeEnd ?? DateTime.Now,
        //                     ShiftType = updateDto.EmpSchedule.ShiftType ?? 0,
        //                     JobPos = updateDto.EmpSchedule.JobPos ?? 0,
        //                     IsActive = updateDto.EmpSchedule.IsActive,
        //                     AllowBreaks = updateDto.EmpSchedule.AllowBreaks,
        //                     PayRate = updateDto.EmpSchedule.PayRate,
        //                     Status = updateDto.EmpSchedule.Status,
        //                     UpdateStatus = 1,
        //                     SNUM = -1,
        //                 };
        //                 await _uow.EmpSchedule.AddAsync(newSched);
        //             }
        //         }

        //         _uow.Commit();
        //         return updatedEmployee;
        //     }
        //     catch
        //     {
        //         _uow.Rollback();
        //         throw;
        //     }
        // }
    }
}
