using MarsRover.Data.Constants;
using MarsRover.Data.Entities;
using MarsRover.Repository.Strategy;

namespace MarsRover.Repository.Command
{
    public class MoveLeft : ICommand
    {
        /// <summary>
        /// Execute left direction
        /// </summary>
        /// <returns>Coordinates</returns>
        public Coordinates Execute(Coordinates coordinates)
        {
            switch (coordinates.Direction)
            {
                case Directions.N:
                    coordinates.Direction = Directions.W;
                    break;

                case Directions.E:
                    coordinates.Direction = Directions.N;
                    break;

                case Directions.S:
                    coordinates.Direction = Directions.E;
                    break;

                case Directions.W:
                    coordinates.Direction = Directions.S;
                    break;
            }
            return coordinates;
        }
    }
}
