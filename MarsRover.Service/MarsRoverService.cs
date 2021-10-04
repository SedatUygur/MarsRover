using MarsRover.Data.Constants;
using MarsRover.Data.Entities;
using MarsRover.Repository.Command;
using MarsRover.Repository.Strategy;
using MarsRover.Service.Strategy;
using System;
using System.Collections.Generic;

namespace MarsRover.Service
{
    public class MarsRoverService : IMarsRoverService
    {
        /// <summary>
        /// Move rover synchronously
        /// </summary>
        /// <param name="upperRightCoordinates"></param>
        /// <param name="roverPosition"></param>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public Coordinates MoveRoverSync(string[] upperRightCoordinates, string[] roverPosition, string instructions, IInvoker _invoker)
        {
            List<int> coordinateLst = new List<int>();
            foreach (string coordinate in upperRightCoordinates)
            {
                int coordinateItem = Convert.ToInt32(coordinate);
                coordinateLst.Add(coordinateItem);
            }
            Coordinates coordinates = new Coordinates();
            coordinates.X = Convert.ToInt32(roverPosition[0]);
            coordinates.Y = Convert.ToInt32(roverPosition[1]);
            coordinates.Direction = roverPosition[2].ToEnumVal<Directions>();
            ICommand command;

            foreach (char instruction in instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        command = new MoveLeft();
                        break;

                    case 'R':
                        command = new MoveRight();
                        break;

                    case 'M':
                        command = new MoveForward(coordinateLst);
                        break;

                    default:
                        return null;
                }
                Coordinates coord = _invoker.StartMoving(command, coordinates);
                
                if (coord == null)
                    return null;

                coordinates.Direction = coord.Direction;
                coordinates.X = coord.X;
                coordinates.Y = coord.Y;
            }
            return coordinates;
        }
    }
}
