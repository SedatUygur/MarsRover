using MarsRover.Data.Entities;
using MarsRover.Repository.Strategy;

namespace MarsRover.Repository.Invoker
{
    public class ExecuteAction : IInvoker
    {
        /// <summary>
        /// Start movement
        /// </summary>
        /// <param name="command"></param>
        /// <param name="coordinates"></param>
        /// <returns>Coordinates</returns>
        public Coordinates StartMoving(ICommand command, Coordinates coordinates)
        {
            return command.Execute(coordinates);
        }
    }
}
