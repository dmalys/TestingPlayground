using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestingProj.Repository
{
    public interface IUserRepository
    {
        public List<object> GetUsers();
        public int CountCurrentUsersWithName(string userName);
        public void InsertUser(object user);
    }
}