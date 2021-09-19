using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Query.Sorting;
using BirthdayAPI.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context, ISortHelper<Note> sortHelper) : base(context, sortHelper) { }

        
        public async Task AddNote(Note newNote)
        {
            await base.Add(newNote);
        }

        public void EditNote(Note note)
        {
            base.Edit(note);
        }

        public async Task<Note> GetNoteById(int id)
        {
            return await base.GetById(id);
        }

        public async Task<IEnumerable<Note>> GetNotes(NoteParameters parameters)
        {
            IQueryable<Note> notes = _context.Notes;
            ReduceQueryByTitle(ref notes, parameters.Title);
            notes = _sortHelper.ApplySort(notes, parameters.OrderBy);
            return await base.GetPagedResult(notes, parameters);
        }

        public async Task<IEnumerable<Note>> GetNotesOfProfile(int profileId, NoteParameters parameters)
        {
            IQueryable<Note> notes = _context.Notes.Where(n => n.ProfileId == profileId);
            ReduceQueryByTitle(ref notes, parameters.Title);
            notes = _sortHelper.ApplySort(notes, parameters.OrderBy);
            return await base.GetPagedResult(notes, parameters);
        }

        public bool NoteWithIdExists(int noteId)
        {
            return _context.Notes.Any(n => n.NoteId == noteId);
        }

        public void RemoveNote(Note note)
        {
            base.Remove(note);
        }

        private void ReduceQueryByTitle(ref IQueryable<Note> notes, string title)
        {
            if (notes.Any() == false || string.IsNullOrWhiteSpace(title))
                return;

            notes = notes.Where(n => n.Title.ToLower().Contains(title.ToLower()));
        }
    }
}
