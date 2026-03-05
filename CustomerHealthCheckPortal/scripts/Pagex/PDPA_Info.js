let isCheckPDPACookie = "";


document.addEventListener('DOMContentLoaded', () => {
    var obj = GenerateUIDObject();
    InsertUID(obj);
    CheckIsConsent();   
});

function CheckIsConsent() {
    var isCheckPDPACookie = document.getElementById("hddIsCheckPDPACookie").value;
    console.log("Get isCheckPDPA is : " + isCheckPDPACookie);
    if (isCheckPDPACookie !== null && isCheckPDPACookie === "1") {

        var isConsent = getCookie("isConsent");
        console.log("IsConsent is : " + isConsent);
        if (isConsent === "true") {
            console.log("Redirect with cookie");
            //window.location.href = "../../index";
        }
    } 
   
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

function GetConsent() {


    let consent = SelectUserConsent();
   
    if (consent !== null &&
        consent.Consent1 === null &&
        consent.Consent2 === null &&
        consent.Consent3 === null) {

        console.log("not redirect");
    } else {
        console.log("Redirect");
        //window.location.href = "../../index";
    }

}
function Step1Consent(status) {
    var btnStep1Yes = document.getElementById("btnStep1Yes");
    var btnStep1No = document.getElementById("btnStep1No");
    var hddStep1Consent = document.getElementById("hddStep1Consent");



    btnStep1Yes.classList.remove("gradient-blue");
    btnStep1No.classList.remove("gradient-blue");
    btnStep1Yes.classList.remove("gradient-gray");
    btnStep1No.classList.remove("gradient-gray");

    if (status === 1) {

        hddStep1Consent.value = "1";
        btnStep1Yes.classList.add("gradient-blue");
        btnStep1No.classList.add("gradient-gray");
    } else {

        hddStep1Consent.value = "0";
        btnStep1Yes.classList.add("gradient-gray");
        btnStep1No.classList.add("gradient-blue");
    }
    CheckIsFinished();
}
function Step2Consent(status) {
    var btnStep2Yes = document.getElementById("btnStep2Yes");
    var btnStep2No = document.getElementById("btnStep2No");
    var hddStep2Consent = document.getElementById("hddStep2Consent");


    btnStep2Yes.classList.remove("gradient-blue");
    btnStep2No.classList.remove("gradient-blue");
    btnStep2Yes.classList.remove("gradient-gray");
    btnStep2No.classList.remove("gradient-gray");

    if (status === 1) {

        hddStep2Consent.value = "1";
        btnStep2Yes.classList.add("gradient-blue");
        btnStep2No.classList.add("gradient-gray");
    } else {

        hddStep2Consent.value = "0";
        btnStep2Yes.classList.add("gradient-gray");
        btnStep2No.classList.add("gradient-blue");
    }
    CheckIsFinished();
}
function Step3Consent(status) {
    var btnStep3Yes = document.getElementById("btnStep3Yes");
    var btnStep3No = document.getElementById("btnStep3No");
    var hddStep3Consent = document.getElementById("hddStep3Consent");

    btnStep3Yes.classList.remove("gradient-blue");
    btnStep3No.classList.remove("gradient-blue");
    btnStep3Yes.classList.remove("gradient-gray");
    btnStep3No.classList.remove("gradient-gray");

    if (status === 1) {

        hddStep3Consent.value = "1";
        btnStep3Yes.classList.add("gradient-blue");
        btnStep3No.classList.add("gradient-gray");
    } else {

        hddStep3Consent.value = "0";
        btnStep3Yes.classList.add("gradient-gray");
        btnStep3No.classList.add("gradient-blue");
    }

    CheckIsFinished();
}

function CheckIsFinished() {
    var hddStep1Consent = document.getElementById("hddStep1Consent");
    var hddStep2Consent = document.getElementById("hddStep2Consent");
    var hddStep3Consent = document.getElementById("hddStep3Consent");
    var btnFinish = document.getElementById("btnSubmitConsent");

    btnFinish.classList.remove("gradient-blue");
    btnFinish.classList.remove("gradient-gray");

    if (hddStep1Consent.value !== ""
        && hddStep2Consent.value !== ""
        && hddStep3Consent.value !== "") {
        btnFinish.classList.add("gradient-blue");       
        btnFinish.classList.remove("disabledButton");
    } else {
        btnFinish.classList.add("gradient-gray");      
    }
}
function CheckConsentIsActive() {
    var hddStep1Consent = document.getElementById("hddStep1Consent");
    var hddStep2Consent = document.getElementById("hddStep2Consent");
    var hddStep3Consent = document.getElementById("hddStep3Consent");


    if (hddStep1Consent.value !== ""
        && hddStep2Consent.value !== ""
        && hddStep3Consent.value !== "") {
        setCookie("isConsent", "true",3650);
        return true;
    }
    return false;
}