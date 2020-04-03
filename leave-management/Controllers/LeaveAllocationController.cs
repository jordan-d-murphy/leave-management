using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace leave_management.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public LeaveAllocationController(
            ILeaveAllocationRepository leaveAllocationRepo,
            ILeaveTypeRepository leaveTypeRepo,
            IMapper mapper,
            UserManager<IdentityUser> userManager
            )
        {
            _leaveAllocationRepo = leaveAllocationRepo;
            _leaveTypeRepo = leaveTypeRepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: LeaveTypes
        public ActionResult Index()
        {
            var leaveTypes = _leaveTypeRepo.FindAll().ToList();
            var mappedLeaveTypes = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leaveTypes);
            var model = new CreateLeaveAllocationViewModel
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdated = 0
            };
            return View(model);
        }

        public ActionResult SetLeave(int id)
        {
            var leaveType = _leaveTypeRepo.FindById(id);
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;

            foreach (var emp in employees)
            {
                if (_leaveAllocationRepo.CheckAllocation(id, emp.Id))
                {
                    continue;
                }

                var allocation = new LeaveAllocationViewModel
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };

                var leaveAllocation = _mapper.Map<LeaveAllocation>(allocation);
                _leaveAllocationRepo.Create(leaveAllocation);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveTypes/Details/5
        public ActionResult Details(int id)
        {
            //if (!_repo.isExists(id))
            //{
            //    return NotFound();
            //}

            //var leaveType = _repo.FindById(id);
            //var model = _mapper.Map<LeaveTypeViewModel>(leaveType);

            //return View(model);
            return View();
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeViewModel model)
        {
            //try
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        return View(model);
            //    }

            //    var leaveType = _mapper.Map<LeaveType>(model);
            //    leaveType.DateCreated = DateTime.Now;
            //    var isSuccess = _repo.Create(leaveType);

            //    if (!isSuccess)
            //    {
            //        ModelState.AddModelError("", "Something went wrong trying to add your Leave Type.");
            //        return View(model);
            //    }

            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    ModelState.AddModelError("", "Something went wrong trying to add your Leave Type.");
            //    return View(model);

            //}
            return View();
        }

        // GET: LeaveTypes/Edit/5
        public ActionResult Edit(int id)
        {
            //if (!_repo.isExists(id))
            //{
            //    return NotFound();
            //}

            //var leaveType = _repo.FindById(id);
            //var model = _mapper.Map<LeaveTypeViewModel>(leaveType);
            //return View(model);
            return View();
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeViewModel model)
        {
            //try
            //{
            //    // TODO: Add update logic here
            //    if (!ModelState.IsValid)
            //    {
            //        return View(model);
            //    }
            //    var leaveType = _mapper.Map<LeaveType>(model);
            //    var isSuccess = _repo.Update(leaveType);

            //    if (!isSuccess)
            //    {
            //        ModelState.AddModelError("", "Something went wrong trying to Edit your Leave Type.");
            //        return View(model);
            //    }

            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    ModelState.AddModelError("", "Something went wrong trying to Edit your Leave Type.");
            //    return View(model);
            //}
            return View();
        }

        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int id)
        {
            //if (!_repo.isExists(id))
            //{
            //    return NotFound();
            //}

            //var leaveType = _repo.FindById(id);
            //var model = _mapper.Map<LeaveTypeViewModel>(leaveType);
            //return View(model);
            return View();
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveHistoryViewModel model)
        {
            //try
            //{
            //    // TODO: Add delete logic here
            //    var leaveType = _repo.FindById(id);

            //    if (leaveType == null)
            //    {
            //        return NotFound();
            //    }

            //    var isSuccess = _repo.Delete(leaveType);

            //    if (!isSuccess)
            //    {
            //        return View(model);
            //    }

            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View(model);
            //}
            return View();
        }
    }

}
