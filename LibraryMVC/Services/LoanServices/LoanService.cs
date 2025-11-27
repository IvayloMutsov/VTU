using Database.Data;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LoanServices
{
    public class LoanService : ILoanService
    {
        IApplicationDbContext context;

        public LoanService(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddLoan(Guid userId, int bookId, int loanPeriod)
        {
            var book = await context.Books
                                     .Include(b => b.Author) 
                                     .Include(b => b.Genre)  
                                     .FirstOrDefaultAsync(b => b.ID == bookId);

            Loan loan = new Loan
            {
                User = userId,
                Book = book,
                LoanPeriodDays = loanPeriod,
                DateLoaned = DateOnly.FromDateTime(DateTime.Today)
            };
            loan.ReturnDate = loan.DateLoaned.AddDays(loan.LoanPeriodDays);
            context.BookLoans.Add(loan);
            await context.SaveChangesAsync();
        }

        public async Task CancellLoan(int loanID)
        {
            Loan loan = await context.BookLoans
                                      .Include(l => l.Book) 
                                      .ThenInclude(b => b.Author) 
                                      .Include(l => l.Book)
                                      .ThenInclude(b => b.Genre)
                                      .FirstOrDefaultAsync(l => l.ID == loanID);

            loan.isCancelled = true;
            loan.isReturned = true;
            loan.ReturnDate = DateOnly.FromDateTime(DateTime.Today);
            await context.SaveChangesAsync();
        }

        public async Task ExtendLoan(int loanID, int loanPeriod)
        {
            Loan loan = await context.BookLoans
                                      .Include(l => l.Book) 
                                      .ThenInclude(b => b.Author) 
                                      .Include(l => l.Book)
                                      .ThenInclude(b => b.Genre) 
                                      .FirstOrDefaultAsync(l => l.ID == loanID);

            loan.ReturnDate = loan.ReturnDate.AddDays(loanPeriod);
            loan.LoanPeriodDays += loanPeriod;
            loan.isExtended = true;
            await context.SaveChangesAsync();
        }

        public async Task<Loan> GetLoan(int loanID)
        {
            Loan loan = await context.BookLoans
                                      .Include(l => l.Book)
                                      .ThenInclude(b => b.Author)
                                      .Include(l => l.Book)
                                      .ThenInclude(b => b.Genre)
                                      .FirstOrDefaultAsync(l => l.ID == loanID);
            return loan;
        }

        public async Task<List<Loan>> GetLoans(Guid userId)
        {
            return await context.BookLoans
            .Include(l => l.Book)
            .ThenInclude(b => b.Genre)
            .Include(l => l.Book)
            .ThenInclude(b => b.Author)
            .Where(l => l.User == userId && l.isReturned == false)
            .ToListAsync();
        }
    }
}
