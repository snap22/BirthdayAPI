using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Infrastructure.LinkResources.LinkGenerators;
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
        public AccountLinks Account { get; private set; }
        public ProfileLinks Profile { get; private set; }
        public ContactLinks Contact { get; private set; }
        public GiftLinks Gift { get; private set; }
        public NoteLinks Note { get; private set; }

        public LinksCreator(LinkGenerator linkGenerator)
        {
            Account = new AccountLinks(linkGenerator);
            Profile = new ProfileLinks(linkGenerator);
            Contact = new ContactLinks(linkGenerator);
            Gift = new GiftLinks(linkGenerator);
            Note = new NoteLinks(linkGenerator);
        }
    }
}
