// Startup page
document.addEventListener("DOMContentLoaded", () => {
    if (isDebugMode == "0") {
        CheckLoginMainLineWithRedirect("https://chatclinic.tcg.or.th/tcghealthcheck_dev/views/RequestInfo/index");
        //liff.init({ liffId: '1657329342-OLdNakq0' })
        //    .then(() => {
        //        if (liff.isLoggedIn()) {

        //        } else {
        //            liff.login({ redirectUri: "https://chatclinic.tcg.or.th/tcghealthcheck_dev/views/RequestInfo/index" })
        //        }
        //    })
        //    .catch((err) => {
        //        console.log(err.code, err.message);
        //    });
    }
});

var qrcode = new QRCode("qrcode", {
    text: "",
    width: 168,
    height: 168,
    colorDark: "#000000",
    colorLight: "#ffffff",
    correctLevel: QRCode.CorrectLevel.H
});



var ContainerCallPrivilege = document.getElementById("modalCallPrivilege");
const modalCallPrivilege = new bootstrap.Modal(ContainerCallPrivilege);

var ContainerConditionPrivilege = document.getElementById("modalConditionPrivilege");
const modalConditionPrivilege = new bootstrap.Modal(ContainerConditionPrivilege);

var modalFixCon1 = document.getElementById("modalFixCon1");
const modalFixCon1xx = new bootstrap.Modal(modalFixCon1);

var modalFixMyCoupon = document.getElementById("modalFixMyCoupon");
const modalFixMyCouponxxx = new bootstrap.Modal(modalFixMyCoupon);




function ShowCondition(code) {

    var imgConditionLogo = document.getElementById("imgConditionLogo");
    var lblConditionTitle = document.getElementById("lblConditionTitle");
    var lblConditionDesc = document.getElementById("lblConditionDesc");
    var lblConditionDetail = document.getElementById("lblConditionDetail");
    var lblConditionEndDate = document.getElementById("lblConditionEndDate");
    var lblConditionUseCase = document.getElementById("lblConditionUseCase");

    var bufferRewardHeaderInfo = GetRewardDetailByRewardHeaderCode(code);
    if (bufferRewardHeaderInfo != null) {

        var bufferData = JSON.parse(bufferRewardHeaderInfo);

        imgConditionLogo.src = bufferData[0].LogoProgramPath;
        lblConditionTitle.innerHTML = bufferData[0].DetailTitle;
        lblConditionDesc.innerHTML = bufferData[0].DetailDescription;
        lblConditionDetail.innerHTML = bufferData[0].DetailCondition;
        lblConditionEndDate.innerHTML = bufferData[0].DetailEndDate;
        lblConditionUseCase.innerHTML = bufferData[0].DetailUseCase;
    }
    modalConditionPrivilege.show();

}
function ShowFixModal1() {
    modalConditionPrivilege.show();
}
function callFixPrivilege() {
    modalFixCon1xx.show();
}
function callFIXMyEventsCoupon() {
    var modalFixMyEventsCoupon = document.getElementById("modalFixMyEventsCoupon");
    const modalFixMyEventsCouponxxx = new bootstrap.Modal(modalFixMyEventsCoupon);


    modalFixMyEventsCouponxxx.show();
}
function callFixMyCoupon(rewardID) {
   

    var imgPartnerLogo = document.getElementById("imgPartnerLogo");
    var lblPartnerName = document.getElementById("lblPartnerName");
    var lblCouponTitle = document.getElementById("lblCouponTitle");
    var lblCouponDetail = document.getElementById("lblCouponDetail");
    var lblCouponCode = document.getElementById("lblCouponCode");


    var bufferRewardInfo = GetRewardByID(rewardID);
    if (bufferRewardInfo != null) {

        var bufferData = JSON.parse(bufferRewardInfo);

        imgPartnerLogo.src = bufferData.RewardLogoPath;
        lblPartnerName.innerHTML = bufferData.RewardOwner;
        lblCouponTitle.innerHTML = bufferData.RewardTitle;
        lblCouponDetail.innerHTML = bufferData.RewardDesc;
        lblCouponCode.innerHTML = bufferData.RewardCode;

        var sDate = new Date(bufferData.StartDate);
        var eDate = new Date(bufferData.EndDate);
        lblPeriod.innerHTML =
            //sDate.toLocaleDateString('th-TH', { year: 'numeric', month: 'short', day: 'numeric', })
            //+ ' - ' +
            eDate.toLocaleDateString('th-TH', { year: 'numeric', month: 'short', day: 'numeric', })


    }



    qrcode.clear(); // clear the code.
    qrcode.makeCode(bufferData.RewardCode); // make another code.

    modalCallPrivilege.show();
}

