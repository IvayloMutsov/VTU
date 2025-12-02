using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.BaseServices;
using Services.LoanServices;
using System.Security.Claims;

namespace LibraryMVC.Controllers
{
    public class LoanController : Controller
    {
        ILoanService service;

        public LoanController(ILoanService loanService)
        {
            service = loanService;
        }

        [HttpGet]
        public async Task<IActionResult> LoanView()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdString, out var userId))
            {
                return Unauthorized("Access not allowed");
            } 
            var loans = await service.GetLoans(userId);
            foreach (var item in loans)
            {
                service.ReturnLoan(item.ID);
            }
            return View(loans);
        }

        [HttpGet]
        public async Task<IActionResult> SearchById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid ID");
            }
            Loan loan = await service.GetLoan(id);
            if (loan == null)
            {
                return NotFound();
            }
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdString, out var userId))
            {
                return Unauthorized("Access not allowed");
            }
            if (loan.User != userId)
            {
                return Unauthorized("Access not allowed");
            }
            service.ReturnLoan(loan.ID);
            return View(loan);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ExtendLoan(int loanID, int loanPeriod)
        {
            await service.ExtendLoan(loanID, loanPeriod);
            return PartialView("_TaskCompleted");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CancellLoan(int loanID)
        {
            await service.CancellLoan(loanID);
            return PartialView("_TaskCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> AddLoan(int bookID, int loanPeriod)
        {
            // Get the current logged-in user's ID
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdString, out var userId))
            {
                return Unauthorized("Access not allowed");
            }
            await service.AddLoan(userId, bookID, loanPeriod);
            return PartialView("_TaskCompleted");
        }
    }
}
