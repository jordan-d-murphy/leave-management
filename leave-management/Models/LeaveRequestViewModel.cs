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
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Leave Type")]
        public  LeaveTypeViewModel LeaveType { get; set; }

        [Display(Name = "Leave Type ID")]
        public int LeaveTypeId { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Date Actioned")]
        public DateTime DateActioned { get; set; }

        public bool? Approved { get; set; }

        [Display(Name = "Approved By")]
        public EmployeeViewModel ApprovedBy { get; set; }

        [Display(Name = "Approved By ID")]
        public string ApprovedById { get; set; }

        [Display(Name = "Leave Types")]
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }

    public class AdminLeaveRequestViewViewModel
    {
        public int TotalRequests { get; set; }

        public int PendingRequests { get; set; }

        public int ApprovedRequests { get; set; }

        public int RejectedRequests { get; set; }

        public List<LeaveRequestViewModel> LeaveRequests { get; set; }
    }
}
