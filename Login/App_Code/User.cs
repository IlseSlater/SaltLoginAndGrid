using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridAndSalt
{
    public class User
    {   
        public string UserId { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
