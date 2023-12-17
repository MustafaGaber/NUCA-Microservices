﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NUCA.Identity.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace NUCA.Identity.Core
{
    public class ApplicationUserStore : UserStore<User>
    {
        public ApplicationUserStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }

        public override Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            return Context.Set<User>()
                .Include(u => u.Enrollments)
                .ThenInclude(e => e.Department)
                .ThenInclude(d => d.Roles)
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        }
   
    }
}
