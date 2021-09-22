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
    public class GiftLinks : BasicLinks<GiftDto>
    {
        public GiftLinks(LinkGenerator linkGenerator) : base(linkGenerator) { }

        public override LinkedEntity<GiftDto> GenerateLinksForOneEntity(HttpContext httpContext, GiftDto entity)
        {
            int profileId = int.Parse((string)httpContext.Request.RouteValues["profileId"]);

            var linkedGift = new LinkedEntity<GiftDto> { Value = entity };
            linkedGift.Links = new List<Link>
            {
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(GiftsController.GetGift), "Gifts", values : new {profileId = profileId, contactId = entity.ContactId, giftId = entity.GiftId}),
                    rel: "self",
                    method: "GET"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(GiftsController.PutGift), "Gifts", values : new {profileId = profileId, contactId = entity.ContactId, giftId = entity.GiftId}),
                    rel: "update_gift",
                    method: "PUT"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(GiftsController.DeleteGift), "Gifts", values : new {profileId = profileId, contactId = entity.ContactId, giftId = entity.GiftId}),
                    rel: "delete_gift",
                    method: "DELETE"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(ContactsController.GetContact), "Contacts", values : new {profileId = profileId, contactId = entity.ContactId}),
                    rel: "self_contact",
                    method: "GET"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(ProfilesController.GetProfile), "Profiles", values : new {id = profileId}),
                    rel: "self_profile",
                    method: "GET"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(GiftsController.GetGifts), "Gifts", values : new {profileId = profileId, contactId = entity.ContactId}),
                    rel: "other_gifts",
                    method: "GET"
                    ),
            };
            return linkedGift;
        }
    }
}
