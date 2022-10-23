
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class ApiUser:IdentityUser
    { 
        //override IdentityUser table and add this fields to it
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
