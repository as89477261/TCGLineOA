let isCheckPDPACookie = "";
let consentPdpaUpdate = [];
let purposesLineOA = [];

const consent1 = sessionStorage.getItem('consentId0');
const consent2 = sessionStorage.getItem('consentId1');
const consent3 = sessionStorage.getItem('consentId2');

//connectPDPA
let pdpaConsentPoint = document.getElementById("hddPDPAConsentPoint").value;

console.log(consent1, consent2, consent3);
console.log(pdpaConsentPoint);

document.addEventListener('DOMContentLoaded', () => {
    var obj = GenerateUIDObject();
    InsertUID(obj);
    CheckIsConsent();
});

async function getPurposesAll() {

    try {
        const stringPorposesAll = await GetPurposesAll();
        let resultPorposes = JSON.parse(stringPorposesAll);
        let _resultPorposes = JSON.parse(resultPorposes);

        console.log(_resultPorposes);

        if (resultPorposes.Message == 'ErrorMessage : Unable to connect to the remote server') {
            return false;
            console.log('resultPorposes', 'fail api GetPurposesAll' + resultPorposes)
        };

        //let resultPorposesfinal = JSON.parse(resultPorposes);

        if (_resultPorposes.result != null) {

            let findresultPurposes = _resultPorposes.result.items.filter(i => i.purposeCategoryName === 'Customer');
            for (let i = 0; i < findresultPurposes.length; i++) {

                purposesLineOA.push(findresultPurposes[i].purpose);

                sessionStorage.setItem("consentId" + i, purposesLineOA[i].id);

            }
            return true;
        }
    }
    catch {
        return false;
        console.log("purposesLineOA", purposesLineOA);
    }

}

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

    let consent = SelectUserConsent(); //Call API
    console.log(consent)


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

//STEP 
async function updateConsentStatusInfo(obj) {

    const data = obj;

    if (data != null) {


        console.log('data', data);

        const buffer = await UpdateConsentStatusAsync(data);
        const result = JSON.parse(buffer);

        console.log(result);

        if (result.RESULT_STATUS == "OK") {
            return true;
        }
        else {
            return false;
        }
    }

}
async function CheckConsentIsActive() {

    var hddStep1Consent = document.getElementById("hddStep1Consent");
    var hddStep2Consent = document.getElementById("hddStep2Consent");
    var hddStep3Consent = document.getElementById("hddStep3Consent");

    /**NEW */
    const result = await GenFromSumbitConsent();
    console.log('GenFromSumbitConsent',result);

    if (result === true) {

        if (hddStep1Consent.value !== ""
            && hddStep2Consent.value !== ""
            && hddStep3Consent.value !== "") {
            setCookie("isConsent", "true", 3650);

            let _uid = getCookie("uid");

            if (_uid != null) { 


            let _genFromUpdateStatus = {
                Uid: _uid,
                Consent1: hddStep1Consent.value,
                Consent2: hddStep2Consent.value,
                Consent3: hddStep3Consent.value
                };
                console.log('_genFromUpdateStatus', _genFromUpdateStatus )

            //STEP 2.1 
            let resultUpdate = await updateConsentStatusInfo(_genFromUpdateStatus);
            //console.log('resultUpdateStatus', resultUpdateStatus ? "complete" : "fail");
            if (resultUpdate == true)

                try {
                    console.log('Redirect : Main');
                    redirectToMain();
                } catch {
                    console.log('Redirect : Landing');
                    redirectToLanding();
                }
            }
            else {
                console.log('Redirect : Landing');
                redirectToLanding(); 
            }

        }
    }
}
/**OLD */
//if (hddStep1Consent.value !== ""
//    && hddStep2Consent.value !== ""
//    && hddStep3Consent.value !== "") {
//    setCookie("isConsent", "true", 3650);
//    return true;
//}

async function GenFromSumbitConsent() {

    const _uid = getCookie("uid");
    const _emailLine = getCookie("uemail");
    const _pdpaConsentPoint = document.getElementById("hddPDPAConsentPoint").value;

    const _consent1 = sessionStorage.getItem('consentId0');
    const _consent2 = sessionStorage.getItem('consentId1');
    const _consent3 = sessionStorage.getItem('consentId2');

    if (_consent1 == null || _consent2 == null || _consent3 == null) {

        const _getPurposes = await getPurposesAll();
        console.log('_getPurposes', _getPurposes);
    }



    if (_uid != null) {

        const _getConsent1 = sessionStorage.getItem('consentId0');
        const _getConsent2 = sessionStorage.getItem('consentId1');
        const _getConsent3 = sessionStorage.getItem('consentId2');

        obj = {
            identifier: _uid,
            email: _emailLine ?? '',
            mobileNo: "-",
            otpType: 0,
            consentPoint: _pdpaConsentPoint, // pdpaConsentPoint
            purposeConsent: [
                {
                    "id": consent1 ?? _getConsent1 
                    , "consentStatus": hddStep1Consent.value == "1" ? true : false
                },
                {
                    "id": consent2 ?? _getConsent2 , 
                    "consentStatus": hddStep2Consent.value == "1" ? true : false
                },
                {
                    "id": consent3 ?? _getConsent3 , 
                    "consentStatus": hddStep3Consent.value == "1" ? true : false
                }
            ]
        };
    };

    let resultSubmitApi = await SubmitConsent(obj);
    let _resultSubmitApi = JSON.parse(resultSubmitApi);
    let finalResultSubmitApi = JSON.parse(_resultSubmitApi);

    console.log('PDPA_INFO_finalResultSubmitApi', finalResultSubmitApi);

    let _isPdpa = finalResultSubmitApi?.success ? '1' : '0';

    consentPdpaUpdate = {
        Uid: _uid
        , IsPdpa: _isPdpa
    };

    let resultUpdate = await UpdateConsentPdpa(consentPdpaUpdate);
    let _resultUpdate = JSON.parse(resultUpdate);
    console.log(_resultUpdate.RESULT_STATUS);

    if (_resultUpdate.RESULT_STATUS == 'OK') {
        return true;
    }
    return false;

}