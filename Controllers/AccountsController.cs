using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BirthdayAPI.Persistence.Context;
using BirthdayAPI.Persistence.Models.Normal;
using BirthdayAPI.Persistence.Services;
using BirthdayAPI.Persistence.Models.DTO;

namespace BirthdayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {
            return Ok(await _service.GetAccounts());
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            return Ok(await _service.GetAccount(id));
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutAccount(AccountDto account)
        {
            return Ok(await _service.UpdateAccount(account));
        }

        // POST: api/Accounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountDto>> PostAccount(AccountDto account)
        {
            await _service.CreateAccount(account);

            return CreatedAtAction(nameof(GetAccount), new { id = account.AccountId }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountDto>> DeleteAccount(int id)
        {
            var deletedAccount = await _service.RemoveAccount(id);
            return Ok(deletedAccount);
        }

        
    }
}
