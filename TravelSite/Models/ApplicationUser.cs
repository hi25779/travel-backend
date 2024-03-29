﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TravelSite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }


        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
        //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        //public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        //public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
    }
}
