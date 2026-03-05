public interface ISystemConfigManager
{
    bool isByPassHash { get; }

    string DefaultLanguage { get; }

    string DBConnectionString { get; }

    string UploadFolderPath { get; }

    bool IsConnectAD { get; }

    string DefaultEmailUsername { get; }

    string DefaultEmailPass { get; }

    string SmtpServer { get; }

    string SmtpPort { get; }

    string SmtpUser { get; }

    string SmtpPassword { get; }

    string SmtpFrom { get; }

    string DefaultRoleID { get; }

    string EmailTitle { get; }

    string EmailBody { get; }

    string EmailForgotTitle { get; }

    string EmailForgotBody { get; }

    int LimitTimeSpanForChangePass { get; }

    string DefaultImagePath { get; }
}