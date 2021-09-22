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
    public class NoteLinks : BasicLinks<NoteDto>
    {
        public NoteLinks(LinkGenerator linkGenerator) : base(linkGenerator) { }

        public override LinkedEntity<NoteDto> GenerateLinksForOneEntity(HttpContext httpContext, NoteDto entity)
        {
            var linkedNote = new LinkedEntity<NoteDto> { Value = entity };
            linkedNote.Links = new List<Link>
            {
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(NotesController.GetNote), "Notes", values : new {profileId = entity.ProfileId, noteId = entity.NoteId}),
                    rel: "self",
                    method: "GET"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(NotesController.PutNote), "Notes", values : new {profileId = entity.ProfileId, noteId = entity.NoteId}),
                    rel: "update_note",
                    method: "PUT"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(NotesController.DeleteNote), "Notes", values : new {profileId = entity.ProfileId, noteId = entity.NoteId}),
                    rel: "delete_note",
                    method: "DELETE"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(ProfilesController.GetProfile), "Profiles", values : new {id = entity.ProfileId}),
                    rel: "self_profile",
                    method: "GET"
                    ),
                new Link(
                    href: _linkGenerator.GetUriByAction(httpContext, nameof(NotesController.GetNotes), "Notes", values : new {profileId = entity.ProfileId}),
                    rel: "other_notes",
                    method: "GET"
                    ),
            };
            return linkedNote;
        }
    }
}
