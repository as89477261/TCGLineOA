// Startup page
document.addEventListener("DOMContentLoaded", () => {
    if (isDebugMode == "0") {
        CheckLoginMainLineWithRedirect("https://chatclinic.tcg.or.th/tcghealthcheck_dev/views/RequestInfo/index");

    }


});

// Front end Function
function onlyOne(checkbox) {
    var checkboxes = document.getElementsByName('check')

    checkboxes.forEach((item) => {
        if (item !== checkbox) item.checked = false
    })
}
function ShowModalConfirmApproved() {
    const containerApproved = document.getElementById("ChooseBankNDIDModal");
    const modalApproved = new bootstrap.Modal(containerApproved);
    modalApproved.show();
}
function ShowModalConfirmUseOldNCBData() {
    const ConfirmUseOldNCBDataModal = document.getElementById("ConfirmUseOldNCBDataModal");
    const ConfirmUseOldNCBDataModalControl = new bootstrap.Modal(ConfirmUseOldNCBDataModal);
    ConfirmUseOldNCBDataModalControl.show();
}
function ConfirmApprovedForm() {
    var containerApproved = document.getElementById("lblChooseBankRequestNumber");
    var lstRequestNo = document.getElementById("hddLstOnlineID").value;
    var idCard = document.getElementById("hddIDCard").value;
    containerApproved.innerHTML = lstRequestNo.slice(0, -1);

    var ncbHistoryObj = GetNCBHistory(idCard);
    if (typeof ncbHistoryObj !== 'undefined') {

        var buffer = JSON.parse(ncbHistoryObj)
        console.log('Data : ' + buffer.RESULT_OBJ);
        console.log('LstRequestNo ' + lstRequestNo);
        console.log('IDCard ' + idCard);

        if (typeof buffer.RESULT_OBJ !== 'undefined') {
            document.getElementById("hddNCBGrade").value = buffer.RESULT_OBJ.T01NCBGrade;
            document.getElementById("hddNCBScore").value = buffer.RESULT_OBJ.T01NCBScore;
            document.getElementById("hddNCBTransID").value = buffer.RESULT_OBJ.TransID;

            ShowModalConfirmUseOldNCBData();

        } else {
            ShowModalConfirmApproved();
        }
    } else {
        ShowModalConfirmApproved();
    }
}
function ConfirmApprovePreviousNCBScore() {
    var bufferObj = GenerateObjNCBPreRequestAndCyber();
    var result = InsertNCBPreRequest(bufferObj);

    console.log(result);

    //location.reload();
    swal('แจ้งเตือน', 'ยืนยันคำขอเสร็จสิ้น', 'success').then(function () {
        window.location = "/views/RequestInfo/index";
    });


}

// Page Utility Function
function CheckChooseBank() {
    var checkCount = 0;
    var inputs = document.querySelectorAll("input[type=checkbox]");
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].checked === true) {
            checkCount++;
        }
    }

    if (checkCount > 0) {
        return true;
    } else {
        return false;
    }
}

// Validation
function Validation() {
    var result = true;
    var buff = CheckChooseBank();
    if (buff == false) {
        console.log("Step 1 Check Personal Choose Bank is : " + buff)
        result = false;
    }
    return result;
}
function ValidateEmail() {
    var condition = "";
    var message = "";
    var textboxEmailEConsentSlip = document.getElementById("textboxEmailEConsentSlip");
    var switch3 = document.getElementById("switch-3");

    var filter = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    var resultPattern = filter.test(textboxEmailEConsentSlip.value)

    if (switch3.value == "0") {
        if (textboxEmailEConsentSlip.value != "") {
            if (resultPattern == false) {
                condition += "Error";
                message += "Pattern : false \r\n";
            } else {
                message += "Pattern : true \r\n";
            }
        }
    } else {

        if (resultPattern == false) {
            condition += "Error";
            message += "Pattern : false \r\n";
        } else {
            message += "Pattern : true \r\n";
        }

        if (textboxEmailEConsentSlip.value == "") {
            condition += "Error";
            message += "IsEmpty : false \r\n";

        } else {
            message += "IsEmpty : true \r\n";
        }
    }

    console.log(message);
    if (condition != "") {
        textboxEmailEConsentSlip.style.border = "1px solid red";
        return false;
    } else {
        textboxEmailEConsentSlip.style.border = "1px solid whitesmoke";
        return true;
    }

}

// Generate OBJ
function GenerateObjNDIDForm(ref) {
    var idCard = document.getElementById("hddIDCard").value;
    var firstName = document.getElementById("hddFirstName").value;
    var lstName = document.getElementById("hddLastName").value;
    var dob = document.getElementById("hddDob").value;
    var mobileNo = document.getElementById("hddMobileNo").value;
    var email = document.getElementById("hddEmail").value;
    //var productCode = "ขอคํ้าประกันสินเชื่อกับ บสย."
    var productCode = "38";
    var productName = "การค้ำประกันเงินกู้";

    var obj = {
        uid: ref,
        idp: GenerateObjPersonalChooseBank(),
        request_option: "2",
        request_params: {
            uuid: GenerateUUID(), //"550e8400-e29b-41d4-a716-446655440000",
            member_shortname: "TCG",
            citizen_id: idCard,
            firstname: firstName,
            lastname: lstName,
            dob: dob,
            mobile_no: mobileNo,
            email: email,
            product_code: productCode,
            product_code_description: productName,
            trn_type: "F2F",
            version: "2",
        },
    };
    return obj;

}
function GenerateObjPreNDIDForm(ref) {

    var lstObj = [];
    var rawLstOnlineID = document.getElementById("hddLstOnlineID").value;
    var lstOnlineID = rawLstOnlineID.split('/');
    var personalChooseBank = GenerateObjPersonalChooseBank();
    LocalLog("Step 3 : Personal Choose : " + personalChooseBank + " bank");

    for (var i = 0; i < lstOnlineID.length; i++) {
        if (lstOnlineID[i] != "") {
            var obj = {
                UID: getCookie("uid"),
                NDIDReferenceID: ref,
                StepName: 'รอยืนยันคำขอ',
                StepNumber: '1',
                Status: false,
                T01OnlineID: lstOnlineID[i],
                T01OnlineIDStep: 'เริ่มยืนยันตัวตน',
                CreatedBy: "SYSTEM",
                PersonalChooseBank: personalChooseBank
            };
            lstObj.push(obj);
        }
    }

    return lstObj;
}
function GenerateObjPersonalChooseBank() {
    var chooseBank = "";
    var inputs = document.querySelectorAll("input[type=checkbox]");
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].type.toLowerCase() === 'checkbox') {
            if (inputs[i].checked === true) {
                chooseBank = inputs[i].value;
            }
        }
    }
    return chooseBank;
}
function GenerateObjENCBConsentSlip(NDIDRef) {
    var idCard = document.getElementById("hddIDCard").value;
    var firstName = document.getElementById("hddFirstName").value;
    var lstName = document.getElementById("hddLastName").value;
    var dob = document.getElementById("hddBirthDate").value;
    var mobileNo = document.getElementById("hddMobileNo").value;
    var email = document.getElementById("hddEmail").value;
    var isRequestEConsentSlip = document.getElementById("switch-3").value;
    //var productCode = "ขอคํ้าประกันสินเชื่อกับ บสย."
    var productCode = "38";
    var productName = "การค้ำประกันเงินกู้";

    console.log("Request EConsent Slip : " + isRequestEConsentSlip);
    var obj = {
        UIDReferenceID: NDIDRef,
        FirstName: firstName,
        LastName: lstName,
        BirthDate: dob,
        IDCard: idCard,
        MobilePhone: mobileNo,
        ProductType: productCode + "-" + productName,
        Email: email,
        IsRequestEConsentSlip: (isRequestEConsentSlip == '1' ? true : false),
        RequestEConsentSlipDate: ""
    };
    console.log(obj);

    return obj;
}
function GenerateObjNCBPreRequestAndCyber(NDIDRef) {

    var NCBGradeData = document.getElementById("hddNCBGrade").value;
    var NCBScoreData = document.getElementById("hddNCBScore").value;
    var NCBTransID = document.getElementById("hddNCBTransID").value;

    var rawLstOnlineID = document.getElementById("hddLstOnlineID").value;
    var r = randomString(5);
    var NDIDRef = getCookie("uid") + "|" + r + "|" + rawLstOnlineID;

    var obj = {
        ID: "",
        UID: getCookie("uid"),
        NDIDReferenceID: NDIDRef,
        NCBResultID: "",
        StepName: "ยืนยันเสร็จสิ้น",
        StepNumber: "3",
        IsSuccessNDID: true,
        Status: true,
        T01OnlineID: rawLstOnlineID,
        T01OnlineIDStep: "อัพเดท NCB Score เสร็จสิ้น",
        CreatedBy: "SYSTEM",
        NCBTransactionID: NCBTransID,
        PersonalChooseBank: "",
        IsSuccessNCB: true,
        NCBGrade: NCBGradeData,
        NCBScore: NCBScoreData,


    };
    console.log(obj);

    return obj;
}
// Main Action
function ApprovedSubmitForm() {

    var dummyID = document.getElementById("hddRegisterDummyID").value;
    var email = document.getElementById("textboxEmailEConsentSlip").value;

    LoaderActive();
    var isValidForm = Validation();
    LocalLog("Step 1 : Validate input form : " + isValidForm);

    if (isValidForm) {
        var rawLstOnlineID = document.getElementById("hddLstOnlineID").value;
        var r = randomString(5);
        var NDIDRef = getCookie("uid") + "|" + r + "|" + rawLstOnlineID;

        LocalLog("Step 2 : Generate NDID Ref : " + NDIDRef);

        var preNdidObj = GenerateObjPreNDIDForm(NDIDRef);
        LocalLog("Step 3 : Generate JSON PreNDIDForm Data : " + JSON.stringify(preNdidObj));

        var isInsertLogPreNDID = InsertUIDMapNDIDPreRequest(preNdidObj);
        LocalLog("Step 4.1 : Insert UID Map PreRequest Approve TCGRequest : " + isInsertLogPreNDID);

        var isUpdateEnrollmentPersonalEmail = UpdateEnrollPersonalEmail(dummyID, email);
        LocalLog("Step 4.2 : Update Enrollment Personal Email  : " + isUpdateEnrollmentPersonalEmail);

        var isInsertStep1ENCBConsentSlip = Step1InsertNCBConsentSlip(NDIDRef);
        LocalLog("Step 4.3 : Create Initial ENCBConsentSlip Data  : " + isInsertStep1ENCBConsentSlip);


        if (isInsertLogPreNDID == '"OK"') {

            var ndidObj = GenerateObjNDIDForm(NDIDRef);
            LocalLog("Step 5 : Generate JSON NDIDForm Data : " + JSON.stringify(ndidObj));

            if (ndidObj != "") {

                //alert(JSON.stringify(ndidObj));
                //let result = HttpRequest("http://192.168.10.20:3000/ncb/request_params", "POST", JSON.stringify(obj))
                var url = CallNDIDEForm(ndidObj);
                LocalLog(url);
                LocalLog("Step 6 : Request To NDID Blockchain Node : " + JSON.stringify(url));

                // Redesign URL
                url = url.replace('"', '').replace(' ', '').replace('2"', '2');
                url = url.replace('http://192.168.13.20/?', 'line://app/1657329342-oJz0ePmV?');
                url = url.replace('https://tcgid.tcg.or.th/?', 'line://app/1657329342-oJz0ePmV?');
                url = url.replace('https://tcgiduat.tcg.or.th/?', 'line://app/1657329342-oJz0ePmV?');
                LocalLog("Step 7 : Redesign NDID URL for Line TCG URL : " + url);

                //url = url.replace('https://tcgiduat.tcg.or.th/?','https://liff.line.me/1657329342-oJz0ePmV?liff.state=');

                // Recheck For Login page before redirect to ndid page
                liff.init({ liffId: '1657329342-OLdNakq0' })
                    .then(() => {
                        if (liff.isLoggedIn()) {
                            window.location.href = url;
                        } else {
                            alert('กรุณาเข้าระบบผ่าน Line ก่อนเข้าใช้งานระบบ');
                        }
                    })
                    .catch((err) => {
                        console.log(err.code, err.message);
                    });
            } else {
                LoaderInActive();
                swal('แจ้งเตือน', 'กรุณาเลือกธนาคารที่ท่านเคยยืนยันตัวตน (KYC)', 'warning');
            }
        } else {
            LoaderInActive();
            swal('แจ้งเตือน', 'กรุณาทำรายการอีกครั้งหลังจากนี้', 'warning');
        }
    } else {
        LoaderInActive();
        swal('แจ้งเตือน', 'กรุณาเลือกธนาคารที่ท่านเคยยืนยันตัวตน (KYC)', 'warning');
    }

}

function ShowPanel(pnl) {
    const modalContent1 = document.getElementById("modalContent1");
    const modalContent2 = document.getElementById("modalContent2");

    if (pnl == '1') {
        modalContent1.style.display = 'block';
        modalContent2.style.display = 'none';

    } else {
        if (ValidateEmail() == true) {
            modalContent1.style.display = 'none';
            modalContent2.style.display = 'block';
        }
    }
}
function ShowDownloadSlipPanel(pnl) {
    const pnlNCBEConsentSlip = document.getElementById("pnlNCBEConsentSlip");
    if (pnl == '1') {
        pnlNCBEConsentSlip.style.display = 'block';
    } else {
        pnlNCBEConsentSlip.style.display = 'none';
    }
}
function ShowLabelEmailRequire() {
    var lblRequireEmail = document.getElementById("lblRequireEmail");
    var lblOptionEmail = document.getElementById("lblOptionEmail");
    var switch3 = document.getElementById("switch-3");

    if (switch3.value == "0") {
        switch3.value = "1"
        lblRequireEmail.style.display = "block";
        lblOptionEmail.style.display = "none";
    } else {
        switch3.value = "0";
        lblRequireEmail.style.display = "none";
        lblOptionEmail.style.display = "block";
    }


}

function DownloadFile() {
    var transID = document.getElementById("hddTransID").value;
    var apiURL = document.getElementById("hddENCBConsentAPI").value;
    console.log(apiURL + transID);

    liff.openWindow({
        url: apiURL + transID,
        //url: "http://localhost:56955/api/encbconsentslip/data/7370467E-D940-4F6C-81CD-2F8A64319F62",
        //url: "https://demo.tcg.or.th/LineOAFront_dev/api/requestinfo/encbconsent/pdf",
        external: true
    });

}

function Step1InsertNCBConsentSlip(NDIDRef) {
    var objBuffer = GenerateObjENCBConsentSlip(NDIDRef);
    InsertENCBConsentSlipInfo(objBuffer);
}
