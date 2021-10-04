using MarsRover.Data.Entities;

namespace MarsRover.Repository.Strategy
{
    public interface IInvoker
    {
        /// <summary>
        /// Start movement
        /// </summary>
        /// <param name="command"></param>
        /// <param name="coordinates"></param>
        /// <returns>Coordinates</returns>
        Coordinates StartMoving(ICommand command, Coordinates coordinates);
    }
}
