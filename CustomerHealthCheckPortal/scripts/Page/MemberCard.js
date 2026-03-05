
const container1 = document.getElementById("checkRegisterModal");
const container2 = document.getElementById("FinishModal");
const container3 = document.getElementById("ErrorModal");

const modalConfirm = new bootstrap.Modal(container1);
const modalFinish = new bootstrap.Modal(container2);
const modalError = new bootstrap.Modal(container3);

document.addEventListener('DOMContentLoaded', () => {

});


function OpenFinishModal() {
    if (ValidateForm() === true) {
        console.log("Validation is true");
        modalConfirm.show();

    } else {
        console.log("Validation is false");

    }

}
function KeepDataAndGoStep2(package) {
    console.log("Keep Data Step 1");
    setCookie("debtPID", package, 36500);

    console.log("Choose debt package : " + package);
    redirectToDebtStep2();

}
function KeepDataAndGoFinish() {
    console.log("Keep Data Step 2");

    var objCustomerProfile = GenerateCustomerProfileObject();
    var cusID = InsertCustomerProfile(objCustomerProfile);

    if (cusID !== "") {
        var objFormRegister = GenerateFormRegisterObject(cusID);
        var objFormRegisterTopUp = GenerateUIDMapDebtEventObject();

        var resultFormRegister = InsertFormFARegister(objFormRegister);
        var resultFormRegisterTopUp = InsertUIDMapFAEvent(objFormRegisterTopUp);

        console.log(resultFormRegister);

        if (resultFormRegister === '"OK"') {
            modalFinish.show();
        } else {
            modalError.show();
        }
    }

}
function OpenDebtPackage(eventCode) {
    let container4 = document.getElementById("ConfirmTopUpModal");
    let modalConfirmTopUp = new bootstrap.Modal(container4);

    var eventFACode = "";
    if (eventCode.toString().length == 1) {
        eventFACode = "00" + eventCode.toString();
    } else if (eventCode.toString().length == 2) {
        eventFACode = "0" + eventCode.toString();
    } else if (eventCode.toString().length == 3) {
        eventFACode = eventCode.toString();
    }

    setCookie("debtEID", eventFACode, 36500);

    switch (eventFACode) {
        case '004':
            modalConfirmTopUp.show();
            break;
        default:
            break;
    }
}

function BindingPersonal() {
    document.getElementById('ddlTitle').value = getCookie("pTitle");
    document.getElementById('txtFirstName').value = getCookie("pName");
    document.getElementById('txtLastName').value = getCookie("pLastName");
    document.getElementById('txtIDCard').value = getCookie("pIDCard");
    document.getElementById('txtBusinessName').value = getCookie("pCompany");
    document.getElementById('ddlProvince').value = getCookie("pProvince");
    document.getElementById('txtPhone').value = getCookie("pMobile");
}
function BindingJuristic() {
    document.getElementById('ddlTitle').value = getCookie("jTitle");
    document.getElementById('txtFirstName').value = getCookie("jName");
    document.getElementById('txtLastName').value = getCookie("jLastName");
    document.getElementById('txtIDCard').value = getCookie("jIDCard");
    document.getElementById('txtBusinessName').value = getCookie("jCompany");
    document.getElementById('ddlProvince').value = getCookie("jProvince");
    document.getElementById('txtPhone').value = getCookie("jMobile");
}
function ValidateForm() {
    var result = true;

    var ddlTitle = document.getElementById("ddlTitle");
    var txtFirstName = document.getElementById("txtFirstName");
    var txtLastName = document.getElementById("txtLastName");
    var txtBusinessName = document.getElementById("txtBusinessName");
    var ddlBusinessPosition = document.getElementById("ddlBusinessPosition");
    var txtIdCard = document.getElementById("txtIDCard");
    var ddlProvince = document.getElementById("ddlProvince");
    var txtPhone = document.getElementById("txtPhone");
    var ddlIncome = document.getElementById("ddlIncome");

    console.log("Title : " + ddlTitle.value);
    if (ddlTitle.value === "") {
        ddlTitle.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlTitle.style.border = "";
    }

    if (txtFirstName.value === "") {
        txtFirstName.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        txtFirstName.style.border = "";
    }

    if (txtLastName.value === "") {
        txtLastName.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        txtLastName.style.border = "";
    }
    if (txtBusinessName.value === "") {
        txtBusinessName.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        txtBusinessName.style.border = "";
    }
    if (ddlBusinessPosition.value === "") {
        ddlBusinessPosition.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlBusinessPosition.style.border = "";
    }



    if (txtIdCard.value === "") {
        txtIdCard.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        if (txtIdCard.value.length === 13 || txtIdCard.value.length === 10) {
            txtIdCard.style.border = "";
        } else {
            txtIdCard.style.border = "1px solid #CF0A0A";
            result = false;
        }
    }





    if (ddlProvince.value === "") {
        ddlProvince.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlProvince.style.border = "";
    }

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




    if (ddlIncome.value === "") {
        ddlIncome.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlIncome.style.border = "";
    }

    return result;
}


function GenFormatServiceObject() {
    var TitleName = document.getElementById("ddlTitle").value;
    switch (TitleName) {
        case "001":
            return 1;
        case "002":
            return 1;
        case "003":
            return 1;
        case "004":
            return 2;
        case "005":
            return 2;
        case "006":
            return 2;
        default:
            return 1;
    }
}
function GenerateCustomerProfileObject() {
    var Obj = {
        TitleName: document.getElementById("ddlTitle").value,
        UserFirstName: document.getElementById("txtFirstName").value,
        UserLastName: document.getElementById("txtLastName").value,
        CompanyName: document.getElementById("txtBusinessName").value,
        PositionInCompany: document.getElementById("ddlBusinessPosition").value,
        IdCard: document.getElementById("txtIDCard").value,
        Province: document.getElementById("ddlProvince").value,
        Mobile: document.getElementById("txtPhone").value,
        TypeCompany: 4,
        FormatService: GenFormatServiceObject(),
        TypeProductOrService: '-',
        CreateBy: '9991'
    };
    console.log("Generate CustomerProfile Object");
    return Obj;

}
function GenerateFormRegisterObject(cusID) {

    var cusIDNumber = parseInt(cusID.replace('"', ''));
    var packageID = getCookie("debtPID");
    var incomeData = document.getElementById('ddlIncome').value;
    var uid = getCookie("uid");
    var Obj = {
        UID: uid,
        ApplicationId: '2',
        CustomerProfileId: cusIDNumber,
        ChannelId: '2',
        CurrentStatusId: '80',
        CreateBy: '9991',
        FA_Ref: document.getElementById("txtIDCard").value,
        Dept_Recon_ObjectId: packageID,
        Dept_Recon_Money: incomeData

    };
    console.log("Generate FormRegister Object");
    return Obj;

}
function GenerateUIDMapTransactionObject(cusID) {


    var packageID = getCookie("debtPID");
    var incomeData = document.getElementById('ddlIncome').value;
    var Obj = {
        ApplicationId: '2',
        CustomerProfileId: cusIDNumber,
        ChannelId: '2',
        CurrentStatusId: '80',
        CreateBy: '9991',
        Dept_Recon_ObjectId: packageID,
        Dept_Recon_Money: incomeData
    };
    console.log("Generate FormRegister Object");
    return Obj;

}
function GenerateUIDMapDebtEventObject() {

    var eventCode = getCookie("debtEID");
    var uid = getCookie("uid");
    var idCard = "";
    var pidCard = getCookie("pIDCard");
    var jidCard = getCookie("jIDCard");
    var txtIdCard = document.getElementById("txtIDCard");

    if (txtIdCard != null && txtIdCard != 'undefined' && txtIdCard != '') {
        idCard = txtIdCard.value;
    } else {
        idCard = (pidCard != null && pidCard != 'undefined' && pidCard != '' ? pidCard : jidCard);
    }

    var Obj = {
        UID: uid,
        EventCode: eventCode,
        IDCard: idCard,
        CreatedBy: 'system'
    };
    console.log("Generate UIDMapFAEvent Object");
    return Obj;
}


function RegisterUIDMapDebtEvent() {
    var obj = GenerateUIDMapDebtEventObject();
    var result = InsertUIDMapFAEvent(obj);

    console.log(result);
    if (result == '"OK"') {
        swal("เสร็จสิ้น", "ระบบบันทึกผลการลงทะเบียนของท่านเรียบร้อยแล้ว", "success").then(() => { redirectToMain(); });
    } else {
        swal("เกิดข้อผิดพลาด", "ระบบไม่สามารถบันทึกผลการลงทะเบียนได้", "warning");
    }
}

