using System;
using System.Collections.Generic;
using leave_management.Data;

namespace leave_management.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        bool CheckAllocation(int leaveTypeId, string employeeId);

        ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id);

        LeaveAllocation GetLeaveAllocationsByEmployeeAndType(string id, int leaveTypeId);
    }
}
