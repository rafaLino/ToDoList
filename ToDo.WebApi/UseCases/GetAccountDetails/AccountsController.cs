using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDo.Application.Queries;

namespace ToDo.WebApi.UseCases.GetAccountDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsQueries _accountsQueries;

        public AccountsController(IAccountsQueries accountsQueries)
        {
            _accountsQueries = accountsQueries;
        }

        [HttpGet("{accountId}", Name = "GetAccounts")]
        public async Task<IActionResult> Get(Guid accountId)
        {
            var account = await _accountsQueries.GetAccount(accountId);

            return Ok(account);
        }
    }
}
