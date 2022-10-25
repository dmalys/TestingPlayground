using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProj.Repository;

namespace TestProjectTests.Examples
{
    public class StubThrowingFinishedWorkRepository : IFinishedWorkRepository
    {
        public void NotifyFinishedWorkAsync(int currentUsersCount)
        {
            throw new Exception();
        }
    }
}
