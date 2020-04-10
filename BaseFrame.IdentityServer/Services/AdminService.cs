using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseFrame.IdentityServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseFrame.IdentityServer.Services
{
    public class AdminService : IAdminService
    {
        public EFContext db;
        public AdminService(EFContext _efcontext)
        {
            db = _efcontext;
        }
        public async Task<Admin> GetByStr(string username, string pwd)
        {
            Admin m = await db.Admin.Where(a => a.UserName == username && a.Password == pwd).SingleOrDefaultAsync();
            return m ?? null;
        }
    }
}
