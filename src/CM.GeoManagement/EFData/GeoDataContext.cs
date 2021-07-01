using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.GeoManagement.BusinessEntities;

namespace CM.GeoManagement.EFData
{
    public class GeoDataContext : DbContext
    {

        public GeoDataContext() : base(
            "Server=.\\sql2019;Database=Blaze;Trusted_Connection=True;"
            )
        {
            
        }

        public DbSet<Country> Countries { set; get; } = null;

        public DbSet<Region> Regions { set; get; } = null;
    }
}
