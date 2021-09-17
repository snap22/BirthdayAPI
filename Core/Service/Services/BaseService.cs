using AutoMapper;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services
{
    public class BaseService
    {
        protected readonly IRepositoryManager _repository;
        protected readonly IMapper _mapper;
        public BaseService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
