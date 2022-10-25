using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProj.Abstract;
using TestingProj.Exceptions;
using TestingProj.Model;
using TestingProj.Repository;

namespace TestingProj
{
    public class TestingClass : ITestingClass
    {
        private readonly IUserRepository _countingRepository;
        private readonly IFinishedWorkRepository _finishedWorkRepository;

        public TestingClass(
            IUserRepository countingRepository,
            IFinishedWorkRepository finishedWorkRepository
            )
        {
            _countingRepository = countingRepository;
            _finishedWorkRepository = finishedWorkRepository;
        }

        public void CountUsers(CountUsersRequst countUsersRequst)
        {
            ValidateRequest(countUsersRequst);

            try
            {
                var currentUsersCount = _countingRepository.CountCurrentUsersWithName(countUsersRequst.UserName);

                _finishedWorkRepository.NotifyFinishedWorkAsync(currentUsersCount);
            }
            catch (Exception ex)
            {
                throw new Exception("Database failed here.", ex);
            }
        }

        private void ValidateRequest(CountUsersRequst countToFiveRequest)
        {
            if (string.IsNullOrWhiteSpace(countToFiveRequest?.UserName))
            {
                throw new ValidationException("ValidationException here with custom message.");
            }
        }
    }
}
