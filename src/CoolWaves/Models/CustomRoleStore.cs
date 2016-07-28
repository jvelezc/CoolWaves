using CoolWaves.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoolWaves.Models
{
    public class CustomRoleStore : RoleStore<ApplicationRole,ApplicationDbContext,int>
    {
        public CustomRoleStore(ApplicationDbContext context) : base(context) { }
    }
}
