using System;
using System.Threading.Tasks;
using TestingProj.Model;
using TestingProj.Repository;

namespace TestingProj
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();
            var finishedWorkRepository = new FinishedWorkRepository();

            var testingClass = new TestingClass(userRepository, finishedWorkRepository);
            var countToFiveRequest = new CountUsersRequst
            {
                UserName = "asd"
            };

            testingClass.CountUsers(countToFiveRequest);

            Console.WriteLine("Hello World!");
        }
    }
}
