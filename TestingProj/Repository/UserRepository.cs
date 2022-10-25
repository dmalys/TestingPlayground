using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestingProj.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<object> _users;

        public UserRepository()
        {
            //connect to database and create client
        }

        public List<object> GetUsers()
        {
            // call to database

            //Some filtering
            //Some changes to structure of data

            return _users;
        }

        public int CountCurrentUsersWithName(string userName)
        {
            // call to database

            //Some filtering
            //Some changes to structure of data

            return 5;
        }

        public void InsertUser(object user)
        {
            _users.Add(user);
        }
    }
}
