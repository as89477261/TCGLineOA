using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.PDPA.Authentication
{
    public class PDPAResponseToken
    {
        public Result result { get; set; }
        public object targetUrl { get; set; }
        public bool success { get; set; }
        public object error { get; set; }
        public bool unAuthorizedRequest { get; set; }
        public bool __abp { get; set; }
    }

    public class Result
    {
        public string accessToken { get; set; }
        public string encryptedAccessToken { get; set; }
        public int expireInSeconds { get; set; }
        public bool shouldResetPassword { get; set; }
        public object passwordResetCode { get; set; }
        public int userId { get; set; }
        public bool requiresTwoFactorVerification { get; set; }
        public object twoFactorAuthProviders { get; set; }
        public object twoFactorRememberClientToken { get; set; }
        public object returnUrl { get; set; }
        public string refreshToken { get; set; }
        public int refreshTokenExpireInSeconds { get; set; }
        public object c { get; set; }
    }
}
