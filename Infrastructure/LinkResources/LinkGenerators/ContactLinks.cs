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
    public class ContactLinks : BasicLinks<ContactDto>
    {
        public ContactLinks(LinkGenerator linkGenerator) : base(linkGenerator) { }

        public override LinkedEntity<ContactDto> GenerateLinksForOneEntity(HttpContext httpContext, ContactDto entity)
        {
            var linkedContact = new LinkedEntity<ContactDto> { Value = entity };

            linkedContact.Links = new List<Link>
            {
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(ContactsController.GetContact), "Contacts", values : new {profileId = entity.ProfileId, contactId = entity.ContactId}),
                    rel: "self",
                    method: "GET"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(ContactsController.PutContact), "Contacts", values : new {profileId = entity.ProfileId, contactId = entity.ContactId}),
                    rel: "update_contact",
                    method: "PUT"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(ContactsController.DeleteContact), "Contacts", values : new {profileId = entity.ProfileId, contactId = entity.ContactId}),
                    rel: "delete_contact",
                    method: "DELETE"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(GiftsController.GetGifts), "Gifts", values : new {profileId = entity.ProfileId, contactId = entity.ContactId}),
                    rel: "self_gifts",
                    method: "GET"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(ProfilesController.GetProfile), "Profiles", values : new {id = entity.ProfileId}),
                    rel: "self_profile",
                    method: "GET"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(ContactsController.GetContacts), "Contacts", values : new {profileId = entity.ProfileId}),
                    rel: "other_contacts",
                    method: "GET"
                    )
            };

            return linkedContact;
        }
    }
}
