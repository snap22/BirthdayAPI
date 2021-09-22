using BirthdayAPI.Core.Service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Infrastructure.LinkResources.LinkGenerators
{
    public class GiftLinks : BasicLinks<GiftDto>
    {
        public GiftLinks(LinkGenerator linkGenerator) : base(linkGenerator) { }

        public override LinkedEntity<GiftDto> GenerateLinksForOneEntity(HttpContext httpContext, GiftDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
