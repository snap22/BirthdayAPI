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
    public class ProfileLinks : BasicLinks<ProfileDto>
    {
        public ProfileLinks(LinkGenerator linkGenerator) : base(linkGenerator) { }

        public override LinkedEntity<ProfileDto> GenerateLinksForOneEntity(HttpContext httpContext, ProfileDto entity)
        {
            var linkedProfile = new LinkedEntity<ProfileDto> { Value = entity };

            linkedProfile.Links = new List<Link>
            {
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, nameof(ProfilesController.GetProfile), "Profiles", values: new { id = entity.ProfileId }), "self", "GET"),
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, action : nameof(ProfilesController.PutProfile), controller: "Profiles", values: new {id = entity.ProfileId }), "update_profile", "PUT"),
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, nameof(ProfilesController.DeleteProfile), "Profiles", values: new { id = entity.ProfileId }), "delete_profile", "DELETE"),
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, nameof(AccountsController.GetAccount), "Accounts", values: new { id = entity.AccountId }), "self_account", "GET"),
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, nameof(NotesController.GetNotes), "Notes", values: new { profileId = entity.ProfileId }), "self_notes", "GET"),
                new Link(
                    _linkGenerator.GetUriByAction(httpContext, nameof(ContactsController.GetContacts), "Contacts", values: new { profileId = entity.ProfileId }), "self_contacts", "GET")
            };
            return linkedProfile;
        }
    }
}
