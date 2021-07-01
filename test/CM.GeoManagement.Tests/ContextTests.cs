using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.GeoManagement.EFData;
using Xunit;

namespace CM.GeoManagement.Tests
{
    public class ContextTests
    {

        [Fact]
        public void ShouldBeAbleCreateContext()
        {
            var context = new GeoDataContext();

            Assert.NotNull(context.Countries);

            Assert.NotNull(context.Regions);
        }

    }
}
