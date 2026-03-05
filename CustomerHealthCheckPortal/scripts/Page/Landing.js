let param = "";
let isDebug = ""
let lineID = "";
let showProfile = ""
let progressValue = 0;
let interval;
let url = "";
let purposesLineOA = [];
let rejectPurposes = [];
let activePurposes = [];
let consentUser = [];
let consentPdpaUpdate = [];

document.addEventListener('DOMContentLoaded', () => {

    var queryString = window.location.search;
    var urlParams = new URLSearchParams(queryString);
    url = urlParams.get('url')

    console.log(url);

    if (url == '2') {

    }

    isDebug = document.getElementById("hddIsDebug");
    lineID = document.getElementById("hddLiffKey");
    showProfile = document.getElementById("hddShowProfile");

    if (isDebug.value === "1") {
        console.log('DebugMode set uid');

        setCookie("uid", "U32652a9f0a40d5beb06bafa55afe6e3c", 3650);
        setCookie("uname", "Nutbit0", 3650);
        setCookie("ustatus", "TEST", 3650);
        setCookie("pic", "TEST", 3650);
        setCookie("uemail", "", 3650);
        setCookie("uidtoken", "U32652a9f0a40d5beb06bafa55afe6e3c", 3650);
        runDebug();

    } else {
        liff
            .init({ liffId: lineID.value, withLoginOnExternalBrowser: true })
            .then(() => {
                if (liff.isLoggedIn()) {
                    console.log('Step 1.1 : ShowProfile');

                    if (showProfile.value === "1") {

                    }

                    console.log('Step 1.2 : Start Progress');
                    StratProgressBar();

                    console.log('Step 1.3 : Step1');
                    Step1(Step2);


                    console.log('Set UID to Storage')
                    let uid = liff?.getDecodedIDToken()?.sub
                    window.localStorage.setItem("uid", uid);

                } else {
                    liff.login({ redirectUri: fullHost });
                }
            })
            .catch((err) => {
                console.log(err.code, err.message);
            });
    }
});

function runDebug() {
    StratProgressBar();

    var obj = GenerateUIDObject();
    InsertUID(obj);
    GetConsent();
}

function Step1(step2) {

    console.log("Step 2.1 : Begin Get Profile");
    liff.getProfile().then(profile => {
        const userID = profile.userId;
        const displayName = profile.displayName;
        const statusMessage = profile.statusMessage;
        const pictureUrl = profile.pictureUrl;
        const email = liff.getDecodedIDToken().email;

        console.log("Step 2.2 : Get Profile Success");
        setCookie("uid", userID, 3650);
        setCookie("uname", displayName, 3650);
        setCookie("ustatus", statusMessage, 3650);
        setCookie("pic", pictureUrl, 3650);
        setCookie("uemail", email, 3650);
        setCookie("uidtoken", userID, 3650);

        console.log("Step 2.3 : Get Profile Success");
        Step2(Step3)

    }).catch(
        err => console.error(err)
    );
}

function Step2(step3) {
    console.log("Step 3.1 : Begin Get Profile From Cookie");
    var obj = GenerateUIDObject();

    console.log("Step 3.2 : Begin Insert Create UID");
    var result = InsertUID(obj);

    console.log("Step 3.3 : Insert initial Data is :" + result);
    step3();
}

function Step3() {
    console.log("Step 4.1 : Begin Get Consent");
    GetConsent();
}

function GetProfile() {
    console.log("Detail Step 2 : Get Profile");
    liff.getProfile().then(profile => {
        const userID = profile.userId;
        const displayName = profile.displayName;
        const statusMessage = profile.statusMessage;
        const pictureUrl = profile.pictureUrl;
        const email = liff.getDecodedIDToken().email;

        console.log("Detail Step 2 : uid = " + userID);
        setCookie("uid", userID, 3650);
        setCookie("uname", displayName, 3650);
        setCookie("ustatus", statusMessage, 3650);
        setCookie("pic", pictureUrl, 3650);
        setCookie("uemail", email, 3650);
        setCookie("uidtoken", userID, 3650);


    }).catch(
        err => console.error(err)
    );
}
async function GetPurposesDetail() {

    const stringPorposesAll = await GetPurposesAll();
    let resultPorposes = JSON.parse(stringPorposesAll);

    console.log(resultPorposes);

    //const checkResult = Find(resultPorposes)
    if (resultPorposes.Message == 'ErrorMessage : Unable to connect to the remote server') {
        return false;
        console.log('resultPorposes', 'fail api GetPurposesAll' + resultPorposes)
    };

    let resultPorposesfinal = JSON.parse(resultPorposes);

    try {
        if (resultPorposesfinal.result != null) {

            let findresultPurposes = resultPorposesfinal.result.items.filter(i => i.purposeCategoryName === 'Customer');
            // purposesLineOA = [...findresultPurposes];
            // console.log(purposesLineOA);
            console.log(findresultPurposes);

            for (let i = 0; i < findresultPurposes.length; i++) {

                purposesLineOA.push(findresultPurposes[i].purpose);

                //setCookie("consentId" + i, purposesLineOA[i].id, 3650);

                sessionStorage.setItem("consentId" + i, purposesLineOA[i].id);

                //break;
            }
            console.log("purposesLineOA", purposesLineOA);

            console.log(sessionStorage.getItem('consentId0'));
            console.log(sessionStorage.getItem('consentId1'));
            console.log(sessionStorage.getItem('consentId2'));
        }
    }
    catch {
        console.log("error GetPurposesDetail")
    }

}


async function GetRejectPurposesAsync() {

    let result = false;
    const uid = getCookie("uid")

    if (uid != null || uid != undefined) {

        try {
            buffer = await GetActivePurposesAsync(uid);
            bufferResult = JSON.parse(buffer);
            bufferResult_2 = JSON.parse(bufferResult);
            console.log('GetRejectPurposesAsync', bufferResult_2);

            rejectPurposes = bufferResult_2.result.purposes;
            console.log('rejectPurposes',rejectPurposes);

            if (rejectPurposes.length == 0) return result;

            //set result success have array 
            result = true;

            return result;
        }
        catch {
            console.log("buffer Not Success");
        }
    }
    return result;
}

async function GetApprovePurposesAsync() {

    let reuslt = false;
    const uid = getCookie("uid")

    if (uid != null || uid != undefined) {

        try {
            buffer = await GetApprovedPurposeByIdentifier(uid);
            bufferResult = JSON.parse(buffer);
            bufferResult_2 = JSON.parse(bufferResult);
            console.log('GetApprovePurposesAsync', bufferResult_2);

            activePurposes = bufferResult_2.result.purposes;
            console.log('activePurposes', activePurposes);

            if (activePurposes.length == 0) return result;

            //set result success have array 
            result = true;

            return result;
        }
        catch {
            console.log("buffer Not Success")
        }
    }
    return reuslt;

}

async function GenFromSumbitConsentLanding(obj) {

    let _uid = getCookie("uid");
    let _emailLine = getCookie("uemail");
    let _configConsentPoint = document.getElementById("hddPDPAConsentPoint").value;

    console.log('configConsentPoint', _configConsentPoint);

    const _consent1 = sessionStorage.getItem('consentId0');
    const _consent2 = sessionStorage.getItem('consentId1');
    const _consent3 = sessionStorage.getItem('consentId2');

    if (_uid != null) {

        obj = {
            identifier: _uid ,
            email: _emailLine ?? '',
            mobileNo: "-",
            otpType: 0,
            consentPoint: _configConsentPoint, // pdpaConsentPoint
            purposeConsent: [
                {
                    "id": _consent1,
                    "consentStatus": obj.Consent1 == "1" ? true : false
                },
                {
                    "id": _consent2,
                    "consentStatus": obj.Consent2 == "1" ? true : false
                },
                {
                    "id": _consent3,
                    "consentStatus": obj.Consent3 == "1" ? true : false
                }
            ]
        };
    }

    let resultSubmitApi = await SubmitConsent(obj);
    let _resultSubmitApi = JSON.parse(resultSubmitApi);
    let finalResultSubmitApi = JSON.parse(_resultSubmitApi);

    console.log('finalResultSubmitApi', finalResultSubmitApi);

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


//async function GetConsent() {
async function GetConsent() {
    console.log("Detail Step 4 : Check Consent");
    let consent = SelectUserConsent(); // CALL TCG API CHECK

    let genDataConsentData = {
        Consent1: consent.Consent1 ?? '',
        Consent2: consent.Consent2 ?? '',
        Consent3: consent.Consent3 ?? '',
    };
    console.log('genDataConsentData', genDataConsentData);

    var uid = getCookie("uid");

    //connectPDPA
    //console.log(consent);
    let resultPdpa = consent.IsPdpa ?? '';
    console.log('consentPdpaIsNull',resultPdpa);

    if (resultPdpa == '' || resultPdpa == 0) {

        let setpurposesCookie = await GetPurposesDetail();
        //console.log(setpurposesCookie)

        let getRejecPurposes = await GetRejectPurposesAsync();
        //console.log(getRejecPurposes);

        let getApprovePurposes = await GetApprovePurposesAsync();
        //console.log(getApprovePurposes);

    }

    //console.log(bufferpdpaConsent);

    if ((consent !== null || typeof consent !== 'undefined' || consent !== '') &&
        consent.Consent1 === null &&
        consent.Consent2 === null &&
        consent.Consent3 === null) {

        setCookie("isConsent", "", 3650);

        console.log("Detail Step 4 : Non-Consent : Redirect");
        if (isDebug.value === "1") {
            console.log("Redirect");
            setTimeout(function () { window.location.href = window.location.origin + "/views/pdpa/info"; }, 1000);
        } else {
            console.log("Redirect");
            setTimeout(function () { window.location.href = fullHost + "/views/pdpa/info"; }, 1000);
        }
    } else {
        console.log("Detail Step 4 : have Concent : Redirect");
        if (isDebug.value === "1") {
     
            console.log("Redirect");
            /** เพิ่ม API SUBMIT จากหลังบ้าน */
            console.log(activePurposes.length);
            console.log(rejectPurposes.length);

            if (activePurposes.length == 0 && resultPdpa == '' || resultPdpa == 0) {

                let resultSubmit = await GenFromSumbitConsentLanding(genDataConsentData);

                console.log('resultSubmit',resultSubmit);
            }

            setTimeout(function () { window.location.href = window.location.origin + "/index"; }, 1000);

        } else {
            console.log("Redirect");

            if (activePurposes.length == 0 && resultPdpa == '' || resultPdpa == 0) {

                let resultSubmit = await GenFromSumbitConsentLanding(genDataConsentData);

                console.log('resultSubmit', resultSubmit);
            }
            setTimeout(function () { window.location.href = fullHost + "/index"; }, 1000);
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

function deleteCookies() {
    var allCookies = document.cookie.split(';');
    for (var i = 0; i < allCookies.length; i++)
        document.cookie = allCookies[i] + "=;expires=" + new Date(0).toUTCString();
}

function StratProgressBar() {
    const element = document.getElementById("progressBar");
    interval = setInterval(frame, 10);

    function frame() {
        if (progressValue === 1000) {
            clearInterval(interval);
        } else {
            progressValue += 10;
            element.style.width = progressValue + '%';
            /*element.innerHTML = progressValue + '%';*/
        }
    }
}

