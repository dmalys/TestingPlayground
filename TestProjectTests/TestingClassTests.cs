using NUnit.Framework;
using System;
using TestingProj;
using TestingProj.Exceptions;
using TestingProj.Model;
using TestingProj.Repository;
using TestProjectTests.Examples;

namespace TestProjectTests
{
    [TestFixture]
    public class TestingClassTests
    {
        

        [SetUp]
        public void SetUp()
        {
            
        }

        [TestCase("asd")]
        [TestCase("Damian123")]
        public void CountUsers_WhenSuccessFull_DoesNotFailAsync(string userName)
        {
            //Arrange
            var countUsersRequest = new CountUsersRequst
            {
                UserName = userName
            };
            var finishedWorkRepository = new FinishedWorkRepository();
            var userRepository = new UserRepository();
            var sut = new TestingClass(userRepository, finishedWorkRepository);

            //Act && Assert
            Assert.DoesNotThrow(() => sut.CountUsers(countUsersRequest));

        }

        [TestCase(null)]
        [TestCase("")]
        public void CountUsers_WhenFailedValidation_ThrowsValidationException(string userName)
        {
            //Arrange
            var countUsersRequest = new CountUsersRequst
            {
                UserName = userName
            };

            var finishedWorkRepository = new FinishedWorkRepository();
            var userRepository = new UserRepository();
            var sut = new TestingClass(userRepository, finishedWorkRepository);

            //Act && Assert
            Assert.Throws<ValidationException>(() => sut.CountUsers(countUsersRequest));

        }

        [Test]
        public void CountUsers_WhenCountUsersCallFailed_()
        {
            //Arrange
            var countUsersRequest = new CountUsersRequst
            {
                UserName = "asd"
            };
            var finishedWorkRepository = new FinishedWorkRepository();
            var userRepository = new StubThrowingUserRepository();

            var sut = new TestingClass(userRepository, finishedWorkRepository);

            //Act && Assert
            Assert.Throws<Exception>(() => sut.CountUsers(countUsersRequest));
        }

        [Test]
        public void CountUsers_WhenNotifyFinishedWorkFailed_()
        {
            //Arrange
            var countUsersRequest = new CountUsersRequst
            {
                UserName = "asd"
            };

            var finishedWorkRepository = new StubThrowingFinishedWorkRepository();
            var userRepository = new UserRepository();
            var sut = new TestingClass(userRepository, finishedWorkRepository);

            //Act && Assert
            Assert.Throws<Exception>(() => sut.CountUsers(countUsersRequest));

        }
    }
}
