using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProj.Repository
{
    public class FinishedWorkRepository : IFinishedWorkRepository
    {
        public FinishedWorkRepository()
        {
            //connect to database and create client
        }

        public void NotifyFinishedWorkAsync(int currentUsersCount)
        {
            //async call to database
            
        }
    }
}
