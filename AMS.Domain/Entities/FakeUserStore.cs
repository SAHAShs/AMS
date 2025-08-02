using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.Entities
{
    public class FakeUserStore
    {
        public static List<AppUser> Users = new()
    {
        new AppUser { Id = 1, Username = "admin", Password = "123", Role = "Admin" },
        new AppUser { Id = 2, Username = "user", Password = "456", Role = "User" }
    };
    }
}
