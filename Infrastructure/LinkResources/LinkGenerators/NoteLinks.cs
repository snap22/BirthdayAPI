using BirthdayAPI.Core.Service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Infrastructure.LinkResources.LinkGenerators
{
    public class NoteLinks : BasicLinks<NoteDto>
    {
        public NoteLinks(LinkGenerator linkGenerator) : base(linkGenerator) { }

        public override LinkedEntity<NoteDto> GenerateLinksForOneEntity(HttpContext httpContext, NoteDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
