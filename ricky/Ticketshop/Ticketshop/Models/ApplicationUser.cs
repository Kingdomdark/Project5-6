using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Ticketshop.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    [Authorize("Admin")]
    public class ApplicationUser : IdentityUser
    {
    }
}
