
//Landing
function redirectToLanding() {

    window.location.href = host + "/landing_KM";
   
}
// Main
function redirectToMain() {

    window.location.href = host + "/index_KM";
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

function redirectToHealthCheckPGS11() {
    let url = "";
    let cookie = getCookie("uid");
    let attentionURL = document.getElementById('hddAttentionURL').value
    url = host + attentionURL + "?uid=" + cookie + "&infoType=HealthCheck&subInfoType=PGS11";
    window.location.href = url;
}

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
function redirectToCal() {
    window.location.href = host + "/views/Cal/index.aspx";
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
    window.location.href = host + "/views/cal/index.aspx";
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
            UID: uid ,
            LogSetUrl: url,
            CreateDate : null,
            StatusValid: true
        }
        console.log(objlog)

        if (objlog != null && objlog != undefined)
        { 
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
    window.location.href = host + "/views/Reward_KM/index_KM.aspx";
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