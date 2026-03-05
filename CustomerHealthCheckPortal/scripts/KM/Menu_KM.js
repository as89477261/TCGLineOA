
////bannerEvent2
//var tabBannerEvent2 = document.getElementById("bannerEvent2");
//var hddBannerEvent2 = document.getElementById("hddBannerEvent2");

////console.log("showbanner")
//tabBannerEvent2.style.display = "none"
//if (hddBannerEvent2.value == "1") {
//    tabBannerEvent2.style.display = "block";
//};

var container = document.getElementById("notFoundModal");
var modal = new bootstrap.Modal(container);


document.addEventListener('DOMContentLoaded', () => {

    var obj = GenerateUIDObject();
    InsertUID(obj);

    if (isDebugMode == "0") {
        CheckLoginMainLineWithRedirect(fullHost + "/index");
    }

    ShowFirstTimeInfo();

});

function RedirectToPage(page) {
    let IshaveProfile = document.getElementById('hddIshaveProfile').value
    let uid = getCookie("uid");

    try {       
        switch (page) {
            case "healthcheck":               
                KeepLogActivity("HEALTH_CHECK", uid);
                redirectToHealthCheck();
                break;
            case "healthcheck_PGS10":
                KeepLogActivity("EVENT_ATTENTION_PGS10", uid);
                redirectToHealthCheckPGS10();
                break;
            case "healthcheck_PGS11":
                KeepLogActivity("EVENT_ATTENTION_PGS11", uid);
                redirectToHealthCheckPGS11();
                break;
            case "debt":
                redirectToDebt();
                break;
            case "event":
                redirectToEvent();
                break;
            case "confirmRequest":
                redirectToConfirmRequest();
                break;
            case "signUp":
                redirectToSignUp();
                break;
            case "product":
                if (IshaveProfile === "true") {
                    redirectToProduct();
                } else {
                    modal.show();
                }
                break;
            case "myrequest":
                redirectToMyrequest();
                break;
            case "mylg":
                redirectToMylg();
                break;
            case "eform_ndid":
                redirectToEForm();
                break;
            case "api_ndid":
                redirectToNDID();
                break;
            case "mybill":
                redirectToPayment();
                break;
            case "cal":
                redirectToCal();
                break;
            case "set_thailand":
                redirectToSetThailand();
                break;
            case "debtDoctor":
                KeepLogActivity("DEBT_DOCTOR", uid);
                redirectToContactDoctor();
                break;
            case "diprom":                
                redirectTodiprom();
                break;
            case "TCCProject":
                //redirectTo
                redirectToTCCProject();
                break;
            case "reward":
                KeepLogActivity("REWARD", uid);
                redirectToReward();
                break;
            case "reward":
                KeepLogActivity("REWARD", uid);
                redirectToReward();
                break;
            case "rewardShop":
                KeepLogActivity("LOA", uid);
                redirectToMerchant_KM();
                break;
            case "rewardRegister":
                KeepLogActivity("LOA", uid);
                redirectToLOAStep0();
                break;
                
            default:
                break;
        }

    } catch (error) {
        console.log(error);

    }
}
function TrimMessage(text) {
    var result = "";
    console.log("text length is : " + text.length);
    if (text.length == 11) {
        result = text.substring(1, 10);
        return result
    }
    return text;
}

// Check BannerLinkEvent
function ValidateRegisteredBanner(eventCode, UID) {
    try {
        var json = GetFormRegisterWithEventCodeAndUID(eventCode, UID);
        var data = JSON.parse(json);
        return data;
    }
    catch (err) {
        return '';
    }
}
function ValidateRegisteredBannerf1() {
    var uid = getCookie("uid");
    var eventID = "008";
    var resultValidate = ValidateRegisteredBanner(eventID, uid)

    // alert(resultValidate.length)

    if (resultValidate.length > 0) {
        swal("แจ้งเตือน", "ท่านลงทะเบียนเข้าร่วมมาตรการเรียบร้อยแล้ว", "warning");
    }
    else {
        redirectToRegister002();
    }

}

function OpenRegisteredBanner() {

    //const modalElement = document.getElementById("RegisteredModal");
    //const modalDiv = new bootstrap.Modal(modalElement);

    //modalDiv.show();

    swal("ยังไม่เปิดให้ลงทะเบียน", "ติดตามการลงทะเบียนได้เร็วๆ นี้", "info");
}

//Next Phase
function ShowRegisterInfoDetail(id) {
    if (id !== null) {
        let bufferDetail = GetRegisterInfoByID(id);
    }
}
function GetRegisterInfoByID(id) {

    let myOffcanvas = document.getElementById('registerInfoDetailModal')
    let bsOffcanvas = new bootstrap.Offcanvas(myOffcanvas)
    bsOffcanvas.show();
}

let FirstTimeCon = document.getElementById('modalFirstTimeInfo')
let FirstTimeModal = new bootstrap.Modal(FirstTimeCon);

function ShowFirstTimeInfo() {
   
    var bufferFirstTimeToken = getCookie("MENU_FirstTimeToken");
    console.log(bufferFirstTimeToken);

    if (bufferFirstTimeToken != "1") {
        FirstTimeModal.show();
    }

    //setCookie("MENU_FirstTimeToken", "0", 3650);
    //getCookie("SIGNUP_DummyID");      
    
}
function HideFirstTimeInfo() {
  
    FirstTimeModal.hide();
    var modalBackDrop = document.getElementsByClassName('modal-backdrop');

    
}
function SetFirstTimeToken() {
    setCookie("MENU_FirstTimeToken", "1", 3650);    
    console.log(getCookie("MENU_FirstTimeToken"));

}
function GenerateUIDObject() {
    let obj = {
        sub: getCookie("uid"),
        name: getCookie("uname"),
        picture: getCookie("pic"),
        email: getCookie("uemail")
    };

    return obj;
}

//async function CheckDummyTest() {
//    const dummyId = "a39a8820-2a4c-4b4b-8e5d-5e9ec82b6351";

//    var buffer = await GetVerifyOTPLastStatusAsync(dummyId); 

//    console.log(buffer);
//}
