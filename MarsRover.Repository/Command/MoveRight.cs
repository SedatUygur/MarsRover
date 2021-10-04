using MarsRover.Data.Constants;
using MarsRover.Data.Entities;
using MarsRover.Repository.Strategy;

namespace MarsRover.Repository.Command
{
    public class MoveRight : ICommand
    {
        /// <summary>
        /// Execute right direction
        /// </summary>
        /// <returns></returns>
        public Coordinates Execute(Coordinates coordinates)
        {
            switch (coordinates.Direction)
            {
                case Directions.N:
                    coordinates.Direction = Directions.E;
                    break;

                case Directions.E:
                    coordinates.Direction = Directions.S;
                    break;

                case Directions.S:
                    coordinates.Direction = Directions.W;
                    break;

                case Directions.W:
                    coordinates.Direction = Directions.N;
                    break;
            }
            return coordinates;
        }
    }
}
