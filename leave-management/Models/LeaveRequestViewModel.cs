using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace leave_management.Models
{
    public class LeaveRequestViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Requesting Employee")]
        public EmployeeViewModel RequestingEmployee { get; set; }

        [Display(Name = "Requesting Employee ID")]
        public string RequestingEmployeeId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Leave Type")]
        public  LeaveTypeViewModel LeaveType { get; set; }

        [Display(Name = "Leave Type ID")]
        public int LeaveTypeId { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Date Actioned")]
        [DataType(DataType.Date)]
        public DateTime DateActioned { get; set; }

        public bool? Approved { get; set; }

        [Display(Name = "Approved By")]
        public EmployeeViewModel ApprovedBy { get; set; }

        [Display(Name = "Approved By ID")]
        public string ApprovedById { get; set; }

        [Display(Name = "Leave Types")]
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }

        [Display(Name = "Employee Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }

        public bool Cancelled { get; set; }
    }

    public class AdminLeaveRequestViewViewModel
    {
        [Display(Name = "Total Requests")]
        public int TotalRequests { get; set; }

        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }

        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }

        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }

        public List<LeaveRequestViewModel> LeaveRequests { get; set; }
    }

    public class CreateLeaveRequestViewModel
    {
        [Display(Name = "Start Date")]
        [Required]       
        public string StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required]        
        public string EndDate { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; }

        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }

        [Display(Name = "Employee Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
    }

    public class EmployeeLeaveRequestViewViewModel
    {
        public List<LeaveAllocationViewModel> LeaveAllocations { get; set; }

        public List<LeaveRequestViewModel> LeaveRequests { get; set; }
    }

}
