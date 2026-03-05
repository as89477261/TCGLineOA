using System;
using System.Collections.Generic;

public class TcgPdpaApiAuthModel
{
	public string accessToken { get; set; }

	public string encryptedAccessToken { get; set; }

	public int expireInSeconds { get; set; }

	public bool shouldResetPassword { get; set; }

	public string passwordResetCode { get; set; }

	public int userId { get; set; }

	public bool requiresTwoFactorVerification { get; set; }

	public string twoFactorAuthProviders { get; set; }

	public string twoFactorRememberClientToken { get; set; }

	public string returnUrl { get; set; }

	public string refreshToken { get; set; }

	public int refreshTokenExpireInSeconds { get; set; }

	public string c { get; set; }

	public string userNameOrEmailAddress { get; set; }

	public string password { get; set; }

}

public class ActivePurposesConsent<T>
{
	public T purposes { get; set; }

	public bool isRequireOtp { get; set; }

	public int otpType { get; set; }

}

public class ActivePurposesDetail
{
	public string id { get; set; }  

	public string name { get; set; }
	
	public int ordering {  get; set; }

	public string status { get; set; }

}

public class SubmitConsentRespond<T>
{
	public T result { get; set; }

	public string targetUrl { get ; set;}

	public bool success { get; set; }

	public string error { get; set; }

	public bool unAuthorizedRequest { get; set; }

	public bool __abp {  get; set; }

}
public class SumbitConsentData
{
	public string identifier { get; set; }
	public string email { get; set; }
	public string mobileNo { get; set; }
	public int otpType { get; set; }
	public string consentPoint { get; set; }
	public List<PurposeConsent> purposeConsent { get; set; }
}

//public class SubmitPurposeConsent
//{
//	public string id { get; set; }
//	public bool consentStatus { get; set; }
//}

public class PurposeConsent
{
	public string id { get; set; }
	public bool consentStatus { get; set; }
}