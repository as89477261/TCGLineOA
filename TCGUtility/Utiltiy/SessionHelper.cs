using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCGUtility.Utiltiy
{
    using System.Data;
    using System.Web;
    /// <summary>
    /// Static Session facade class
    /// </summary>
    public static class SessionHelper
    {
        #region Private Constants
        private const string userId = "UserId";
        private const string projectId = "ProjectId";
        private const string province = "Province";
        #endregion
        #region Private Static Member Variables
        private static HttpContext thisContext;
        #endregion
        #region Public Static Methods
        /// <summary>
        /// Clears Session
        /// </summary>
        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }
        /// <summary>
        /// Abandons Session
        /// </summary>
        public static void Abandon()
        {
            ClearSession();
            HttpContext.Current.Session.Abandon();
        }
        #endregion
        #region Public Static Properties
        /// <summary>
        /// Gets/Sets Session for UserId
        /// </summary>
        //public static string UserId
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[userId] == null)
        //            return "";
        //        else
        //            return HttpContext.Current.Session[userId].ToString();
        //    }
        //    set { HttpContext.Current.Session[userId] = value; }
        //}
        //public static string ProjectId
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[projectId] == null)
        //            return "";
        //        else
        //            return HttpContext.Current.Session[projectId].ToString();
        //    }
        //    set { HttpContext.Current.Session[projectId] = value; }
        //}

        public static DataTable Province
        {
            get
            {
                if (HttpContext.Current.Session[province] == null)
                    return null;
                else
                    return (DataTable)HttpContext.Current.Session[province];
            }
            set { HttpContext.Current.Session[province] = value; }
        }
        #endregion
    }
    //Use as: SessionHelper.UserId="user1";
    //        string user=SessionHelper.UserId;
    //        SessionHelper.Abandon();
}
