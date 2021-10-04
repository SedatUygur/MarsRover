using FakeItEasy;
using MarsRover.Data.Entities;
using MarsRover.Repository.Invoker;
using MarsRover.Repository.Strategy;
using Xunit;

namespace MarsRover.Test.RepositoryTest
{
    public class ExecuteActionTest
    {
        /// <summary>
        /// Command object
        /// </summary>
        private readonly ICommand _command;

        /// <summary>
        /// IInvoker object
        /// </summary>
        private readonly IInvoker _invoker;

        /// <summary>
        /// ExecuteActionTest Constructor
        /// </summary>
        public ExecuteActionTest()
        {
            _command = A.Fake<ICommand>();
            _invoker = new ExecuteAction();
        }

        /// <summary>
        /// StartMovingSync Test
        /// </summary>
        [Fact]
        public void StartMovingTest()
        {
            //Arrange
            Coordinates coordinates = MockData.Coordinates();
            A.CallTo(() => _command.Execute(A<Coordinates>._)).ReturnsLazily(() => coordinates);

            //Act
            Coordinates startCoord = _invoker.StartMoving(_command, coordinates);

            //Assert
            Assert.NotNull(startCoord);
            Assert.Equal(startCoord, coordinates);
        }
    }
}
