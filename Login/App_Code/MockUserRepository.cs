using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridAndSalt
{
    public class DBUserRepository
    {
        List<User> users = new List<User>();

        // Function to add the user to im memory dummy DB
        public void AddUser(User user)
        {
            users.Add(user);
        }

        // Function to retrieve the user based on user id
        public User GetUser(string userid)
        {
            return users.Single(u => u.UserId == userid);
        }
    }
}
