var host = document.getElementById("hddHomeUrl").value;
var fullHost = "https://" + window.location.hostname + host;
var liffKey = document.getElementById("hddLiffKey").value;
var isDebugMode = document.getElementById("hddIsDebug").value;
var isHttpManagerDubugMode = document.getElementById("hddIsHttpManagerDubug").value;
var loader = document.querySelector(".loader");
var partialCode = "";
var headerCode = "";

document.addEventListener('DOMContentLoaded', () => {
    var raw = document.getElementById("hddAPIPartialCode").value;
    partialCode = atob(raw)

   
    //liff.init({ liffId: '1657329342-OLdNakq0' })
    //    .then(() => {
    //        if (liff.isLoggedIn()) {
    //            GetProfile();
    //        } else {
    //            if (isDebug.value === "1") {

    //            } else {
    //                liff.login();
    //            }

    //        }
    //    })
    //    .catch((err) => {
    //        console.log(err.code, err.message);
    //    });

});

function GetProfile() {
    liff.getProfile().then(profile => {
        headerCode = "";// profile.userId.substring(0, 6);
        
    }).catch(
        err => console.error(err)
    );
}