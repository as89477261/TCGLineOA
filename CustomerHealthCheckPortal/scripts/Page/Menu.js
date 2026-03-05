////bannerEvent2
//var tabBannerEvent2 = document.getElementById("bannerEvent2");
//var hddBannerEvent2 = document.getElementById("hddBannerEvent2");

////console.log("showbanner")
//tabBannerEvent2.style.display = "none"
//if (hddBannerEvent2.value == "1") {
//    tabBannerEvent2.style.display = "block";
//};

let isDebug = ""


var container = document.getElementById("notFoundModal");
var modal = new bootstrap.Modal(container);

var allBannerModalcontainer = document.getElementById("allBannerModal");
var allBannerModalmodal = new bootstrap.Modal(allBannerModalcontainer);


document.addEventListener('DOMContentLoaded', async () => {

    var LToken = document.getElementById("hddLToken").value;

    //var menuPROMKHUM = document.getElementById("bannerPROMKHUM");
    //var hddPROMKHUMShow = document.getElementById("hddPROMKHUMShow").value;

    //let bannerSMEsPickUp = document.getElementById("mainBannerSMEsPickUp");
    //let hddSMEsPickUpShow = document.getElementById("hddSMEsPickUpShow").value;


    //let bannerSMEsStimulateCampaign = document.getElementById("mainBannerSMEsStimulateCampaign");
    //let hddSMEsStimulateCampaignShow = document.getElementById("hddSMEsStimulateCampaignShow").value;


    if (LToken != "") {
        setCookie("LToken", LToken, 3650);
        console.log("set cookie Ltoken : " + LToken);
    }

    //menuPROMKHUM.style.display = "none"
    //if (hddPROMKHUMShow == "1") {
    //    menuPROMKHUM.style.display = "block";
    //};

    //bannerSMEsPickUp.style.display = "none"
    //if (hddSMEsPickUpShow == "1") {
    //    bannerSMEsPickUp.style.display = "block";
    //};

    //bannerSMEsStimulateCampaign.style.display = "none"
    //if (hddSMEsStimulateCampaignShow == "1") {
    //    bannerSMEsStimulateCampaign.style.display = "block";
    //};

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
            case "healthcheck_PromKhum":
                KeepLogActivity("EVENT_PROMPTKHUM", uid);
                redirectToHealthPromKhum();
                break;
            case "healthcheck_SMEsPickUp":
                KeepLogActivity("EVENT_PICKUP_CAMPAIGN", uid);
                redirectToHealthSMEsPickUp();
                break;
            case "healthcheck_SMEsStimulateCampaign":
                KeepLogActivity("EVENT_ATTENTION_STIMULATE", uid);
                redirectToHealthCheckSMEsStimateCampaign();
                break;
            case "debt":
                redirectToDebt();
                break;
            case "event":
                redirectToEvent();
                break;
            case "event_Help":
                KeepLogActivity("EVENT_PROMPTKHUM", uid, "พร้อมช่วย");
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
                break; healthcheck
            case "cal":
                KeepLogActivity("CALCULATOR_MAIN", uid);
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
                redirectToTCCProject();
                break;
            case "reward":
                KeepLogActivity("REWARD", uid);
                redirectToReward();
                break;
            case "mygurantee":
                KeepLogActivity("MYGUARANTEE", uid);
                redirectToLOAStep1();
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

const firstTimeModalElement = document.getElementById('modalFirstTimeInfo')
const firstTimeModal = new bootstrap.Modal(firstTimeModalElement);

function ShowFirstTimeInfo() {
    var bufferFirstTimeToken = getCookie("MENU_FirstTimeToken");
    console.log('FirstTimeToken', bufferFirstTimeToken);

    // Get the current date and time
    var currentDate = new Date();

    // Define the target date and time (26/01/2568 08:00)
    var targetDate = new Date("2025-01-26T08:00:00");

    if (!bufferFirstTimeToken) {
        setCookie("MENU_FirstTimeToken", "0", 3650);
    }

    // Show modal only if the current date is before the target date
    if (currentDate < targetDate && bufferFirstTimeToken != "1") {
        firstTimeModal.show();
    }
}

function HideFirstTimeInfo() {

    firstTimeModal.hide();
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

function OpenConfirmPromKhumPromChue() {
    const container1 = document.getElementById("ConfirmRegisterModal1");
    const modalConfirm = new bootstrap.Modal(container1);
    modalConfirm.show();
}

function ShowAllBanner() {
    allBannerModalmodal.show();
}
//async function CheckDummyTest() {
//    const dummyId = "a39a8820-2a4c-4b4b-8e5d-5e9ec82b6351";

//    var buffer = await GetVerifyOTPLastStatusAsync(dummyId);

//    console.log(buffer);
//}

function redirectToExternal(url, eventId, remark) {
    const uid = getCookie("uid");
    KeepLogActivity(eventId, uid, remark)

    console.log('Redirecting to external URL:', url);
    window.location.href = url;
}


function redirectCampaignTo(campaignId, eventId, remark) {

    isDebug = document.getElementById("hddIsDebug");

    const _campaignId = campaignId
    let _accessToken = ''
    let _idToken = ''
    const _callback = window.location.href
    console.log(window.location.href);

    if (isDebug.value === "1") {

        _accessToken = 'eyJhbGciOiJIUzI1NiJ9.F2NoOu67U4AfsKyB32AtPfR37rMO_k7DEG8c4YY_BQP9FRpvrH8N4C0-UH9QlrEdFFE7PFkSM-OAb4cbWuoSxJVxPKx5zDC8mAn_CL9mX_q8YmxuxNngPfIrfikS_vUDh_VfQp1DLrcgsPz6oLPE-wm2vd4kt0PL8msinjHRROs.u4xfkaSmDtPH9QGlXe_FTJb2VfI5JDPSG_X_T6zO3jg';
        _idToken = 'eyJraWQiOiI5MjkxZTZiNmEzOGM3ZDhhZjY4YzUyNjZmYWEyODIwOGQ2ZGQ1OTg0NWZhYTAyNGU1NDFiZGIzOWZlMTM1ZDRiIiwidHlwIjoiSldUIiwiYWxnIjoiRVMyNTYifQ.eyJpc3MiOiJodHRwczovL2FjY2Vzcy5saW5lLm1lIiwic3ViIjoiVTMyNjUyYTlmMGE0MGQ1YmViMDZiYWZhNTVhZmU2ZTNjIiwiYXVkIjoiMTY1NzYwNTg1OCIsImV4cCI6MTc0MzA1MjAyMiwiaWF0IjoxNzQzMDQ4NDIyLCJhbXIiOlsibGluZXNzbyJdLCJuYW1lIjoixKbhtLjhtLDilazigqbhv6bilKwiLCJwaWN0dXJlIjoiaHR0cHM6Ly9wcm9maWxlLmxpbmUtc2Nkbi5uZXQvMGhseWRnb2MwWE0xWlpIaWVLdE45TUFXVmJQVHN1TURVZUlYOTFZblJKWlRFbUtuTUlZWEV2WUg1SmJXQnhLeUVHTlM5NU4zNU9ibUJ4IiwiZW1haWwiOiJudXRiaXRvc2FrdW5AZ21haWwuY29tIn0.-ZhadsrGIOwUXKafcs4nJ6SA7N7Qs_rOPNoSFLz6UG7IR8Or8fLQKAwzf3N6Vg3sZJWsL5MAMTixTJtGJA1opw';

    } else {

        _accessToken = liff.getAccessToken();
        _idToken = liff.getIDToken();

    };
    console.log('accessToken', _accessToken);
    console.log('idToken', _idToken);
    // 'https : uat-ext.tcg.or.th/das/register' ตัวกลางในการ Direct ใช้งานตัวเดียว เปลี่ยนเฉพาะ Prod ใน Config
    const _lineLiffUrl = document.getElementById('hddliffCampaignConfigUrl').value;

    let directUrlCampaign = _lineLiffUrl
    const _uid = getCookie("uid");

    if (eventId) {
        KeepLogActivity(eventId, _uid, remark);
    }

    if (_accessToken != null && _idToken != null) {
        url = directUrlCampaign + "?access_token=" + _accessToken + "&id_token=" + _idToken + "&campaign_id=" + _campaignId + "&callback=" + _callback;
        KeepLogActivity("EVENT_PREAPP_CAMPAIGNCONFIG", _uid, url);
        console.log('pathDirect', url);
    }
    else {
        redirectToLanding();
    }
    window.location.href = url;

}