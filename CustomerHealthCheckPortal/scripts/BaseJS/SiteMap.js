
//Landing
function redirectToLanding() {

    window.location.href = host + "/landing";

}
// Main
function redirectToMain() {

    window.location.href = host + "/index";
    //window.location.href = 'https://liff.line.me/1657329342-aqLD49gj';
}
function redirectToOriginalTcgWebsite() {
    url = "https://www.tcg.or.th/index.php";
    window.location.href = url;
}
function redirectToConsultFACenter() {
    url = "https://fs.tcg.or.th/tcg_ui_facenter/eregister/-1/-1"
    window.location.href = url;
}
function redirectToConsultClinicOnline() {
    url = "https://fs.tcg.or.th/tcg_ui_clinic/index-agreement.html"
    window.location.href = url;
}

function redirectToThaicamber2301() {
    url = "https://www.thaichamber.org/donation"
    window.location.href = url;
}


//----------------------Detail-----------------------
//HealthCheck
//function redirectToHealthCheck() {

//    let customerHealthCheckURL = document.getElementById('hddCustomerHealthCheckURL').value
//    window.location.href = customerHealthCheckURL;
//}
function redirectToHealthCheck() {
    let url = "";
    let cookie = getCookie("uid");
    let customerHealthCheckURL = document.getElementById('hddCustomerHealthCheckURL').value


    if (cookie === "") {
        url = customerHealthCheckURL;
    } else {
        url = customerHealthCheckURL + "?uid=" + cookie;
    }
    window.location.href = url;
}
function redirectToHealthCheckPGS10() {
    let url = "";
    let cookie = getCookie("uid");
    let attentionURL = document.getElementById('hddAttentionURL').value
    url = host + attentionURL + "?uid=" + cookie + "&infoType=HealthCheck&subInfoType=PGS10";
    window.location.href = url;
}
function redirectToHealthCheckPGS11() {
    let url = "";
    let cookie = getCookie("uid");
    let attentionURL = document.getElementById('hddAttentionURL').value
    url = host + attentionURL + "?uid=" + cookie + "&infoType=HealthCheck&subInfoType=PGS11";
    window.location.href = url;
}

function redirectToHealthPromKhum() {
    let url = "";
    let cookie = getCookie("uid");
    let attentionURL = document.getElementById('hddAttentionURL').value
    url = host + attentionURL + "?uid=" + cookie + "&infoType=HealthCheck&subInfoType=PROMKHUM";
    window.location.href = url;
}

function redirectToHealthSMEsPickUp() {
    let url = "";
    let cookie = getCookie("uid");
    let attentionURL = document.getElementById('hddAttentionURL').value
    url = host + attentionURL + "?uid=" + cookie + "&infoType=HealthCheck&subInfoType=SMEsPickUp";
    window.location.href = url;
}

function redirectToHealthCheckSMEsStimateCampaign() {
    let url = "";
    let cookie = getCookie("uid");
    let attentionURL = document.getElementById('hddAttentionURL').value
    url = host + attentionURL + "?uid=" + cookie + "&infoType=HealthCheck&subInfoType=SMEsStimulateCampaign";
    window.location.href = url;
}




//https://demo.tcg.or.th/healthcheck_promkhum_uat/ui/v3/default.aspx


//Product
function redirectToProduct() {
    let productURL = document.getElementById('hddProductURL').value
    window.location.href = host + productURL;
}
function redirectToStep1() {

    window.location.href = host + "/views/PreApproch/step1.aspx";
}
function redirectToStep2() {

    window.location.href = host + "/views/PreApproch/step2.aspx";
}
function redirectToStep3() {


    window.location.href = host + "/views/PreApproch/step3.aspx";
}
function redirectToStep4() {

    window.location.href = host + "/views/PreApproch/step4.aspx";
}

//NDID EForm
function redirectToEForm() {

    let EFormUrl = document.getElementById('hddNDIDEFormURL').value
    window.location.href = EFormUrl;
}

//NDID 
function redirectToNDID() {
    let NDIDUrl = document.getElementById('hddNDIDURL').value
    window.location.href = host + NDIDUrl;
}
function redirectToNDIDStep1() {

    window.location.href = host + "/views/NDID/step1.aspx";
}
function redirectToNDIDStep2() {

    window.location.href = host + "/views/NDID/step2.aspx";
}
function redirectToNDIDStep3() {

    window.location.href = host + "/views/NDID/step3.aspx";
}
function redirectToNDIDStep4() {

    window.location.href = host + "/views/NDID/step4.aspx";
}
function redirectToNDIDStep5() {

    window.location.href = host + "/views/NDID/step5.aspx";
}

//Confirm Request
function redirectToConfirmRequest() {

    window.location.href = host + "/views/Request/List.aspx";
}
function redirectToConfirmRequestStep1() {

    window.location.href = host + "/views/Request/step1.aspx";
}
function redirectToConfirmRequestStep2() {

    window.location.href = host + "/views/Request/step2.aspx";
}
function redirectToConfirmRequestStep3() {

    window.location.href = host + "/views/Request/step3.aspx";
}
function redirectToConfirmRequestStep4() {

    window.location.href = host + "/views/Request/step4.aspx";
}
function redirectToConfirmRequestStep5() {

    window.location.href = host + "/views/Request/step5.aspx";
}

function redirectToNDIDStepVerify(result) {

    window.location.href = host + "/views/NDID/Step/Verify.aspx?uid=" + result;
}

//Debt
function redirectToDebt() {

    let debtURL = document.getElementById('hddDebtURL').value
    window.location.href = host + debtURL;
}
function redirectToDebtStep1() {
    let url = document.getElementById('hddDebtURL').value
    window.location.href = host + url;
}
function redirectToDebtStep2() {
    window.location.href = host + "/views/Debt/register.aspx";
}

//Dopa
function redirectToIdentify() {

    let IdentifyURL = document.getElementById('hddIdentifyURL').value
    window.location.href = IdentifyURL;
}

//Events
function redirectToEvent() {
    let eventURL = document.getElementById('hddEventURL').value
    window.location.href = host + eventURL;
}
function redirectToRegister002() {
    let eventURL = "/views/Register/Event/Register002?code=008";
    window.location.href = host + eventURL;
}

//Register
function redirectToRegister() {
    let EventRegisterURL = document.getElementById('hddRegisterURL').value
    window.location.href = host + EventRegisterURL;
}
function redirectToRegisterWithFormAndCode(registerForm, eventCode) {

    let EventRegisterURL = document.getElementById('hddRegisterEventFormURL').value
    window.location.href = host + EventRegisterURL + registerForm + "?code=" + eventCode;
}

function redirectToQuestionaire() {
    let RegisterURL = document.getElementById('hddRegisterURL').value
    window.location.href = host + RegisterURL;
}

function redirectToMyLG() {
    window.location.href = host + "/views/LG/index.aspx";
}
function redirectToQueue() {
    window.location.href = host + "/views/Booking/index.aspx";
}
function redirectToPayment() {
    window.location.href = host + "/views/bill/index.aspx";
}

//SignUp
function redirectToSignUp() {
    window.location.href = host + "/views/SignUp/index.aspx";
}
function redirectToConfirmOTP() {
    window.location.href = host + "/views/SignUp/confirmOTP.aspx";
}
// my lg
function redirectToMylg() {
    window.location.href = host + "/views/LG/index.aspx";
}

// my request
function redirectToMyrequest() {
    window.location.href = host + "/views/RequestInfo/index.aspx";
}

// my bill
function redirectToMyBill(lg) {
    if (lg) {
        window.location.href = host + "/views/Bill/index.aspx?lg=" + lg;
    } else {
        window.location.href = host + "/views/Bill/index.aspx";
    }
}

// Profile
function redirectToProfile() {
    window.location.href = host + "/views/Profile/index.aspx";
}
function redirectToEditProfile() {
    window.location.href = host + "/views/PDPA/edit.aspx";
}

// EventBanner
function redirectToEventBanner() {
    window.location.href = host + "/views/EventBanner/index.aspx";
}
function redirectToRegisterEventBannerPersonal() {
    let cookie = getCookie("uid");
    //let url = "https://bit.ly/3pCfwb2";
    let url = "https://register.thaichamber.org/question/470";
    window.location.href = url + "?uid=" + cookie;
}
function redirectToRegisterEventBannerJuristic() {
    let cookie = getCookie("uid");
    let url = "https://register.thaichamber.org/question/461";
    window.location.href = url + "?uid=" + cookie;
}

function redirectToEventBanner2() {
    window.location.href = host + "/views/EventBanner/Event2.aspx";
}
function redirectToRegisterEventBanner2() {
    url = "https://bit.ly/thaicreditguaranteecorporation";
    window.location.href = url;
}

// enrollment
function redirectToEnrollmentOTP() {
    window.location.href = host + "/views/SignUp/confirmOTP.aspx";
}
function redirectToEnrollmentNotFound() {
    window.location.href = host + "/views/SignUp/Notfound.aspx";
}

// RequestInfo
function redirectToRequestInfo() {
    window.location.href = host + "/views/RequestInfo/index.aspx";
}

// NDID Choose Bank Step
function redirectToNDIDChooseBank() {
    window.location.href = host + "/views/NDID/Choose/Bank.aspx";
}

// NDID E-Form Step
function redirectToNDIDEform() {
    window.location.href = host + "/views/NDID/Step/Verify.aspx";
}

// Calculator
function redirectToCal() {
    const newTcgUrl = getNewTCGUrl()
    let uid = window.localStorage.getItem('uid');
    window.location.href = newTcgUrl + `/calculators?uid=${uid}`
    //window.location.href = host + "/views/Cal/Menu.aspx";
}

//ContactDoctor
function redirectToContactDoctor() {
    let url = "";
    let cookie = getCookie("uid");
    //let contactDoctorURL = 'https://liff.line.me/1657329342-wpGx9ry3';//document.getElementById('hddContactDoctorURL').value
    let contactDoctorURL = document.getElementById('hddContactDoctorURL').value;

    if (cookie === "") {
        url = contactDoctorURL;
    }
    else {
        url = contactDoctorURL + "?uid=" + cookie;
    }
    window.location.href = url;
}

//SET THAILAND
function redirectToSetThailand() {

    let uid = getCookie("uid");
    let CallSetThailandURL = document.getElementById('hddSetThailandURL').value;

    console.log(uid);

    if (uid != null && uid != '' && uid != undefined) {

        //GET PROFILE UID
        let obj = GetUidData(uid)

        obj = obj.replace(" ", "");

        let data = JSON.parse(obj);

        //GET PROFILE UID LINE
        let objUid = GetUIDLineProfile(uid);

        let datalineprofile = JSON.parse(objUid);

        console.log(datalineprofile.RESULT_OBJ[0].Email);

        //EDIT CUT PROFILE SOME FIELD
        let rUid = ''
        let rEmail = ''
        let rName = ''
        let rSurname = ''
        let rMobileNumber = ''
        let rCompanyName = ''

        if (data.RESULT_OBJ.length > 0) {

            let resultObj = data.RESULT_OBJ[0]

            rUid = uid
            rEmail = ''
            rName = resultObj.Name
            rSurname = resultObj.SureName
            rMobileNumber = resultObj.MobileNumber
            rCompanyName = resultObj.CompanyName

            if (rName != null) {
                rName = ReplaceSpecailLetter(resultObj.Name);
            }
            if (rSurname != null) {
                rSureName = ReplaceSpecailLetter(resultObj.SureName);
            }
            if (rCompanyName != null) {
                rCompanyName = ReplaceSpecailLetter(resultObj.CompanyName);
            }
            if (rEmail == '' || rEmail == 'undefined') {
                rEmail = null
            }
            if (rSurname == '' || rSurname == 'undefined') {
                rSurname = null
            }
            if (rName == '' || rName == 'undefined') {
                rName = null
            }
            if (rCompanyName == '' || rCompanyName == 'undefined') {
                rCompanyName = null
            }

        } else {

            rUid = uid
            rEmail = null
            rName = null
            rSurname = null
            rMobileNumber = null
            rCompanyName = null

            if (rEmail == '' || rEmail == 'undefined') {
                rEmail = null
            }
        }

        console.log(rUid)
        console.log(rEmail)
        console.log(rName)
        console.log(rSurname)
        console.log(rMobileNumber)
        console.log(rCompanyName)

        //URL CALL PROJECT SETTHAILAND
        let url = CallSetThailandURL + `/authenticate/${rUid}/id/${rEmail ?? "null"}/email/${rName ?? "null"}/firstname/${rSurname ?? "null"}/lastname/${"null"}/gender/${rMobileNumber ?? "null"}/phone_number/${rCompanyName ?? "null"}/company_name/${"null"}/corporate_number`

        //console.log(window.location.href + "GO TO :" + url);
        //URL CHECK DIRECT

        //LOG GEN OBJECT TO LOG DB

        let objlog = {
            UID: uid,
            LogSetUrl: url,
            CreateDate: null,
            StatusValid: true
        }
        console.log(objlog)

        if (objlog != null && objlog != undefined) {
            let logresult = logSetThainland(objlog);
            logresult = JSON.parse(logresult);
            console.log(logresult.RESULT_OBJ);
        }

        swal('SET Live Platform ', 'GO', 'success').then(() => { window.location.href = url });

    }
    else {
        redirectToMain();
    }
    function ReplaceSpecailLetter(string) {
        let originalString = string
        let searchString = /\@|\!|\%|\#|\$|\//g;
        let replacementString = ""

        // Using the replace method
        let newString = originalString.replace(searchString, replacementString);

        return newString
        // Output the result
        console.log(newString);
    }
}

//DIPROM 
function redirectTodiprom() {
    window.location.href = host + "/views/diprom/index.aspx";


    //url = "https://bit.ly/thaicreditguaranteecorporation";
    //window.location.href = url;
}

// FA Center
function redirectToFaCenterPortal() {
    window.location.href = "https://www.tcgcyber.com/reg/index-consult.html";

}

// Reward
function redirectToReward() {
    window.location.href = host + "/views/Reward/index.aspx";
}

//TCCProject
function redirectToTCCProject() {
    window.location.href = host + "/views/TCCProject/index.aspx";
}

//LOA
function redirectToLOAStep0() {
    window.location.href = host + "/views/LOA/Step0.aspx";
}
function redirectToLOAStep1() {
    window.location.href = host + "/views/LOA/Step1.aspx";
}
function redirectToLOAStep2() {
    window.location.href = host + "/views/LOA/Step2.aspx";
}
function redirectToLOAStep2BK() {
    window.location.href = host + "/views/LOA/Step2_BK.aspx";
}

function redirectToLOAStep3_1() {
    window.location.href = host + "/views/LOA/Step3_1.aspx";
}
function redirectToLOAStep3_2() {
    window.location.href = host + "/views/LOA/Step3_2.aspx";
}
function redirectToLOAStep3_3() {
    window.location.href = host + "/views/LOA/Step3_3.aspx";
}
function redirectToLOAStep3_4() {
    window.location.href = host + "/views/LOA/Step3_4.aspx";
}
function redirectToLOAStep4() {
    window.location.href = host + "/views/LOA/Step4.aspx";
}
function redirectToLOAStep5() {
    window.location.href = host + "/views/LOA/Step5.aspx";
}
function redirectToLOAStep6() {
    window.location.href = host + "/views/LOA/Step6.aspx";
}
function redirectToLOAStep7() {
    window.location.href = host + "/views/LOA/Step7.aspx";
}
function redirectToLOAStep7_1() {
    window.location.href = host + "/views/LOA/Step7_1.aspx";
}
function redirectToLOAStep7_2() {
    window.location.href = host + "/views/LOA/Step7_2.aspx";
}
function redirectToLOAStep8() {
    window.location.href = host + "/views/LOA/Step8.aspx";
}
function redirectToLOAStep9() {
    window.location.href = host + "/views/LOA/Step9.aspx";
}


function redirectToMerchant_KM() {
    window.location.href = host + "/views/reward_KM/merchant_KM.aspx";
}
function redirectToRegister_KM() {
    window.location.href = host + "/views/reward_KM/Register_KM.aspx";
}
function redirectToMProfile_KM() {
    window.location.href = host + "/views/reward_KM/merchant_Profile_KM.aspx";
}
function redirectToMCoupon_KM() {
    window.location.href = host + "/views/reward_KM/merchant_Coupon_KM.aspx";
}
function redirectToMScan_KM() {
    window.location.href = host + "/views/reward_KM/merchant_Scan_KM.aspx";
}
function redirectToMDashboard_KM() {
    window.location.href = host + "/views/reward_KM/merchant_Dashboard_KM.aspx";
}


function redirectToLOAStep10() {
    window.location.href = host + "/views/LOA/Step10.aspx";
}

function redirectToLOAStep10_1() {
    window.location.href = host + "/views/LOA/Step10_1.aspx";
}

function redirectToRegisterTCC() {
    let cookie = getCookie("uid");
    window.location.href = 'https://dev.mudjaicrm.com/tcc-mr/MemberRegister/NewMember' + "?uid=" + cookie;

}

function getAccessToken(prefix, suffix) {
    for (let i = 0; i < localStorage.length; i++) {
        const key = localStorage.key(i);
        if (key.startsWith(prefix) && key.endsWith(suffix)) {
            return localStorage.getItem(key); // คืนค่า accessToken
        }
    }
    return null; // หากไม่พบค่า
}

function redirectToPreApporchTCGOR() {

    const accessToken = liff.getAccessToken();
    const idToken = liff.getIDToken();

    let directAppTcgOrURL = document.getElementById('hddDirectAppTcgOrURL').value;
    console.log(directAppTcgOrURL);

    let preApprochURL = directAppTcgOrURL
    console.log('accessToken', accessToken);
    console.log('idToken', idToken);

    if (accessToken != null && idToken != null) {
        url = preApprochURL + "?access_token=" + accessToken + "&id_token=" + idToken;
        const _uid = getCookie("uid");
        KeepLogActivity("EVENT_PREAPP_OR", _uid, url);
        console.log('pathDirect', url);
    }
    else {
        redirectToLanding();
    }
    //window.location.href = url;
}

//function redirectToContactDoctor() {
//    let url = "";
//    let cookie = getCookie("uid");
//    //let contactDoctorURL = 'https://liff.line.me/1657329342-wpGx9ry3';//document.getElementById('hddContactDoctorURL').value
//    let contactDoctorURL = document.getElementById('hddContactDoctorURL').value;

//    if (cookie === "") {
//        url = contactDoctorURL;
//    }
//    else {
//        url = contactDoctorURL + "?uid=" + cookie;
//    }
//    window.location.href = url;
//}

function redirectToPreApporchKORSO() {

    const isDebug = document.getElementById("hddIsDebug");
    let accessToken = ''
    let idToken = ''

    if (isDebug.value === "1") {

        accessToken = 'eyJhbGciOiJIUzI1NiJ9.F2NoOu67U4AfsKyB32AtPfR37rMO_k7DEG8c4YY_BQP9FRpvrH8N4C0-UH9QlrEdFFE7PFkSM-OAb4cbWuoSxJVxPKx5zDC8mAn_CL9mX_q8YmxuxNngPfIrfikS_vUDh_VfQp1DLrcgsPz6oLPE-wm2vd4kt0PL8msinjHRROs.u4xfkaSmDtPH9QGlXe_FTJb2VfI5JDPSG_X_T6zO3jg';
        idToken = 'eyJraWQiOiI5MjkxZTZiNmEzOGM3ZDhhZjY4YzUyNjZmYWEyODIwOGQ2ZGQ1OTg0NWZhYTAyNGU1NDFiZGIzOWZlMTM1ZDRiIiwidHlwIjoiSldUIiwiYWxnIjoiRVMyNTYifQ.eyJpc3MiOiJodHRwczovL2FjY2Vzcy5saW5lLm1lIiwic3ViIjoiVTMyNjUyYTlmMGE0MGQ1YmViMDZiYWZhNTVhZmU2ZTNjIiwiYXVkIjoiMTY1NzYwNTg1OCIsImV4cCI6MTc0MzA1MjAyMiwiaWF0IjoxNzQzMDQ4NDIyLCJhbXIiOlsibGluZXNzbyJdLCJuYW1lIjoixKbhtLjhtLDilazigqbhv6bilKwiLCJwaWN0dXJlIjoiaHR0cHM6Ly9wcm9maWxlLmxpbmUtc2Nkbi5uZXQvMGhseWRnb2MwWE0xWlpIaWVLdE45TUFXVmJQVHN1TURVZUlYOTFZblJKWlRFbUtuTUlZWEV2WUg1SmJXQnhLeUVHTlM5NU4zNU9ibUJ4IiwiZW1haWwiOiJudXRiaXRvc2FrdW5AZ21haWwuY29tIn0.-ZhadsrGIOwUXKafcs4nJ6SA7N7Qs_rOPNoSFLz6UG7IR8Or8fLQKAwzf3N6Vg3sZJWsL5MAMTixTJtGJA1opw';

    } else {

        accessToken = liff.getAccessToken();
        idToken = liff.getIDToken();

    };

    let directAppTcgOrURL = document.getElementById('hddDirectAppTcgKorsoURL').value;
    console.log(directAppTcgOrURL);

    let preApprochURL = directAppTcgOrURL;

    /* PASS */
    console.log('accessToken', accessToken);
    console.log('idToken', idToken);

    const _uid = getCookie("uid");


    if (accessToken != null && idToken != null) {
        url = preApprochURL + "?access_token=" + accessToken + "&id_token=" + idToken;
        KeepLogActivity("EVENT_KORORCHOR", _uid);
        //KeepLogActivity("EVENT_PREAPP_KORSO", _uid);
        console.log('pathDirect', url);
        location.href = url;
    }
    else {
        redirectToLanding();
    }
    //window.location.href = url;
}

function redirectToPreApporchRegisterReward() {

    const accessToken = liff.getAccessToken();
    const idToken = liff.getIDToken();

    let directAppTcgOrURL = document.getElementById('hddDirectAppTcgRegisterRewardURL').value;
    console.log(directAppTcgOrURL);

    let preApprochURL = directAppTcgOrURL;

    /* PASS */
    console.log('accessToken', accessToken);
    console.log('idToken', idToken);


    if (accessToken != null && idToken != null) {
        url = preApprochURL + "?access_token=" + accessToken + "&id_token=" + idToken;
        const _uid = getCookie("uid");
        KeepLogActivity("EVENT_PREAPP_KORSO", _uid, url);
        console.log('pathDirect', url);
    }
    else {
        redirectToLanding();
    }
    //window.location.href = url;
}

function redirectToPreApporchTcgRegisterDopa() {

    const accessToken = liff.getAccessToken();
    const idToken = liff.getIDToken();


    let liffUrl = 'https://liff.line.me/1657605858-5Xl76mE9'   // document.getElementById('hddDirectAppTcgRegisterRewardURL').value;
    console.log(liffUrl);


    console.log('accessToken', accessToken);
    console.log('idToken', idToken);

    if (accessToken != null && idToken != null) {
        url = liffUrl + "?access_token=" + accessToken + "&id_token=" + idToken;
        const _uid = getCookie("uid");
        KeepLogActivity("EVENT_PREAPP_TCGREGISTER", _uid, url);
        console.log('pathDirect', url);
    }
    else {
        redirectToLanding();
    }

    window.location.href = url;
}

function getNewTCGUrl() {
    const newTcgUrl = document.getElementById('hddNewTCGPortalURL').value;

    return newTcgUrl;
}


function redirectToCal_LG() {
    window.location.href = host + "/views/Cal/LG/index.aspx";
}
function redirectToCal_DCU() {
    window.location.href = host + "/views/Cal/DCU/index.aspx";
}

function redirectToDebtRegister() {
    window.location.href = host + "/views/Debt/register.aspx";
}

