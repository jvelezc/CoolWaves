using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CoolWaves.Data;

namespace CoolWaves.Models
{

    public class CustomUserStore :UserStore<ApplicationUser,ApplicationRole,ApplicationDbContext,int>
    {
        public CustomUserStore(ApplicationDbContext context) : base(context) { }
    }

}
