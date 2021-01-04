using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Application.Commands.CreateTask;
using ToDo.Application.Repositories;
using ToDo.Domain.Accounts;
using Xunit;

namespace ToDo.UseCases.Tests
{
    public class AccountUseCaseTests
    {

        private readonly Mock<IAccountReadOnlyRepository> _accountReadOnlyRepositoryMock;

        private readonly Mock<IAccountWriteOnlyRepository> _accountWriteOnlyRepositoryMock;

        public AccountUseCaseTests()
        {
            _accountReadOnlyRepositoryMock = new Mock<IAccountReadOnlyRepository>();
            _accountWriteOnlyRepositoryMock = new Mock<IAccountWriteOnlyRepository>();

        }

        [Fact]
        public async Task Should_Create_New_Task()
        {
            var _createTaskUseCase = new CreateTaskUseCase(_accountReadOnlyRepositoryMock.Object, _accountWriteOnlyRepositoryMock.Object);
            Guid accountId = Guid.NewGuid();
            string task = "some task";
            DateTime taskDate = DateTime.Today;
            var account = Account.Load(
                    accountId,
                    Guid.NewGuid(),
                    new ToDoCollection()
                    );

            _accountReadOnlyRepositoryMock
                .Setup(x => x.Get(accountId))
                .ReturnsAsync(account);

            _accountWriteOnlyRepositoryMock
                .Setup(x => x.Update(account));

            await _createTaskUseCase.Execute(accountId, task, taskDate);

            _accountReadOnlyRepositoryMock.VerifyAll();
            _accountWriteOnlyRepositoryMock.VerifyAll();
        }
    }
}
