using MarsRover.Data.Entities;
using MarsRover.Repository.Invoker;
using MarsRover.Repository.Strategy;
using MarsRover.Service;
using MarsRover.Service.Strategy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string[] upperRightCoordinates = Console.ReadLine().Split(' ');
            bool isRunning = true;
            List<string> expectedOutputs = new List<string>();

            while (isRunning)
            {
                string[] roverPosition = Console.ReadLine().Split(' ');
                string instructions = Console.ReadLine();

                var services = new ServiceCollection();
                services.AddSingleton<IMarsRoverService, MarsRoverService>();
                services.AddSingleton<IInvoker, ExecuteAction>();
                ServiceProvider _serviceProvider = services.BuildServiceProvider(true);
                IMarsRoverService _marsRoverService = _serviceProvider.GetService<IMarsRoverService>();
                IInvoker _invoker = _serviceProvider.GetService<IInvoker>();

                Coordinates coordinates = _marsRoverService.MoveRoverSync(upperRightCoordinates, roverPosition, instructions, _invoker);
                if (coordinates != null)
                    //Console.WriteLine(coordinates.X + " " + coordinates.Y + " " + coordinates.Direction);
                    expectedOutputs.Add(coordinates.X + " " + coordinates.Y + " " + coordinates.Direction);
                else
                    Console.WriteLine("Bad Command");

                isRunning = ContinueMoving();
                if (!isRunning)
                {
                    DisposeServices(_serviceProvider);
                }
            }

            foreach (string output in expectedOutputs)
            {
                Console.WriteLine(output);
            }
        }

        /// <summary>
        /// Dispose Services
        /// </summary>
        /// <param name="_serviceProvider"></param>
        private static void DisposeServices(ServiceProvider _serviceProvider)
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        public static bool ContinueMoving()
        {
            Console.Write("Continue? y/n");

            string continueAnswer = Console.ReadLine();

            string[] correctAnswers = { "Y", "N", "y", "n" };

            if (!correctAnswers.Contains(continueAnswer))
            {
                Console.WriteLine("Incorrect answer.Try again.");
                return ContinueMoving();
            }

            else if (continueAnswer == "Y" || continueAnswer == "y")
                return true;

            else if (continueAnswer == "N" || continueAnswer == "n")
                return false;

            return false;
        }
    }
}
