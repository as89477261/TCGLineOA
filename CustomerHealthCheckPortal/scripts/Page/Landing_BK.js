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
    if (url == '2') {

    }

    isDebug = document.getElementById("hddIsDebug");
    lineID = document.getElementById("hddLiffKey");
    showProfile = document.getElementById("hddShowProfile");

    if (isDebug.value === "1") {
        console.log('DebugMode set uid');

        setCookie("uid", "U7be5eb818d2dfa2dcdeaf83b36cdb944", 3650);
        setCookie("uname", "Supachoke", 3650);
        setCookie("ustatus", "TEST", 3650);
        setCookie("pic", "test", 3650);
        setCookie("uemail", "supachoke@gmail.com", 3650);
        setCookie("uidtoken", "U7be5eb818d2dfa2dcdeaf83b36cdb944", 3650);
        runDebug();
    } else {
        liff
            .init({ liffId: lineID.value })
            .then(() => {
                if (liff.isLoggedIn()) {
                    if (showProfile.value === "1") {
                        console.log('Step 1 : ShowProfile');

                    }
                    StratProgressBar();
                    Step1(Step2);

                    //runApp();
                } else {
                    liff.login({ redirectUri: "https://chatclinic.tcg.or.th/tcghealthcheck_dev" })

                    //
                }
            })
            .catch((err) => {
                console.log(err.code, err.message);
            });
    }
});



function runApp() {
    //GetProfile() // ´Ö§ Profile
    console.log("Step 2 : Begin Running App");
    StratProgressBar()

    var myPromise = new Promise((resolve, reject) => {
        console.log('RunApp Step 1 : GetProfile');
        GetProfile();
        resolve("OK");
    });

    myPromise
        .then((msg) => {
            console.log('RunApp Step 2 : InsertUID');

            //var obj = GenerateUIDObject();
            //var result = InsertUID(obj);
            //console.log("Insert initial Data is :" + result);

            return "";
        })
        .catch((msg) => { console.log("Error: " + msg); });

    myPromise
        .then((msg) => {
            console.log('RunApp Step 3 : Get Consent');
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

function Step1(step2) {
   
    console.log("Step 3 : Get Profile");
    liff.getProfile().then(profile => {
        const userID = profile.userId;
        const displayName = profile.displayName;
        const statusMessage = profile.statusMessage;
        const pictureUrl = profile.pictureUrl;
        const email = liff.getDecodedIDToken().email;

        console.log("Step 3 : uid = " + userID);

        setCookie("uid", userID, 3650);
        setCookie("uname", displayName, 3650);
        setCookie("ustatus", statusMessage, 3650);
        setCookie("pic", pictureUrl, 3650);
        setCookie("uemail", email, 3650);
        setCookie("uidtoken", userID, 3650);

        Step2(Step3)

    }).catch(
        err => console.error(err)
    );
}

function Step2(step3) {
    var obj = GenerateUIDObject();
    var result = InsertUID(obj);
    console.log("Insert initial Data is :" + result);
    step3();
}


function Step3() {
    GetConsent();
}












function GetProfile() {
    console.log("Step 3 : Get Profile");
    liff.getProfile().then(profile => {
        const userID = profile.userId;
        const displayName = profile.displayName;
        const statusMessage = profile.statusMessage;
        const pictureUrl = profile.pictureUrl;
        const email = liff.getDecodedIDToken().email;

        console.log("Step 3 : uid = " + userID);

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
    console.log("Step Check Consent");
    let consent = SelectUserConsent();

    if ((consent !== null || consent !== 'undefined' || consent !== '') &&
        consent.Consent1 === null &&
        consent.Consent2 === null &&
        consent.Consent3 === null) {
        setCookie("isConsent", "", 3650);

        console.log("Step Check Consent Finish : Redirect");
        if (isDebug.value === "1") {
            console.log("Redirect");
            setTimeout(function () { window.location.href = "http://localhost:56955/views/pdpa/info"; }, 1000);
        } else {
            console.log("Redirect");
            setTimeout(function () { window.location.href = "https://chatclinic.tcg.or.th/tcghealthcheck_dev/views/pdpa/info"; }, 1000);
        }
    } else {
        console.log("Step Check Consent Finish : Redirect");
        if (isDebug.value === "1") {
            console.log("Redirect");
            setTimeout(function () { window.location.href = "http://localhost:56955/index"; }, 1000);
        } else {
            console.log("Redirect");
            setTimeout(function () { window.location.href = "https://chatclinic.tcg.or.th/tcghealthcheck_dev/index"; }, 1000);
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

    // The "expire" attribute of every cookie is 
    // Set to "Thu, 01 Jan 1970 00:00:00 GMT"
    for (var i = 0; i < allCookies.length; i++)
        document.cookie = allCookies[i] + "=;expires="
            + new Date(0).toUTCString();
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

