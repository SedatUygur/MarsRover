using MarsRover.Data.Entities;

namespace MarsRover.Repository.Strategy
{
    public interface ICommand
    {
        /// <summary>
        /// Execute movement
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>Coordinates</returns>
        public Coordinates Execute(Coordinates coordinates);
    }
}
