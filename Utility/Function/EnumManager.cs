using System.ComponentModel;

namespace OIC_UTILITY.Function
{
    public class EnumManager
    {
        public enum ActivityEnum
        {
            [Description("OpenPage")] OpenPage,
            [Description("Search")] Search,
            [Description("DownloadFile")] DownloadFile,
            [Description("Update")] Update
        }

        public enum CookieDatetimeType
        {
            Minute,
            Hour,
            Day,
            Month,
            Year
        }

        public enum RefType
        {
            [Description("CT01")] Objective,
            [Description("CT02")] Activity,
            [Description("CT03")] Department,
            [Description("CT04")] Division,
            [Description("CT05")] UserType,
            [Description("CT06")] UserLevel,
            [Description("CT07")] ISSUE,
            [Description("CT08")] AuditStatus,
            [Description("CT09")] FileStatus,
            [Description("CT10")] FollowType
        }
    }
}