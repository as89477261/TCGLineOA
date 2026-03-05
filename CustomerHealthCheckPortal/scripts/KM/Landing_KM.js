let param = "";
let isDebug = ""
let lineID = "";
let showProfile = ""
let progressValue = 0;
let interval;
let url = "";

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

    StratProgressBar();

    setCookie("uid", "U7be5eb818d2dfa2dcdeaf83b36cdb944", 3650);
    setCookie("uname", "nutbito", 3650);
    setCookie("ustatus", "TEST", 3650);
    setCookie("pic", "test", 3650);
    setCookie("uemail", "test@tcg.or.th", 3650);
    setCookie("uidtoken", "U7be5eb818d2dfa2dcdeaf83b36cdb944", 3650);

    //setTimeout(function () { window.location.href = "http://localhost:56955/index_KM"; }, 1000);
    setTimeout(function () { window.location.href = fullHost + "/index_KM"; }, 1000);
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
function GetConsent() {
    console.log("Detail Step 4 : Check Consent");
    let consent = SelectUserConsent();

    if ((consent !== null || typeof consent !== 'undefined' || consent !== '') &&
        consent.Consent1 === null &&
        consent.Consent2 === null &&
        consent.Consent3 === null) {

        setCookie("isConsent", "", 3650);

        console.log("Detail Step 4 : Non-Consent : Redirect");
        if (isDebug.value === "1") {
            console.log("Redirect");
            setTimeout(function () { window.location.href = "http://localhost:56955/views/pdpa/info"; }, 1000);
        } else {
            console.log("Redirect");
            setTimeout(function () { window.location.href = fullHost + "/views/pdpa/info"; }, 1000);
        }
    } else {
        console.log("Detail Step 4 : have Concent : Redirect");
        if (isDebug.value === "1") {
            console.log("Redirect");
            setTimeout(function () { window.location.href = "http://localhost:56955/index"; }, 1000);
        } else {
            console.log("Redirect");
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

