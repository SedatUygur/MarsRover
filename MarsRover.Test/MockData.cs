using MarsRover.Data.Constants;
using MarsRover.Data.Entities;
using System;
using System.Collections.Generic;

namespace MarsRover.Test
{
    public static class MockData
    {
        public static string[] UpperRightCoordinates = { "5", "5" };

        public static string[] RoverPosition = { "1", "2", "N" };

        public static string Instructions = "LMLMLMLMM";

        public static Coordinates Coordinates()
        {
            return new Coordinates
            {
                X = 1,
                Y = 2,
                Direction = Directions.N
            };
        }

        public static List<int> CoordinateLst => new List<int> { Convert.ToInt32(UpperRightCoordinates[0]), Convert.ToInt32(UpperRightCoordinates[1]) };
    }
}
