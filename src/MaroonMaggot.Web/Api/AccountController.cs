using MaroonMaggot.Core.AccountAggregate;
using MaroonMaggot.SharedKernel.Interfaces;
using MaroonMaggot.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MaroonMaggot.Web.Api
{
    public class AccountController : BaseApiController
    {
        private readonly IRepository<Account> _repository;

        public AccountController(IRepository<Account> repository)
        {
            _repository = repository;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var accountDTOs = (await _repository.ListAsync())
                .Select(account => new AccountDTO
                {
                    Id = account.Id,
                    Name = account.Name
                })
                .ToList();

            return Ok(accountDTOs);
        }
    }
}
