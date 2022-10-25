using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProj.Repository;

namespace TestProjectTests.Examples
{
    class StubThrowingUserRepository : IUserRepository
    {
        public int CountCurrentUsersWithName(string userName)
        {
            throw new Exception();
        }

        public List<object> GetUsers()
        {
            throw new Exception();
        }

        public void InsertUser(object user)
        {
            throw new Exception();
        }
    }
}
