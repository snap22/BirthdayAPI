using BirthdayAPI.Core.Service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Infrastructure.LinkResources.LinkGenerators
{
    public class ContactLinks : BasicLinks<ContactDto>
    {
        public ContactLinks(LinkGenerator linkGenerator) : base(linkGenerator) { }

        public override LinkedEntity<ContactDto> GenerateLinksForOneEntity(HttpContext httpContext, ContactDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
