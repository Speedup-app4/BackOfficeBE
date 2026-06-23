using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;

namespace BackOffice.Services.Modules.Employees
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
                    payRollList.AddRange(payrolls);

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
                e.PayRolls = [.. payRollList.Where(p => p.EMPNUM == e.EMPNUM)];
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

                List<PayRoll> payRollsToAdd = [];

                if (employee.PayRolls != null && employee.PayRolls.Any())
                {
                    var payRollCount = employee.PayRolls.Count;
                    var nextSequence = await _uow.AutoInc.GetNextSequenceAsync(
                        AutoIncType.GETNEXT_PAYROLL,
                        clientId,
                        null,
                        payRollCount
                    );

                    int startSequence = nextSequence - payRollCount + 1;

                    foreach (var pr in employee.PayRolls)
                    {
                        pr.ClientId = clientId;
                        pr.EMPNUM = EMPNUM;
                        pr.UNIQUEID = startSequence++;
                        pr.ISACTIVE = 1;
                        pr.UpdateStatus = 1;
                        payRollsToAdd.Add(pr);
                    }
                }

                if (employee.EmpSchedInfo != null)
                {
                    employee.EmpSchedInfo.EmpNum = EMPNUM;
                    employee.EmpSchedInfo.ClientId = clientId;
                }

                var createdEmployee = await _uow.Employee.AddAsync(employee);

                if (payRollsToAdd.Count > 0)
                {
                    await _uow.PayRoll.AddRangeAsync(payRollsToAdd);
                    createdEmployee?.PayRolls = payRollsToAdd;
                }

                if (employee.EmpSchedInfo != null)
                {
                    await _uow.EmpSchedInfo.AddAsync(employee.EmpSchedInfo);
                    createdEmployee?.EmpSchedInfo = employee.EmpSchedInfo;
                }

                _uow.Commit();
                return createdEmployee!;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<Employee> Update(Guid clientId, EmployeeUpdate updateDto)
        {
            try
            {
                _uow.BeginTransaction();

                var updatedEmployee = await _uow.Employee.UpdatePartialAsync(
                    updateDto,
                    updateDto.EMPNUM,
                    clientId
                );

                if (updateDto.PayRolls != null && updateDto.PayRolls.Any())
                {
                    var existingPayRolls = await _uow.PayRoll.GetByEmpNum(
                        clientId,
                        updateDto.EMPNUM
                    );
                    var existingIds =
                        existingPayRolls?.Select(x => x.UNIQUEID).ToHashSet() ?? new HashSet<int>();

                    var payRollsToUpdate = new List<PayRoll>();
                    var payRollsToAdd = new List<PayRoll>();

                    foreach (var pr in updateDto.PayRolls)
                    {
                        pr.EMPNUM = updateDto.EMPNUM;
                        pr.ClientId = clientId;

                        if (existingIds.Contains(pr.UNIQUEID))
                        {
                            payRollsToUpdate.Add(pr);
                        }
                        else
                        {
                            payRollsToAdd.Add(pr);
                        }
                    }

                    // Xử lý Update hàng loạt cho các PayRoll đã tồn tại
                    if (payRollsToUpdate.Count > 0)
                    {
                        await _uow.PayRoll.UpdatePartialRangeAsync(payRollsToUpdate, clientId);
                    }

                    // Xử lý Insert hàng loạt (kèm lấy Sequence 1 lần) cho các PayRoll mới
                    if (payRollsToAdd.Count > 0)
                    {
                        var nextSequence = await _uow.AutoInc.GetNextSequenceAsync(
                            AutoIncType.GETNEXT_PAYROLL,
                            clientId,
                            null,
                            payRollsToAdd.Count
                        );

                        int startSequence = nextSequence - payRollsToAdd.Count + 1;

                        foreach (var newPr in payRollsToAdd)
                        {
                            newPr.UNIQUEID = startSequence++;
                            await _uow.PayRoll.AddAsync(newPr);
                        }
                    }

                    updatedEmployee?.PayRolls = updateDto.PayRolls;
                }

                if (updateDto.EmpSchedInfo != null)
                {
                    var existingSched = await _uow.EmpSchedInfo.GetByEmpNum(
                        clientId,
                        updateDto.EMPNUM
                    );

                    updateDto.EmpSchedInfo.EmpNum = updateDto.EMPNUM;
                    updateDto.EmpSchedInfo.ClientId = clientId;

                    if (existingSched != null)
                    {
                        await _uow.EmpSchedInfo.UpdatePartialAsync(
                            updateDto.EmpSchedInfo,
                            existingSched.EmpNum,
                            clientId
                        );
                    }
                    else
                    {
                        await _uow.EmpSchedInfo.AddAsync(updateDto.EmpSchedInfo);
                    }

                    updatedEmployee?.EmpSchedInfo = updateDto.EmpSchedInfo;
                }

                _uow.Commit();
                return updatedEmployee!;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
