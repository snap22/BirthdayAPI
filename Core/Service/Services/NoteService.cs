using AutoMapper;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Domain.Exceptions;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services
{
    public class NoteService : BaseService, INoteService
    {
        public NoteService(IRepositoryManager repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<NoteDto> CreateNote(int profileId, NoteDto note)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            note.ProfileId = profileId;

            var newNote = _mapper.Map<Note>(note);
            await _repository.NoteRepository.AddNote(newNote);
            await _repository.UnitOfWork.CompleteAsync();

            return note;
        }

        public async Task<NoteDto> GetNote(int profileId, int noteId)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfNoteDoesntExist(noteId);

            var foundNote = await _repository.NoteRepository.GetNoteById(noteId);
            base.ThrowErrorIfProfilesNotTheSame(foundNote.ProfileId, profileId);
            return _mapper.Map<NoteDto>(foundNote);
        }

        public async Task<IEnumerable<NoteDto>> GetNotes(int profileId, NoteParameters parameters)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            var foundNotes = await _repository.NoteRepository.GetNotesOfProfile(profileId, parameters);
            return _mapper.Map<IEnumerable<NoteDto>>(foundNotes);
        }

        public async Task<NoteDto> RemoveNote(int profileId, int noteId)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfNoteDoesntExist(noteId);

            var foundNote = await _repository.NoteRepository.GetNoteById(noteId);
            base.ThrowErrorIfProfilesNotTheSame(foundNote.ProfileId, profileId);

            _repository.NoteRepository.RemoveNote(foundNote);
            await _repository.UnitOfWork.CompleteAsync();
            
            return _mapper.Map<NoteDto>(foundNote);
        }

        public async Task<NoteDto> UpdateNote(int profileId, int noteId, NoteDto Note)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfNoteDoesntExist(noteId);

            var foundNote = await _repository.NoteRepository.GetNoteById(noteId);
            base.ThrowErrorIfProfilesNotTheSame(foundNote.ProfileId, profileId);

            if (foundNote.ProfileId != Note.ProfileId)
                throw new BadRequestException("Cannot change the profile of notes!");

            _mapper.Map(Note, foundNote);
            _repository.NoteRepository.EditNote(foundNote);
            await _repository.UnitOfWork.CompleteAsync();

            return _mapper.Map<NoteDto>(foundNote);
        }
    }
}
