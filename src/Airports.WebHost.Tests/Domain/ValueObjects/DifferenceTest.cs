using Airports.WebHost.Domain.ValueObjects;
using Xunit;

namespace Airports.WebHost.Tests.Domain.ValueObjects
{
    public class DifferenceTest
    {
        [Fact]
        public void Meters_TwoDifferentCities_Ok()
        {
            var ams = new Location(52.309069, 4.763385);
            var almaty = new Location(43.346652, 77.011455);

            var target = new Difference(ams, almaty);

            Assert.Equal(5259077.56, target.Meters);
            Assert.Equal(3267.84, target.Miles);
        }

        [Fact]
        public void Meters_SameLocations_Zero()
        {
            var ams = new Location(52.309069, 4.763385);

            var target = new Difference(ams, ams);

            Assert.Equal(0, target.Meters);
            Assert.Equal(0, target.Miles);
        }
    }
}
