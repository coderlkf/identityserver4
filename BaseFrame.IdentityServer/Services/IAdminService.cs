using BaseFrame.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseFrame.IdentityServer.Services
{
    public interface IAdminService
    {
        Task<Admin> GetByStr(string username, string pwd);
    }
}
