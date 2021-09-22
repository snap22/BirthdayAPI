using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Infrastructure.Presentation.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Infrastructure.LinkResources.LinkGenerators
{
    public class AccountLinks : BasicLinks<AccountDto>
    {
        public AccountLinks(LinkGenerator linkGenerator) : base(linkGenerator) { }

        public override LinkedEntity<AccountDto> GenerateLinksForOneEntity(HttpContext httpContext, AccountDto entity)
        {
            var linkedAccount = new LinkedEntity<AccountDto> { Value = entity };

            linkedAccount.Links = new List<Link>
            {
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, nameof(AccountsController.GetAccount), "Accounts", values: new { id = entity.AccountId }), "self", "GET"),
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, action : nameof(AccountsController.PutAccount), controller: "Accounts", values: new {id = entity.AccountId }), "update_account", "PUT"),
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, nameof(AccountsController.DeleteAccount), "Accounts", values: new { id = entity.AccountId }), "delete_account", "DELETE"),
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, nameof(ProfilesController.GetProfileByAccount), "Profiles", values: new { accountId = entity.AccountId }), "self_profile", "GET")
            };
            return linkedAccount;
        }
    }
}
