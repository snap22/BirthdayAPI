using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Infrastructure.Presentation.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Infrastructure.LinkResources
{
    public class LinksCreator
    {
        private readonly LinkGenerator _linkGenerator;

        public LinksCreator(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }
        public LinkedEntity<AccountDto> GenerateLinksForAccount(HttpContext httpContext, AccountDto account)
        {
            var linkedAccount = new LinkedEntity<AccountDto> { Value = account };

            
            var links = new List<Link>
            {
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, nameof(AccountsController.GetAccount), "Accounts", values: new { id = account.AccountId }), "self", "GET"),
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, action : nameof(AccountsController.PutAccount), controller: "Accounts", values: new {id = account.AccountId }), "update_account", "PUT"),
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, nameof(AccountsController.DeleteAccount), "Accounts", values: new { id = account.AccountId }), "delete_account", "DELETE")
            };

            

            

            linkedAccount.Links = links;
            return linkedAccount;
        }
    }
}
