using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace leave_management.Models
{
    public class LeaveAllocationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public int Period { get; set; }

        public EmployeeViewModel Employee { get; set; }

        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }

        [Display(Name = "Leave Types")]
        public  LeaveTypeViewModel LeaveType { get; set; }

        [Display(Name = "Leave Type ID")]
        public int LeaveTypeId { get; set; }       

    }

    public class CreateLeaveAllocationViewModel
    {
        [Display(Name = "Number Updated")]
        public int NumberUpdated { get; set; }

        [Display(Name = "Leave Types")]
        public List<LeaveTypeViewModel> LeaveTypes { get; set; } 
    }

    public class EditLeaveAllocationViewModel
    {
        public int Id { get; set; }

        public EmployeeViewModel Employee { get; set; }

        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }

        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Leave Type")]
        public LeaveTypeViewModel LeaveType { get; set; }
    }

    public class ViewAllocationsViewModel
    {
        public EmployeeViewModel Employee { get; set; }

        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }

        [Display(Name = "Leave Allocations")]
        public List<LeaveAllocationViewModel> LeaveAllocations { get; set; }
    }
}
