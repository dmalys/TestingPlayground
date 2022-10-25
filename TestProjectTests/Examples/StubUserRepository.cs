using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProj.Repository;

namespace TestProjectTests.Examples
{
    public class StubUserRepository : IUserRepository
    {
        public List<object> GetUsers()
        {
            //NO call to database

            //And return value
            return new List<object>();
        }

        public int CountCurrentUsersWithName(string userName)
        {
            //NO call to database

            return 0;
        }

        public void InsertUser(object user)
        {
            //NOTHING HERE
        }
    }
}
