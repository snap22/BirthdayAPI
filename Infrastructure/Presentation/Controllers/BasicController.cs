using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayAPI.Core.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayAPI.Infrastructure.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BasicController : ControllerBase
    {
        protected readonly IServiceManager _service;

        public BasicController(IServiceManager service)
        {
            _service = service;
        }
    }
}