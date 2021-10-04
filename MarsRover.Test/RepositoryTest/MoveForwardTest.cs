using MarsRover.Data.Constants;
using MarsRover.Data.Entities;
using MarsRover.Repository.Command;
using MarsRover.Repository.Strategy;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Test.RepositoryTest
{
    public class MoveForwardTest
    {
        /// <summary>
        /// command object
        /// </summary>
        private readonly ICommand _command;

        /// <summary>
        /// coordinate list
        /// </summary>
        private readonly List<int> _coordinateLst;

        /// <summary>
        /// MoveForwardTest Constructor
        /// </summary>
        public MoveForwardTest()
        {
            _coordinateLst = MockData.CoordinateLst;
            _command = new MoveForward(_coordinateLst);
        }

        /// <summary>
        /// Execute Direction Test
        /// </summary>
        /// <param name="directions"></param>
        [Theory]
        [InlineData(Directions.N)]
        [InlineData(Directions.W)]
        [InlineData(Directions.E)]
        [InlineData(Directions.S)]
        public void ExecuteTest(Directions directions)
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
            Coordinates resultCoord = _command.Execute(coordinates);

            //Assert
            Assert.NotNull(resultCoord);
            Assert.Equal(coordinates, resultCoord);
        }

        /// <summary>
        /// Execute Failure Test
        /// </summary>
        /// <param name="isYUpperLimit"></param>
        /// <param name="isXUpperLimit"></param>
        /// <param name="isYLowerLimit"></param>
        /// <param name="isXLowerLimit"></param>
        [Theory]
        [InlineData(true, false, false, false)]
        [InlineData(false, true, false, false)]
        [InlineData(false, false, true, false)]
        [InlineData(false, false, false, true)]
        [InlineData(true, true, false, false)]
        [InlineData(false, true, true, false)]
        [InlineData(false, false, true, true)]
        public void ExecuteTestFail(bool isYUpperLimit, bool isXUpperLimit, bool isYLowerLimit, bool isXLowerLimit)
        {
            Coordinates coordinates = MockData.Coordinates();
            if (isYUpperLimit)
            {
                coordinates.Y = 6;
                coordinates.Direction = Directions.N;
            }
            else if (isXUpperLimit)
            {
                coordinates.X = 6;
                coordinates.Direction = Directions.E;
            }
            else if (isYLowerLimit)
            {
                coordinates.Y = 0;
                coordinates.Direction = Directions.S;
            }
            else if (isXLowerLimit)
            {
                coordinates.X = 0;
                coordinates.Direction = Directions.W;
            }

            Coordinates resultCoords = _command.Execute(coordinates);

            Assert.Null(resultCoords);
        }
    }
}
