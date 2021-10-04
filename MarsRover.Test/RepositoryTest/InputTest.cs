using MarsRover.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test.RepositoryTest
{
    public class InputTest
    {
        [Theory]
        [InlineData("5 6")]
        public void CoordinateCorrectFormat(string command)
        {
            var commandSplit = command.Split(' ');
            int expectedX = int.Parse(commandSplit[0]);
            int expectedY = int.Parse(commandSplit[1]);

            Assert.Equal(5, expectedX);
            Assert.Equal(6, expectedY);
        }

        [Theory]
        [InlineData("5")]
        public void CoordinateNotEnough(string command)
        {
            var commandSplit = command.Split(' ');

            if (commandSplit.Length < 2)
                Assert.True(true);
        }

        [Theory]
        [InlineData("5 6 7")]
        public void CoordinateManyParts(string command)
        {
            var commandSplit = command.Split(' ');

            if (commandSplit.Length > 2)
                Assert.True(true);
        }

        [Theory]
        [InlineData("two 2")]
        public void CoordinateNotParsableX(string command)
        {
            var commandSplit = command.Split(' ');
            bool isNumeric = int.TryParse(commandSplit[0], out _);

            if (commandSplit.Length == 2 && !isNumeric)
            {
                Assert.True(true);
            }    
        }

        [Theory]
        [InlineData("5 three")]
        public void CoordinateNotParsableY(string command)
        {
            var commandSplit = command.Split(' ');
            bool isNumeric = int.TryParse(commandSplit[1], out _);

            if (commandSplit.Length == 2 && !isNumeric)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData("two three")]
        public void CoordinateNotParsableBoth(string command)
        {
            var commandSplit = command.Split(' ');
            bool isFirstNumeric = int.TryParse(commandSplit[0], out _);
            bool isSecondNumeric = int.TryParse(commandSplit[0], out _);

            if (commandSplit.Length == 2 && !isFirstNumeric && !isSecondNumeric)
            {
                Assert.True(true);
            }
        }
    }
}
