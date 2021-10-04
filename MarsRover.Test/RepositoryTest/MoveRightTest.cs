using MarsRover.Data.Constants;
using MarsRover.Data.Entities;
using MarsRover.Repository.Command;
using MarsRover.Repository.Strategy;
using Xunit;

namespace MarsRover.Test.RepositoryTest
{
    public class MoveRightTest
    {
        /// <summary>
        /// command object
        /// </summary>
        private readonly ICommand _command;

        /// <summary>
        /// MoveRightTest Constructor
        /// </summary>
        public MoveRightTest()
        {
            _command = new MoveRight();
        }

        /// <summary>
        /// Test Execute method
        /// </summary>
        /// <param name="directions"></param>
        [Theory]
        [InlineData(Directions.N)]
        [InlineData(Directions.W)]
        [InlineData(Directions.E)]
        [InlineData(Directions.S)]
        public void Execute_Test(Directions directions)
        {
            //Arrange
            Coordinates coordinates = MockData.Coordinates();
            switch (directions)
            {
                case Directions.N:
                    coordinates.Direction = Directions.N;
                    break;

                case Directions.W:
                    coordinates.Direction = Directions.W;
                    break;

                case Directions.E:
                    coordinates.Direction = Directions.E;
                    break;

                case Directions.S:
                    coordinates.Direction = Directions.S;
                    break;
            }

            //Act
            Coordinates resultCoords = _command.Execute(coordinates);

            //Assert
            Assert.NotNull(resultCoords);
            Assert.Equal(coordinates, resultCoords);
        }
    }
}
