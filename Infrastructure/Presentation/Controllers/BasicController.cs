using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayAPI.Core.Service.Services.Abstractions;
using BirthdayAPI.Infrastructure.LinkResources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BirthdayAPI.Infrastructure.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BasicController : ControllerBase
    {
        protected readonly IServiceManager _service;

        // TODO: zmenit
        protected LinksCreator _linksCreator;
        protected LinkGenerator _linksGenerator;

        public BasicController(IServiceManager service, LinksCreator linksCreator)
        {
            _service = service;
            _linksCreator = linksCreator;
        }
    }
}