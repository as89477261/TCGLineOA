// Startup page
document.addEventListener("DOMContentLoaded", () => {
    if (isDebugMode == "0") {
        CheckLoginMainLineWithRedirect("https://chatclinic.tcg.or.th/tcghealthcheck_dev/views/RequestInfo/index");
    }

    console.log(getCookie("LToken"));
});

var onloadCallback = function () {
    grecaptcha.render('html_element', {
        'sitekey': '6LeW2owoAAAAAHx7cWk81dNFq3OW73tb62RynwQ6',
        'callback': ShowButtonConfirmStep
    });
};

function ShowButtonConfirmStep() {
    var btn = document.getElementById("btnStep3");
    btn.classList.remove("btn-disable");
}

function ShowFullCoupon() {

    var bufferItem = "<a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>" +
        "<div class='align-self-center'>" +
        "<span class='icon me-2 shadow-bg shadow-bg-xs rounded-s'>" +
        "<img src='" + '../../images/logos/pt.jpg' + "' width='45' class='rounded-s' alt='img'></span>" +
        "</div>" +
        "<div class='align-self-center ps-1'>" +
        "<label class='pt-1 mb-n1' style='font-size: 14px; color: black; font-weight: 500;'>" + 'คูปองส่วนลดกาแฟพันธ์ไทย' + "</label>" +
        "<p class='mb-0 font-11 opacity-70'><span class=''>" + 'สิ้นสุดโครงการ 31-12-2567' + "</span></p>" +
        "</div>" +
        "<div class='align-self-center ms-auto text-end'>" +
        "<span class='btn btn-xl gradient-yellow shadow-bg shadow-bg-xs ' style='font-size: 18px; padding: 0px 12px;' >" +
        "สิทธิ์เต็ม" +
        "</div>" +
        "</a>";

    var div = document.createElement("div");
    div.innerHTML = bufferItem;

    var panelParent = document.getElementById("tab-5");
    var panel = document.getElementById("ContentPlaceHolder1_pnlRewardEmpty");
    if (typeof panel != 'undefined') {
        panel.style.display = "none";
        panelParent.appendChild(div);
    }


}

var ContainerCallPrivilege = document.getElementById("modalCallPrivilege");
const modalCallPrivilege = new bootstrap.Modal(ContainerCallPrivilege);

var ContainerConditionPrivilege = document.getElementById("modalConditionPrivilege");
const modalConditionPrivilege = new bootstrap.Modal(ContainerConditionPrivilege);

var ContainerOTPPrivilege = document.getElementById("modalOTPPrivilege");
const modalOTPPrivilege = new bootstrap.Modal(ContainerOTPPrivilege);


var qrcode = new QRCode("qrcode", {
    text: "",
    width: 168,
    height: 168,
    colorDark: "#000000",
    colorLight: "#ffffff",
    correctLevel: QRCode.CorrectLevel.H
});
var CallPrivilegePanel = modalCallPrivilege;

function ShowCondition(ownerCode, programCode) {

    var imgConditionLogo = document.getElementById("imgConditionLogo");
    var imgConditionLogo2 = document.getElementById("imgConditionLogo2");
    var lblConditionTitle = document.getElementById("lblConditionTitle");
    var lblConditionDesc = document.getElementById("lblConditionDesc");
    var lblConditionDetail = document.getElementById("lblConditionDetail");
    var lblConditionEndDate = document.getElementById("lblConditionEndDate");
    var lblConditionUseCase = document.getElementById("lblConditionUseCase");
    var lblConditionTitle2 = document.getElementById("lblConditionTitle2");

    var hddOwnerCode = document.getElementById("hddOwnerCode");
    var hddProgramCode = document.getElementById("hddProgramCode");
    var hddStartDate = document.getElementById("hddStartDate");
    var hddEndDate = document.getElementById("hddEndDate");

    var bufferRewardHeaderInfo = GetRewardDetailByRewardHeaderCode(ownerCode, programCode);
    if (bufferRewardHeaderInfo != null) {

        var bufferData = JSON.parse(bufferRewardHeaderInfo);
       
        imgConditionLogo.src = bufferData[0].LogoProgramPath;
        imgConditionLogo2.src = bufferData[0].LogoProgramPath;

        lblConditionTitle.innerHTML = bufferData[0].DetailTitle;
        lblConditionDesc.innerHTML = bufferData[0].DetailDescription;
        lblConditionDetail.innerHTML = bufferData[0].DetailCondition;
        lblConditionEndDate.innerHTML = bufferData[0].DetailEndDate;
        lblConditionUseCase.innerHTML = bufferData[0].DetailUseCase;
        lblConditionTitle2.innerHTML = bufferData[0].DetailTitle;

        hddOwnerCode.value = bufferData[0].RewardOwnerCode;
        hddProgramCode.value = bufferData[0].RewardProgramCode;
        hddStartDate.value = bufferData[0].StartDate;
        hddEndDate.value = bufferData[0].EndDate;
    }
    GetCoupon('1');
    modalConditionPrivilege.show();

}

function GetUIDMapReward() {
    var uid = getCookie("uid");
    var hddOwnerCode = document.getElementById("hddOwnerCode").value;
    var hddProgramCode = document.getElementById("hddProgramCode").value;

    var passCon = CheckRewardCondition(uid, hddOwnerCode, hddProgramCode);
    console.log("CheckRewardCondition : " + passCon);
    if (passCon == '"SUCCESS"') {

        var item = GetUIDMapRewardProgram(uid, hddOwnerCode, hddProgramCode);
        console.log("GetUIDMapReward : " + item);
        if (item == '"SUCCESS"') {

            GetCoupon('2');

        } else if (item == '"FULL"') {
            LoaderInActive();
            swal("แจ้งเตือน", "สิทธิพิเศษเต็มแล้ว", "warning").then(function () {

            });

        } else {
            LoaderInActive();
            swal("แจ้งเตือน", "สิทธิ์เต็ม หรือท่านเคยรับสิทธิ์แล้ว", "warning").then(function () {

            });
        }
    } else {
        LoaderInActive();
        swal("แจ้งเตือน", "เงื่อนไขยังไม่ครบเพื่อขอรับสิทธิ์", "warning").then(function () {

        });
    }
}

function CalPrivilege(rewardID) {

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

function GetCoupon(step) {
    var modalStep1 = document.getElementById("modal-body-step1");
    var modalStep2 = document.getElementById("modal-body-step2");

    var pnlBtnStep1 = document.getElementById("pnlBtnStep1");
    var pnlBtnStep2 = document.getElementById("pnlBtnStep2");

    var modalTitle = document.getElementById("modalConditionPrivilegeLabel");

    modalStep1.style.display = "none";
    modalStep2.style.display = "none";

    pnlBtnStep1.style.display = "none";
    pnlBtnStep2.style.display = "none";

    switch (step) {
        case "1":
            modalStep1.style.display = "block";
            pnlBtnStep1.style.display = "block";
            modalTitle.innerHTML = "รายละเอียดเงื่อนไขลุ้นรับคูปอง";

            break;

        case "2":
            modalStep2.style.display = "block";
            pnlBtnStep2.style.display = "block";
            modalTitle.innerHTML = "ยืนยัน OTP รับคูปอง";

            break;

        default:
            break;
    }

    ShowVerifiesOTP('0');
}

function ShowVerifiesOTP(isShow) {
    var modalStep3 = document.getElementById("modal-body-step3");

    if (isShow == '1') {
        if (VerifyPhoneNumber()) {

            LoaderActive();
            ShowLoading().then(() => {
                SendOTP_CoreSendOTP();
            });

            modalStep3.style.display = "block";


        }
    } else {
        modalStep3.style.display = "none";
    }
}
function ConfirmVerifiesOTP() {

    var obj = GenerateConfirmObj();
    console.log("obj is : " + JSON.stringify(obj));

    if (typeof obj != 'undefined') {
        //var result = SendPersonalOTP(dummyID, phoneNumber);
        let result = SendRewardConfirmOTP(obj);
        console.log("Result Step 2 Confirm OTP is : " + result)


        if (result == '"SUCCESS"') {
            modalConditionPrivilege.hide();
            swal("แจ้งเตือน", "ยืนยัน OTP เสร็จสิ้น", "success").then(function () {
                location.reload();
            });
        } else {

            swal("แจ้งเตือน", "ยืนยัน OTP ผิดพลาด", "error").then(function () {

            });
        }
    } else {
        console.log("obj is : Null");
    }

}

function VerifyPhoneNumber() {
    var txtPhoneNumber = document.getElementById("txtPhoneNumber");
    if (txtPhoneNumber.value != "" && txtPhoneNumber.value.length == 10) {

        txtPhoneNumber.classList.remove("validateFail");
        return true;
    } else {

        txtPhoneNumber.classList.add("validateFail");
        return false;
    }
}
function VerifyOTP() {
    var txtOTP = document.getElementById("txtOTP");
    if (txtOTP.value != "") {

        txtOTP.classList.remove("validateFail");
        return true;
    } else {

        txtOTP.classList.add("validateFail");
        return false;
    }
}

function ShowLoading() {
    return new Promise((resolve) => {
        setTimeout(() => {

            loader.classList.add("loader--show");
            resolve('true')
        }, 10);
    })
}

function GenerateRewardObj() {

    var ownerCode = document.getElementById("hddOwnerCode").value;
    var programCode = document.getElementById("hddProgramCode").value;
    var startDate = document.getElementById("hddStartDate").value;
    var endDate = document.getElementById("hddEndDate").value;
    var uid = getCookie("uid");
    var token = getCookie("LToken");
    let date = getDate();

    var Obj = {
        UID: uid,
        rewardOwnerCode: ownerCode,
        rewardProgramCode: programCode,
        phoneNumber: document.getElementById("txtPhoneNumber").value,
        token: token,
        startdate: startDate,
        enddate: endDate,
    };
    console.log(Obj);
    
    return Obj;
}
function GenerateConfirmObj() {

    var ownerCode = document.getElementById("hddOwnerCode").value;
    var programCode = document.getElementById("hddProgramCode").value;
    var uid = getCookie("uid");
    var token = getCookie("LToken");
    let date = getDate();

    var Obj = {
        UID: uid,
        rewardOwnerCode: ownerCode,
        rewardProgramCode: programCode,
        phoneNumber: document.getElementById("txtPhoneNumber").value,
        token: token,
        startdate: date,
        enddate: date,
        OTP: document.getElementById("txtOTP").value,
        OTPRef: document.getElementById("ltlReferenceNumber").innerHTML
    };
    console.log(Obj);
    return Obj;
}

async function SendOTP_CoreSendOTP() {
    DisableAndCounting("disable");
    var obj = GenerateRewardObj();
    var phoneNumber = document.getElementById("txtPhoneNumber").value;
    var ltlReferenceNumber = document.getElementById("ltlReferenceNumber");

    console.log("obj is : " + JSON.stringify(obj));

    if (phoneNumber != "") {
        var resultSendOTP = await CallServiceSendOTP(obj);
        sendOTPObj = JSON.parse(resultSendOTP);

        console.log(sendOTPObj.Messagej);

        if (sendOTPObj.Message == "Duplicate") {
            LoaderInActive();
            GetCoupon('1');
            swal('แจ้งเตือน', 'เคยขอรับสิทธิพิเศษนี้แล้ว', 'warning');
            return;
        }

        if (resultSendOTP != "" && resultSendOTP != "undefined") {

            ltlReferenceNumber.innerHTML = sendOTPObj.OTPRef;

            console.log('OTP : ' + resultSendOTP);
            console.log("Send OTP Status is : " + sendOTPObj.OTPRef);

            LoaderInActive();
        } else {
            LoaderInActive();
            swal('แจ้งเตือน', 'กรุณาลองอีกครั้ง', 'warning');
        }
    }
}

function DisableAndCounting(action) {

    console.log("Disable button and send OTP");

    var limitCounting = 3;
    var btnSendOTP = document.getElementById("btnSendOTP");

    if (action == "disable") {
        btnSendOTP.classList.add("btn-disable");
        btnSendOTP.classList.remove("gradient-blue");
        CountDownResend();
    } else {
        btnSendOTP.classList.remove("btn-disable");
        btnSendOTP.classList.add("gradient-blue");
        btnSendOTP.innerText = "ขอรหัส OTP";
    }
}

function CountDownResend() {

    var minute = 4;
    var sec = 60;
    var interval = setInterval(function () {
        document.getElementById("btnSendOTP").style.color = "black";
        document.getElementById("btnSendOTP").innerHTML = minute + ":" + sec;
        sec--;

        if (sec == 00) {
            minute--;

            if (minute > 0) {
                sec = 60;

            } else {
                clearInterval(interval);
                DisableAndCounting("Enable");
                return;
            }
        }
    }, 1000);

}

async function CallServiceSendOTP(obj) {
    if (typeof obj != 'undefined') {
        //var result = SendPersonalOTP(dummyID, phoneNumber);
        let result = await SendRewardOTPAsync(obj);

        return result;
    }

}

const inputField = document.querySelector('#txtPhoneNumber');

inputField.onkeydown = (event) => {
    // Only allow if the e.key value is a number or if it's 'Backspace'
    if (isNaN(event.key) && event.key !== 'Backspace') {
        event.preventDefault();
    }
};

function onlyNumberKey(evt) {

    //// Only ASCII character in that range allowed
    //let ASCIICode = (evt.which) ? evt.which : evt.keyCode
    //if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57))
    //    return false;
    //return true;

    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;

}

function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

function CheckPhoneNumber() {
    var txtPhone = document.getElementById("txtPhoneNumber");

    if (txtPhone.value === "") {
        txtPhone.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        if (txtPhone.value.length === 9 || txtPhone.value.length === 10) {
            txtPhone.style.border = "";
        } else {
            txtPhone.style.border = "1px solid #CF0A0A";
            result = false;
        }
    }
}

function IsNumeric(input) {
    var RE = /^-?(0|INF|(0[1-7][0-7]*)|(0x[0-9a-fA-F]+)|((0|[1-9][0-9]*|(?=[\.,]))([\.,][0-9]+)?([eE]-?\d+)?))$/;
    return (RE.test(input));
}