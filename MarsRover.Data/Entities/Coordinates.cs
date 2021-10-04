using MarsRover.Data.Constants;

namespace MarsRover.Data.Entities
{
    public class Coordinates
    {
        /// <summary>
        /// X Coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y Coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Rover Direction
        /// </summary>
        public Directions Direction { get; set; }
    }
}
