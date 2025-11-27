using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BaseServices
{
    public interface ILoanService
    {
        public Task AddLoan(Guid user, int bookID, int loanPeriod);
        public Task CancellLoan(int loanID);
        public Task ExtendLoan(int loanID, int loanPeriod);
        public Task<Loan> GetLoan(int loanID);
        public Task<List<Loan>> GetLoans(Guid userId);
    }
}
