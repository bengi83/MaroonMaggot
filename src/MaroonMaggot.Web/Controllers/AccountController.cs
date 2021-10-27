using MaroonMaggot.Core.AccountAggregate;
using MaroonMaggot.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaroonMaggot.Web.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountController(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }
    }
}
