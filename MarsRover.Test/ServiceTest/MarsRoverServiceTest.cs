using FakeItEasy;
using MarsRover.Data.Entities;
using MarsRover.Repository.Strategy;
using MarsRover.Service;
using MarsRover.Service.Strategy;
using MarsRover.Test;
using Xunit;

namespace MarsRover.Test.ServiceTest
{
    public class MarsRoverServiceTest
    {
        /// <summary>
        /// invoker object
        /// </summary>
        private readonly IInvoker _invoker;

        /// <summary>
        /// IMarsRoverService object
        /// </summary>
        private readonly IMarsRoverService _MarsRoverService;

        /// <summary>
        /// MarsRoverServiceTest Constructor
        /// </summary>
        public MarsRoverServiceTest()
        {
            _invoker = A.Fake<IInvoker>();
            _MarsRoverService = new MarsRoverService();
        }

        /// <summary>
        /// Test MoveRoverSync method
        /// </summary>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MoveRoverSyncTest(bool isNullCoordinate)
        {
            string[] uprigCoordinates = MockData.UpperRightCoordinates;
            string[] roverPosition = MockData.RoverPosition;
            string instructions = MockData.Instructions;
            Coordinates coordinates = MockData.Coordinates();
            if (!isNullCoordinate)
                A.CallTo(() => _invoker.StartMoving(A<ICommand>._, A<Coordinates>._)).ReturnsLazily(() => coordinates);
            else
                A.CallTo(() => _invoker.StartMoving(A<ICommand>._, A<Coordinates>._)).ReturnsLazily(() => null);

            Coordinates resultCoords = _MarsRoverService.MoveRoverSync(uprigCoordinates, roverPosition, instructions, _invoker);

            if (!isNullCoordinate)
            {
                Assert.NotNull(resultCoords);
                Assert.Equal(coordinates.X, resultCoords.X);
                Assert.Equal(coordinates.Y, resultCoords.Y);
                Assert.Equal(coordinates.Direction, resultCoords.Direction);
            }
            else
            {
                Assert.Null(resultCoords);
            }
        }
    }
}