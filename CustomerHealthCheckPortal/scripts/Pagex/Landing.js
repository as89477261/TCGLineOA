let param = "";
let isDebug = ""
let lineID = "";
let showProfile = ""
let progressValue = 0;
let interval;

document.addEventListener('DOMContentLoaded', () => {
    isDebug = document.getElementById("hddIsDebug");
    lineID = document.getElementById("hddLiffKey");
    showProfile = document.getElementById("hddShowProfile");

    StratProgressBar();
    window.location.href = "index_inno";
});


function runApp() {
    //GetProfile() // ´Ö§ Profile
    StratProgressBar()

    let myPromise = new Promise((resolve, reject) => {
        GetProfile();
        resolve("OK");
    });

    myPromise
        .then((msg) => {
            var obj = GenerateUIDObject();
            var result = InsertUID(obj);
            console.log("Insert initial Data is :" + result);
            if (result != "") {
                resolve("OK");
            } else {
                reject("x must be 0");
            }
        })
        .catch((msg) => console.log("Error: " + msg));

    myPromise
        .then((msg) => {

            GetConsent();
            console.log("Check Consent");
        })
        .catch((msg) => console.log("Error: " + msg));

}
function runDebug() {
    StratProgressBar();

    var obj = GenerateUIDObject();
    InsertUID(obj);
    GetConsent();
}

function GetProfile() {
    liff.getProfile().then(profile => {
        const userID = profile.userId;
        const displayName = profile.displayName;
        const statusMessage = profile.statusMessage;
        const pictureUrl = profile.pictureUrl;
        const email = liff.getDecodedIDToken().email;

        setCookie("uid", userID, 3650);
        setCookie("uname", displayName, 3650);
        setCookie("ustatus", statusMessage, 3650);
        setCookie("pic", pictureUrl, 3650);
        setCookie("uemail", email, 3650);

        //localStorageSave("uid", userID);
        //localStorageSave("uname", displayName);
        //localStorageSave("ustatus", statusMessage);
        //localStorageSave("pic", pictureUrl);
        //localStorageSave("uemail", email);




    }).catch(
        err => console.error(err)
    );
}
function GetConsent() {

    let consent = SelectUserConsent();
    if ((consent !== null || consent !== 'undefined' || consent !== '') &&
        consent.Consent1 === null &&
        consent.Consent2 === null &&
        consent.Consent3 === null) {
        setCookie("isConsent", "", 3650);
        setTimeout(function () { window.location.href = "views/pdpa/info"; }, 1000);
    } else {
        setTimeout(function () { window.location.href = "index_inno"; }, 1000);
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
function StratProgressBar() {
    const element = document.getElementById("progressBar");
    interval = setInterval(frame, 10);
    function frame() {
        if (progressValue === 1000) {
            clearInterval(interval);
        } else {
            progressValue += 20;
            element.style.width = progressValue + '%';
            /*element.innerHTML = progressValue + '%';*/
        }
    }
}

