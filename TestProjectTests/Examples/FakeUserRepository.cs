using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProj.Repository;

namespace TestProjectTests.Examples
{
    public class FakeUserRepository : IUserRepository
    {
        private List<object> _users = new List<object>();

        public List<object> GetUsers()
        {
            //NO call to database

            //Some filtering
            //Some changes to structure of data

            return _users;
        }

        public int CountCurrentUsersWithName(string userName)
        {
            //NO call to database
            var countOfUsersNamedDerek = 5;

            //Some filtering
            //Some changes to structure of data

            return countOfUsersNamedDerek;
        }

        public void InsertUser(object user)
        {
            _users.Add(user);
        }
    }
}
