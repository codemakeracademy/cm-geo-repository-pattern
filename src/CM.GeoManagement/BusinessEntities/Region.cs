using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CM.GeoManagement.Repositories;

namespace CM.GeoManagement.BusinessEntities
{
    [Serializable]
    public class Region : Entity
    {
        [Key, Column(Order = 0)]
        public string RegionCode { get; set; }
        [Key, Column(Order = 1)]
        public string CountryCode { get; set; }

        public string RegionName { get; set; }
    }
}
