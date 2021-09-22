using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BirthdayAPI.Core.Service.Services.Abstractions;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Infrastructure.LinkResources;

namespace BirthdayAPI.Infrastructure.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BasicController
    {
        public AccountsController(IServiceManager service, LinksCreator links) : base(service, links) { }

        // GET: api/Accounts
        [HttpGet(Name = "GetAccounts")]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts([FromQuery] AccountParameters accountParameters)
        {
            var accounts = await _service.AccountService.GetAccounts(accountParameters);
            var linkedAccounts = _linksCreator.GenerateLinksForAccounts(HttpContext, accounts);
            return Ok(linkedAccounts);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            var foundAccount = await _service.AccountService.GetAccount(id);
            var linkedAccount = _linksCreator.GenerateLinksForAccount(HttpContext, foundAccount);
            return Ok(linkedAccount);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}", Name = "PutAccount")]
        public async Task<IActionResult> PutAccount(int id, AccountDto account)
        {
            return Ok(await _service.AccountService.UpdateAccount(id, account));
        }

        // POST: api/Accounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name = "PostAccount")]
        public async Task<ActionResult<AccountDto>> PostAccount(AccountDto account)
        {
            var newAccount = await _service.AccountService.CreateAccount(account);

            return CreatedAtAction(nameof(GetAccount), new { id = newAccount.AccountId }, newAccount);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}", Name = "DeleteAccount")]
        public async Task<ActionResult<AccountDto>> DeleteAccount(int id)
        {
            return Ok(await _service.AccountService.RemoveAccount(id));
        }

        
    }
}
