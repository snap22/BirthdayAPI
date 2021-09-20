using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BirthdayAPI.Core.Service.Services.Abstractions;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;

namespace BirthdayAPI.Infrastructure.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BasicController
    {
        public AccountsController(IServiceManager service) : base(service) { }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts([FromQuery] AccountParameters accountParameters)
        {
            return Ok(await _service.AccountService.GetAccounts(accountParameters));
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            return Ok(await _service.AccountService.GetAccount(id));
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, AccountDto account)
        {
            return Ok(await _service.AccountService.UpdateAccount(id, account));
        }

        // POST: api/Accounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountDto>> PostAccount(AccountDto account)
        {
            var newAccount = await _service.AccountService.CreateAccount(account);

            return CreatedAtAction(nameof(GetAccount), new { id = newAccount.AccountId }, newAccount);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountDto>> DeleteAccount(int id)
        {
            return Ok(await _service.AccountService.RemoveAccount(id));
        }

        
    }
}
