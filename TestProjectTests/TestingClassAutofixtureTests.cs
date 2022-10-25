using AutoFixture;
using AutoFixture.AutoNSubstitute;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProj;
using TestingProj.Exceptions;
using TestingProj.Model;
using TestingProj.Repository;

namespace TestProjectTests
{
    [TestFixture]
    class TestingClassAutofixtureTests
    {
        private IFixture _fixture;
        private const string ValidUserName = "asd";

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        }

        [TestCase(ValidUserName)]
        [TestCase("Damian123")] //add some other signs to show that they are allowed in test
        public void CountUsers_WhenSuccessFull_DoesNotFailAsync(string userName)
        {
            //Arrange
            var countUsersRequest = _fixture.Build<CountUsersRequst>()
                .With(x => x.UserName, userName)
                .Create();

            var finishedWorkRepository = _fixture.Freeze<IFinishedWorkRepository>();
            var userRepository = _fixture.Freeze<IUserRepository>();
            var sut = _fixture.Create<TestingClass>();

            //Act && Assert
            Assert.DoesNotThrow(() => sut.CountUsers(countUsersRequest));

            finishedWorkRepository.Received(1).NotifyFinishedWorkAsync(Arg.Any<int>());
            userRepository.Received(1).CountCurrentUsersWithName(Arg.Any<string>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void CountUsers_WhenFailedValidation_ThrowsValidationException(string userName)
        {
            //Arrange
            var countUsersRequest = _fixture.Build<CountUsersRequst>()
                .With(x => x.UserName, userName)
                .Create();

            var finishedWorkRepository = _fixture.Freeze<IFinishedWorkRepository>();
            var userRepository = _fixture.Freeze<IUserRepository>();
            var sut = _fixture.Create<TestingClass>();

            //Act && Assert
            Assert.Throws<ValidationException>(() => sut.CountUsers(countUsersRequest));

            finishedWorkRepository.DidNotReceive().NotifyFinishedWorkAsync(Arg.Any<int>());
            userRepository.DidNotReceive().CountCurrentUsersWithName(Arg.Any<string>());
        }

        [Test]
        public void CountUsers_WhenCountUsersCallFailed_ThrowsException()
        {
            //Arrange
            var countUsersRequest = _fixture.Build<CountUsersRequst>()
                .With(x => x.UserName, ValidUserName)
                .Create();

            var finishedWorkRepository = _fixture.Freeze<IFinishedWorkRepository>();
            var userRepository = _fixture.Freeze<IUserRepository>();
            userRepository
                .When(x => x.CountCurrentUsersWithName(Arg.Any<string>()))
                .Throw<Exception>();
            var sut = _fixture.Create<TestingClass>();

            //Act && Assert
            Assert.Throws<Exception>(() => sut.CountUsers(countUsersRequest));

            finishedWorkRepository.DidNotReceive().NotifyFinishedWorkAsync(Arg.Any<int>());
            userRepository.Received().CountCurrentUsersWithName(Arg.Any<string>());
        }

        [Test]
        public void CountUsers_WhenNotifyFinishedWorkFailed_ThrowsException()
        {
            //Arrange
            var countUsersRequest = _fixture.Build<CountUsersRequst>()
                .With(x => x.UserName, ValidUserName)
                .Create();

            var finishedWorkRepository = _fixture.Freeze<IFinishedWorkRepository>();
            finishedWorkRepository
                .When(x => x.NotifyFinishedWorkAsync(Arg.Any<int>()))
                .Throw<Exception>(); 
            var userRepository = _fixture.Freeze<IUserRepository>();
            
            var sut = _fixture.Create<TestingClass>();

            //Act && Assert
            Assert.Throws<Exception>(() => sut.CountUsers(countUsersRequest));

            finishedWorkRepository.Received().NotifyFinishedWorkAsync(Arg.Any<int>());
            userRepository.Received().CountCurrentUsersWithName(Arg.Any<string>());

        }
    }
}
