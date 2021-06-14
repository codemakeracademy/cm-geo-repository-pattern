using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace CM.GeoManagement.Repositories
{
    public abstract class BaseRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Server=.\\sql2019;Database=Blaze;Trusted_Connection=True;");
        }
    }
}
