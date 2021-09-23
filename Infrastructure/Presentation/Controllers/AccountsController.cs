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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BasicController
    {
        public AccountsController(IServiceManager service, LinksCreator links) : base(service, links) { }

        /// <summary>
        /// Gets a list of accounts
        /// </summary>
        /// <param name="accountParameters"></param>
        /// <returns>A list of accounts</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Accounts
        ///
        /// </remarks>
        /// <response code="200">Returns a list of accounts</response>
        [HttpGet(Name = "GetAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts([FromQuery] AccountParameters accountParameters)
        {
            var accounts = await _service.AccountService.GetAccounts(accountParameters);
            var linkedAccounts = _linksCreator.Account.GenerateLinksForManyEntities(HttpContext, accounts);
            return Ok(linkedAccounts);
        }

        /// <summary>
        /// Gets a specific account
        /// </summary>
        /// <param name="id">ID of an account</param>
        /// <returns>An account</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Accounts/5
        ///
        /// </remarks>
        /// <response code="200">Returns an accout that has been found</response>
        /// <response code="404">If an account with given id has not been found</response>
        [HttpGet("{id}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            var foundAccount = await _service.AccountService.GetAccount(id);
            var linkedAccount = _linksCreator.Account.GenerateLinksForOneEntity(HttpContext, foundAccount);
            return Ok(linkedAccount);
        }

        /// <summary>
        /// Updates a specific account
        /// </summary>
        /// <param name="id">ID of an account</param>
        /// <param name="account">account</param>
        /// <returns>An updated account</returns>
        /// <remarks>
        /// The AccountId and DateCreated attributes cannot be changed
        /// 
        /// Sample request:
        ///
        ///     PUT /api/Accounts/5
        ///
        /// </remarks>
        /// <response code="200">Returns an accout that has been updated</response>
        /// <response code="404">If an account with given id has not been found</response>
        /// <response code="400">If the email is already used</response>
        [HttpPut("{id}", Name = "PutAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAccount(int id, AccountDto account)
        {
            return Ok(await _service.AccountService.UpdateAccount(id, account));
        }

        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="account">account</param>
        /// <returns>A new account</returns>
        /// <remarks>
        /// The AccountId and DateCreated attributes are created automatically
        /// 
        /// Sample request:
        ///
        ///     POST /api/Accounts
        ///
        /// </remarks>
        /// <response code="200">Returns a newly created account</response>
        /// <response code="400">If the email is already used</response>
        [HttpPost(Name = "PostAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDto>> PostAccount(AccountDto account)
        {
            var newAccount = await _service.AccountService.CreateAccount(account);

            return CreatedAtAction(nameof(GetAccount), new { id = newAccount.AccountId }, newAccount);
        }

        /// <summary>
        /// Deletes a specific account
        /// </summary>
        /// <param name="id">ID of an account</param>
        /// <returns>A deleted account</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Accounts/5
        ///
        /// </remarks>
        /// <response code="200">Returns an accout that has been deleted</response>
        /// <response code="404">If an account with given id has not been found</response>
        [HttpDelete("{id}", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountDto>> DeleteAccount(int id)
        {
            return Ok(await _service.AccountService.RemoveAccount(id));
        }

        
    }
}
