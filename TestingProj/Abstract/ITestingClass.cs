using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProj.Model;

namespace TestingProj.Abstract
{
    public interface ITestingClass
    {
        public void CountUsers(CountUsersRequst countUsersRequst);
    }
}
