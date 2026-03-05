using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using BLL.Controller;
using BLL.Controller.FACenter;
using BLL.Controller.HealthCheck;
using BLL.Controller.NDID;
using CoreUtility;
using DataModel.Models.CustomerHealthModel;
using DataModel.Models.CustomerHealthModel.AppModel;
using DataModel.Models.CustomerHealthModel.EventsModel;
using DataModel.Models.FACenter;
using DataModel.Models.Line;
using DataModel.Models.SMEClinic;
using Newtonsoft.Json;
using Utiltiy;

namespace CustomerHealthCheck
{
    public partial class merchant_Scan_KM : BasePage
    {
        private string code = string.Empty;
        private bool isHasItem;
        private bool isHasProfile;
        private LineOAuthTokenModel lineInfo;
        private string state = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

    }
}