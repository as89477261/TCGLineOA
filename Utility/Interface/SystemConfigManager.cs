using System;
using System.Configuration;

namespace OIC_UTILITY.Interface
{
    public class SystemConfigManager : ISystemConfigManager
    {
        private SystemConfigManager()
        {
        }

        public static SystemConfigManager Instance => Nested.instance;

        public bool isByPassHash => throw new NotImplementedException();

        public string DefaultLanguage => "th-TH";

        public string DBConnectionString => ConfigurationManager.AppSettings[""];

        public string UploadFolderPath => throw new NotImplementedException();

        public bool IsConnectAD => ConfigurationManager.AppSettings["IsConnectAD"] == "yes" ? true : false;

        public string DefaultEmailUsername => throw new NotImplementedException();

        public string DefaultEmailPass => throw new NotImplementedException();

        public string SmtpServer => throw new NotImplementedException();

        public string SmtpPort => throw new NotImplementedException();

        public string SmtpUser => throw new NotImplementedException();

        public string SmtpPassword => throw new NotImplementedException();

        public string SmtpFrom => throw new NotImplementedException();

        public string DefaultRoleID => throw new NotImplementedException();

        public string EmailTitle => throw new NotImplementedException();

        public string EmailBody => throw new NotImplementedException();

        public string EmailForgotTitle => throw new NotImplementedException();

        public string EmailForgotBody => throw new NotImplementedException();

        public int LimitTimeSpanForChangePass => throw new NotImplementedException();

        public string DefaultImagePath => throw new NotImplementedException();

        private class Nested
        {
            internal static readonly SystemConfigManager instance = new SystemConfigManager();

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
        }
    }
}