using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebSite.Areas.Identity.Data;

public class ApplicationUser : IdentityUser
{
    public bool IsAdmin { get; set; }
}

