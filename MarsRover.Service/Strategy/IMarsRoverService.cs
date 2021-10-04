using MarsRover.Data.Entities;
using MarsRover.Repository.Strategy;

namespace MarsRover.Service.Strategy
{
    public interface IMarsRoverService
    {
        /// <summary>
        /// Rover movement interface method
        /// </summary>
        /// <param name="upperRightCoordinates"></param>
        /// <param name="roverPosition"></param>
        /// <param name="instructions"></param>
        /// <returns>Coordinates</returns>
        Coordinates MoveRoverSync(string[] upperRightCoordinates, string[] roverPosition, string instructions, IInvoker _invoker);
    }
}
