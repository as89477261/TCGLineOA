using System.Data;
using System.Web;

namespace Utiltiy
{
    /// <summary>
    ///     Static Session facade class
    /// </summary>
    public static class SessionHelper
    {
        #region Private Static Member Variables

        private static HttpContext thisContext;

        #endregion

        #region Private Constants

        private const string uid = "uid";
        private const string projectId = "ProjectId";
        private const string province = "Province";

        #endregion

        #region Public Static Methods

        /// <summary>
        ///     Clears Session
        /// </summary>
        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        /// <summary>
        ///     Abandons Session
        /// </summary>
        public static void Abandon()
        {
            ClearSession();
            HttpContext.Current.Session.Abandon();
        }

        #endregion

        #region Public Static Properties

        /// <summary>
        ///     Gets/Sets Session for UserId
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
                return (DataTable)HttpContext.Current.Session[province];
            }
            set => HttpContext.Current.Session[province] = value;
        }

        public static string UID
        {
            get
            {
                if (HttpContext.Current.Session[uid] == null)
                    return "";
                return (string)HttpContext.Current.Session[uid];
            }
            set => HttpContext.Current.Session[uid] = value;
        }

        #endregion
    }
    //Use as: SessionHelper.UserId="user1";
    //        string user=SessionHelper.UserId;
    //        SessionHelper.Abandon();
}