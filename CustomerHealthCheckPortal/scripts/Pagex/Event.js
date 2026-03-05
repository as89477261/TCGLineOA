
const container1 = document.getElementById("ConfirmRegisterModal");
const container2 = document.getElementById("FinishModal");
const container3 = document.getElementById("ErrorModal");



const modalConfirm = new bootstrap.Modal(container1);
const modalFinish = new bootstrap.Modal(container2);
const modalError = new bootstrap.Modal(container3);


//document.addEventListener('DOMContentLoaded', () => {

//});


//document.getElementById("txtIncomePerYear").addEventListener("change", function () {
//    var data = document.getElementById("txtIncomePerYear").value.replace(/[$,]+/g, "").replace(".00", "")
//    data = data.replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");   
//    document.getElementById("txtIncomePerYear").value  = data;
//});

//document.getElementById("txtLoanMoney").addEventListener("change", function () {
//    var data = document.getElementById("txtLoanMoney").value.replace(/[$,]+/g, "").replace(".00", "")
//    data = data.replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");
//    document.getElementById("txtLoanMoney").value = data;
//});

//document.getElementById("txtHaveAssetGaranteeValue").addEventListener("change", function () {
//    var data = document.getElementById("txtHaveAssetGaranteeValue").value.replace(/[$,]+/g, "").replace(".00", "")
//    data = data.replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");
//    document.getElementById("txtHaveAssetGaranteeValue").value = data;
//});

function OpenConfirmRegister() {
    modalConfirm.show();
}
function OpenSuccessRegister() {
    modalFinish.show();
}
function OpenError() {
    modalError.show();
}
function OpenRegistered() {

    const modalElement = document.getElementById("RegisteredModal");
    const modalDiv = new bootstrap.Modal(modalElement);

    modalDiv.show();
}

function GotoStep2() {
    if (ValidateStep1()) {
        var step1 = document.getElementById("step1");
        var step2 = document.getElementById("step2");

        step1.style.display = "none";
        step2.style.display = "flex";
    }
}
function GotoStep1() {
    var step1 = document.getElementById("step1");
    var step2 = document.getElementById("step2");

    step1.style.display = "flex";
    step2.style.display = "none";
}
function ToggleMainLoanBankValue() {
    var ddlHaveMainBank = document.getElementById("ddlHaveMainBank");
    var divHaveMainBankSelectBank = document.getElementById("divHaveMainBankSelectBank");

    if (ddlHaveMainBank.value === "002") {
        divHaveMainBankSelectBank.style.display = "flex";
    } else {
        divHaveMainBankSelectBank.style.display = "none";
    }


}
function ToggleMainAssetValue() {
    var ddlHaveAssetGarantee = document.getElementById("ddlHaveAssetGarantee");
    var divHaveAssetGaranteeValue = document.getElementById("divHaveAssetGaranteeValue");

    if (ddlHaveAssetGarantee.value === "002") {
        divHaveAssetGaranteeValue.style.display = "flex";
    } else {
        divHaveAssetGaranteeValue.style.display = "none";
    }

}

function ChooseEvent(formEvent,eventCode) {
    try {
        /*var eventID = '001';*/
        var uid = getCookie("uid");
        setCookie("eventID", eventCode, 36500);

        var isRegistered = ValidateRegistered(eventCode, uid);
      
        if (isRegistered.length === 0) {    
            console.log("Can Register Event : " + eventCode);
            redirectToRegister();
        } else {
            console.log("Can Not Register Event : " + eventCode);    

            OpenRegistered();
            
        }
    }
    catch (err) {
        //alert(err.message);
    }
}
function RegisterEvent() {

    if (ValidateStep2()) {
        OpenConfirmRegister();
    }
}
function KeepDataAndFinish() {
    var obj = GenerateFormObj();
    var result = InsertFormEventRegister(obj);

    if (result === '"OK"') {
        OpenSuccessRegister();
    } else {
        OpenError();
    }
}

function BindingPersonal() {

    document.getElementById('txtFirstName').value = getCookie("pName");
    document.getElementById('txtLastName').value = getCookie("pLastName");
    document.getElementById('txtBusinessName').value = getCookie("pCompany");
    document.getElementById('ddlProvince').value = getCookie("pProvince");
    document.getElementById('txtPhone').value = getCookie("pMobile");
}
function BindingJuristic() {

    document.getElementById('txtFirstName').value = '';
    document.getElementById('txtLastName').value = '';
    document.getElementById('txtBusinessName').value = getCookie("jCompany");
    document.getElementById('ddlProvince').value = getCookie("jProvince");
    document.getElementById('txtPhone').value = getCookie("jMobile");
}
function ValidateRegistered(eventCode, UID) {
    try {
        var json = GetFormRegisterWithEventCodeAndUID(eventCode, UID);
        var data = JSON.parse(json);
        return data;
    }
    catch (err) {
        return '';
    }
}
function ValidateStep1() {
    var result = true;

    var ddlBusinessType = document.getElementById("ddlBusinessType");
    var txtBusinessName = document.getElementById("txtBusinessName");
    var txtFirstName = document.getElementById("txtFirstName");
    var txtLastName = document.getElementById("txtLastName");
    var txtPosition = document.getElementById("txtPosition");
    var txtPhone = document.getElementById("txtPhone");
    var txtEmail = document.getElementById("txtEmail");

    console.log("BusinessType : " + ddlBusinessType.value);
    if (ddlBusinessType.value === "") {
        ddlBusinessType.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlBusinessType.style.border = "";
    }
    if (txtBusinessName.value === "") {
        txtBusinessName.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        txtBusinessName.style.border = "";
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
    if (txtPosition.value === "") {
        txtPosition.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        txtPosition.style.border = "";
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
    if (txtEmail.value === "") {
        txtEmail.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        var isEmail = ValidateEmail(txtEmail.value);
        if (isEmail === false) {
            txtEmail.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            txtEmail.style.border = "";
        }       
    }

    return result;
    //return true;
}
function ValidateStep2() {
    var result = true;

    var ddlBusinessNature = document.getElementById("ddlBusinessNature");
    var ddlProvince = document.getElementById("ddlProvince");
    var txtCompanyAge = document.getElementById("txtCompanyAge");
    var txtIncomePerYear = document.getElementById("txtIncomePerYear");
    var ddlStatementBank = document.getElementById("ddlStatementBank");
    //var txtBranch = document.getElementById("txtBranch");
    var ddlPurpose = document.getElementById("ddlPurpose");
    var txtLoanMoney = document.getElementById("txtLoanMoney");
    var ddlHaveMainBank = document.getElementById("ddlHaveMainBank");
    var ddlHaveAssetGarantee = document.getElementById("ddlHaveAssetGarantee");
    var ddlPurpostFromBank = document.getElementById("ddlPurpostFromBank");

    console.log("BusinessNature : " + ddlBusinessNature.value);
    if (ddlBusinessNature.value === "") {
        ddlBusinessNature.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlBusinessNature.style.border = "";
    }

    if (ddlProvince.value === "") {
        ddlProvince.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlProvince.style.border = "";
    }

    if (txtCompanyAge.value === "") {
        txtCompanyAge.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        let data = parseInt(txtCompanyAge.value);
        if (data > 150) {
            txtCompanyAge.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            txtCompanyAge.style.border = "";
        }
    }

    if (txtIncomePerYear.value === "") {
        txtIncomePerYear.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        let data = parseInt(txtIncomePerYear.value.replace(/[$,]+/g, "").replace(".00", ""));
        if (data > 1000000000) {
            txtIncomePerYear.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            txtIncomePerYear.style.border = "";
        }
    }

    if (ddlStatementBank.value === "") {
        ddlStatementBank.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlStatementBank.style.border = "";
    }
    //if (txtBranch.value === "") {
    //    txtBranch.style.border = "1px solid #CF0A0A";
    //    result = false;
    //} else {
    //    txtBranch.style.border = "";
    //}


    if (ddlPurpose.value === "") {
        ddlPurpose.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlPurpose.style.border = "";
    }


    if (txtLoanMoney.value === "") {
        txtLoanMoney.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        let data = parseInt(txtLoanMoney.value.replace(/[$,]+/g, "").replace(".00", ""));
        if (data > 1000000000) {
            txtLoanMoney.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            txtLoanMoney.style.border = "";
        }
    }



    if (ddlProvince.value === "") {
        ddlProvince.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlProvince.style.border = "";
    }

    if (ddlHaveMainBank.value === "") {
        ddlHaveMainBank.style.border = "1px solid #CF0A0A";
        result = false;
    } else {

        ddlHaveMainBank.style.border = "";
        if (ddlHaveMainBank.value === "002") {
            if (ddlHaveMainBankSelectBank.value === "") {
                ddlHaveMainBankSelectBank.style.border = "1px solid #CF0A0A";
                result = false;
            } else {
                ddlHaveMainBankSelectBank.style.border = "";
            }
        }
    }



    if (ddlHaveAssetGarantee.value === "") {
        ddlHaveAssetGarantee.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlHaveAssetGarantee.style.border = "";
        if (ddlHaveAssetGarantee.value === "002") {
            if (txtHaveAssetGaranteeValue.value === "") {
                txtHaveAssetGaranteeValue.style.border = "1px solid #CF0A0A";
                result = false;
            } else {
                let data = parseInt(txtHaveAssetGaranteeValue.value.replace(/[$,]+/g, "").replace(".00", ""));
                if (data > 1000000000) {
                    txtHaveAssetGaranteeValue.style.border = "1px solid #CF0A0A";
                    result = false;
                } else {
                    txtHaveAssetGaranteeValue.style.border = "";
                }
            }
        }
    }



    if (ddlPurpostFromBank.value === "") {
        ddlPurpostFromBank.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlPurpostFromBank.style.border = "";
    }

    //return true;
    return result;
}

function GenerateFormObj() {

    var eventID = getCookie("eventID");
    var uid = getCookie("uid");

    var Obj = {
        UID: uid,
        eventID: eventID,
        FormCode: eventID,
        BusinessType: document.getElementById("ddlBusinessType").value,
        BusinessName: document.getElementById("txtBusinessName").value,
        FirstName: document.getElementById("txtFirstName").value,
        LastName: document.getElementById("txtLastName").value,
        Position: document.getElementById("txtPosition").value,
        Phone: document.getElementById("txtPhone").value,
        Email: document.getElementById("txtEmail").value,

        BusinessNature: document.getElementById("ddlBusinessNature").value,
        BusinessProvince: document.getElementById("ddlProvince").value,
        CompanyAge: document.getElementById("txtCompanyAge").value,
        IncomePerYear: document.getElementById("txtIncomePerYear").value,
        StatementBank: document.getElementById("ddlStatementBank").value,
        Branch: '',//document.getElementById("txtBranch").value,
        Purpose: document.getElementById("ddlPurpose").value,
        LoanMoney: document.getElementById("txtLoanMoney").value,

        HaveMainBank: document.getElementById("ddlHaveMainBank").value,
        HaveMainBankSelectBank: document.getElementById("ddlHaveMainBankSelectBank").value,
        HaveAssetGarantee: document.getElementById("ddlHaveAssetGarantee").value,
        HaveAssetGaranteeValue: document.getElementById("txtHaveAssetGaranteeValue").value,
        PurpostFromBank: document.getElementById("ddlPurpostFromBank").value,

    };
    console.log("Generate FormRegister Object");
    return Obj;
}

function ToggleRegisterButton(eventID, type) {
    var btnRegisName = "btnRegis" + eventID;
    var btnCancelName = "btnCancel" + eventID;

    var btnRegis = document.getElementById(btnRegisName);
    var btnCancel = document.getElementById(btnCancelName);

    if (type === "register") {
        btnRegis.style.display = "none";
        btnCancel.style.display = "block";
    } else {
        btnRegis.style.display = "block";
        btnCancel.style.display = "none";
    }

}



