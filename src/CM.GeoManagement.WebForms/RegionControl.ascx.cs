using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CM.GeoManagement.BusinessEntities;

namespace CM.GeoManagement.WebForms
{
    public partial class RegionControl : System.Web.UI.UserControl
    {
        [Bindable(true)]
        public Region Region { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
     DataBind();
        }
    }
}