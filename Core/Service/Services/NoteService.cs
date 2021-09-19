using AutoMapper;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
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

        public Task<NoteDto> CreateNote(int profileId, NoteDto Note)
        {
            throw new NotImplementedException();
        }

        public Task<NoteDto> GetNote(int profileId, int noteId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoteDto>> GetNotes(int profileId, NoteParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<NoteDto> RemoveNote(int profileId, int noteId)
        {
            throw new NotImplementedException();
        }

        public Task<NoteDto> UpdateNote(int profileId, int noteId, NoteDto Note)
        {
            throw new NotImplementedException();
        }
    }
}
