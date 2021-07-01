using System;
using System.Collections.Generic;
using System.Text;
using CM.GeoManagement.Common;
using CM.GeoManagement.Repositories;

namespace CM.GeoManagement.BusinessEntities
{
    [Serializable]
    public class Country : Entity
    {

        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();

        public void AddRegion(Region region)
        {
            if (region.CountryCode != CountryCode)
                throw new GeoException("Region must belong to current country.");

            Regions.Add(region);
        }
    }
}
