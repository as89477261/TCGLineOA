
var onloadCallback = function () {
    grecaptcha.render('html_element', {
        'sitekey': '6LeW2owoAAAAAHx7cWk81dNFq3OW73tb62RynwQ6',
        'callback': ShowButtonConfirmStep
    });
};

function ShowButtonConfirmStep() {
    var btn = document.getElementById("btnSubmit");
    btn.classList.remove("btn-disable");
}

//EventActivityRegister
function OpenSuccessRegisterPlusLinkContact() {
    swal("เสร็จสิ้น", "ระบบบันทึกผลการลงทะเบียนของท่านเรียบร้อยแล้ว หากมีข้อเสนอแนะและข้อคิดเห็นเพิ่มเติม คลิก", "success", {
        className: "boxstyle",

        buttons: {

            New: {
                text: "ข้อเสนอแนะ",

                value: "contactus",

                visible: true,
            },

            New2: {
                text: "เสร็จสิ้น",

                value: "index",

                visible: true,

            },
        },
    }).then((value) => {
        switch (value) {

            case "contactus":
                window.location.href = "https://www.tcg.or.th/contactus_form.php?Channel=Activity";
                break;

            case "index":
                redirectToMain();
                break;

            default:
                redirectToMain();
        }
    });
}

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
    const container1 = document.getElementById("ConfirmRegisterModal");
    const modalConfirm = new bootstrap.Modal(container1);
    modalConfirm.show();
}

function OpenSuccessRegister() {
    //const container2 = document.getElementById("FinishModal");
    //const modalFinish = new bootstrap.Modal(container2);
    //modalFinish.show();

    swal("เสร็จสิ้น", "ระบบบันทึกผลการลงทะเบียนของท่านเรียบร้อยแล้ว", "success").then(() => { redirectToMain(); });

}

function OpenError() {
    //const container3 = document.getElementById("ErrorModal");
    //const modalError = new bootstrap.Modal(container3);
    //modalError.show();
    swal("เกิดข้อผิดพลาด", "ระบบไม่สามารถบันทึกผลการลงทะเบียนได้", "error");
}
function OpenRegistered() {

    //const modalElement = document.getElementById("RegisteredModal");
    //const modalDiv = new bootstrap.Modal(modalElement);

    //modalDiv.show();
    swal("แจ้งเตือน", "ท่านลงทะเบียนเข้าร่วมมาตรการเรียบร้อยแล้ว", "warning");
  
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

function ChooseEvent(formRegister, code, isCheckDuplicate) {
    try {
        var isRegistered = "";
        var eventID = "";
        if (code.toString().length == 1) {
            eventID = "00" + code.toString();
        } else if (code.toString().length == 2) {
            eventID = "0" + code.toString();
        } else if (code.toString().length == 3) {
            eventID = code.toString();
        }

        /*var eventID = '001';*/
        var uid = getCookie("uid");
        setCookie("eventID", eventID, 36500);

        if (isCheckDuplicate === 1) {
            isRegistered = ValidateRegistered(eventID, uid);
        }


        if (isRegistered.length === 0) {
            console.log("Can Register Event : " + eventID);
            redirectToRegisterWithFormAndCode(formRegister, eventID);
        } else {
            console.log("Can Not Register Event : " + eventID);

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
function RegisterEventOneStep() {

    if (ValidateStep1() && ValidateStep2()) {
        OpenConfirmRegister();
    }
}
function KeepDataAndFinish() {
    var obj = GenerateFormObj();
    var result = InsertFormEventRegisterDynamic(obj);

    console.log("API result is : "+result);
    if (result === '"OK"') {
        //OpenSuccessRegisterPlusLinkContact();
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

    if (ddlBusinessType != null) {
        if (ddlBusinessType.value === "") {
            ddlBusinessType.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            ddlBusinessType.style.border = "";
        }
    }

    if (txtBusinessName != null) {
        if (txtBusinessName.value === "") {
            txtBusinessName.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            txtBusinessName.style.border = "";
        }
    }

    if (txtFirstName != null) {
        if (txtFirstName.value === "") {
            txtFirstName.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            txtFirstName.style.border = "";
        }
    }

    if (txtLastName != null) {
        if (txtLastName.value === "") {
            txtLastName.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            txtLastName.style.border = "";
        }
    }

    if (txtPosition != null) {
        if (txtPosition.value === "") {
            txtPosition.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            txtPosition.style.border = "";
        }
    }

    if (txtPhone != null) {
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

    if (txtEmail != null) {
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

    if (ddlBusinessNature != null) {
        if (ddlBusinessNature.value === "") {
            ddlBusinessNature.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            ddlBusinessNature.style.border = "";
        }
    }

    if (ddlProvince != null) {
        if (ddlProvince.value === "") {
            ddlProvince.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            ddlProvince.style.border = "";
        }
    }

    if (txtCompanyAge != null) {
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
    }

    if (txtIncomePerYear != null) {
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
    }

    if (ddlStatementBank != null) {
        if (ddlStatementBank.value === "") {
            ddlStatementBank.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            ddlStatementBank.style.border = "";
        }
    }
    //if (txtBranch.value === "") {
    //    txtBranch.style.border = "1px solid #CF0A0A";
    //    result = false;
    //} else {
    //    txtBranch.style.border = "";
    //}

    if (ddlPurpose != null) {
        if (ddlPurpose.value === "") {
            ddlPurpose.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            ddlPurpose.style.border = "";
        }
    }

    if (txtLoanMoney != null) {
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
    }


    if (ddlProvince != null) {
        if (ddlProvince.value === "") {
            ddlProvince.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            ddlProvince.style.border = "";
        }
    }

    if (ddlHaveMainBank != null) {
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
    }


    if (ddlHaveAssetGarantee != null) {
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
    }

    if (ddlPurpostFromBank != null) {
        if (ddlPurpostFromBank.value === "") {
            ddlPurpostFromBank.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            ddlPurpostFromBank.style.border = "";
        }
    }

    //return true;
    return result;
}

function GenerateFormObj() {

    var eventID = getCookie("eventID");
    var uid = getCookie("uid");

    var Obj = {
        UID: uid,        
        EventCode: eventID,
        BusinessType: document.getElementById("ddlBusinessType").value,
        BusinessName: document.getElementById("txtBusinessName").value,
        FirstName: document.getElementById("txtFirstName").value,
        LastName: document.getElementById("txtLastName").value,      
        Phone: document.getElementById("txtPhone").value,
        Email: document.getElementById("txtEmail").value,
             
        Q1: document.getElementById("ddlProvince").value,       
        Q2: document.getElementById("txtLoanMoney").value,
        Q3: document.getElementById("ddlHaveMainBank").value,
        Q4: document.getElementById("ddlHaveMainBankSelectBank").value       

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



