using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services.Abstractions
{
    public interface IServiceManager
    {
        IAccountService AccountService { get; }
        IProfileService ProfileService { get; }
        IContactService ContactService { get; }
    }
}
