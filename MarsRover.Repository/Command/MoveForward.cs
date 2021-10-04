using MarsRover.Data.Constants;
using MarsRover.Data.Entities;
using MarsRover.Repository.Strategy;
using System;
using System.Collections.Generic;

namespace MarsRover.Repository.Command
{
    public class MoveForward : ICommand
    {
        /// <summary>
        /// Maximum limit of rover
        /// </summary>
        private readonly List<int> maxRoverLimit;

        /// <summary>
        /// MoveForward Constructor
        /// </summary>
        /// <param name="maxRoverLimit"></param>
        public MoveForward(List<int> maxRoverLimit)
        {
            this.maxRoverLimit = maxRoverLimit;
        }

        /// <summary>
        /// Execute movement
        /// </summary>
        /// <returns>Coordinates</returns>
        public Coordinates Execute(Coordinates coordinates)
        {
            switch (coordinates.Direction)
            {
                case Directions.N:
                    if (coordinates.Y >= maxRoverLimit[1])
                        coordinates = RoverWontStartMoving();
                    else
                        coordinates.Y += 1;
                    break;

                case Directions.W:
                    if (coordinates.X != 0)
                        coordinates.X -= 1;
                    else
                        coordinates = RoverWontStartMoving();
                    break;

                case Directions.E:
                    if (coordinates.X >= maxRoverLimit[0])
                        coordinates = RoverWontStartMoving();
                    else
                        coordinates.X += 1;
                    break;

                case Directions.S:
                    if (coordinates.Y != 0)
                        coordinates.Y -= 1;
                    else
                        coordinates = RoverWontStartMoving();
                    break;
            }
            return coordinates;
        }

        /// <summary>
        /// Second rover won't start moving info
        /// </summary>
        private Coordinates RoverWontStartMoving()
        {
            Console.WriteLine("Won't Start Moving");
            return null;
        }
    }
}
