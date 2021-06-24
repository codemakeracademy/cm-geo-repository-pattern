using System;
using System.Collections.Generic;
using System.Text;
using CM.GeoManagement.Repositories;

namespace CM.GeoManagement.BusinessEntities
{
    [Serializable]
    public class Region : Entity
    {
        public string RegionCode { get; set; }
        public string CountryCode { get; set; }
        public string RegionName { get; set; }
    }
}
