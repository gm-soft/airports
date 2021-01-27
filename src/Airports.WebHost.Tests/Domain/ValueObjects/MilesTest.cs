using System;
using Airports.WebHost.Domain.ValueObjects;
using Xunit;

namespace Airports.WebHost.Tests.Domain.ValueObjects
{
    public class MilesTest
    {
        [Theory]
        [InlineData(1000, 0.6213712)]
        [InlineData(1, 0.0006213712)]
        [InlineData(0, 0)]
        public void Meters_Positive_Ok(double meters, double expected)
        {
            var target = new Miles(meters);
            Assert.Equal(expected, target.Value);
        }

        [Fact]
        public void Meters_Positive_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Miles(-1));
        }
    }
}