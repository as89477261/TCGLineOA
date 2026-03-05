let idCardOriginalValue = ''
let idCardModifiedValue = ''
let phonePersonOriginalValue = ''
let phonePersonModifiedValue = ''
let jurusticIdCardOriginalValue = ''
let jurusticIdCardModifiedValue = ''
let jurusticPhoneOriginalValue = ''
let jurusticPhoneModifiedValue = ''

document.addEventListener("DOMContentLoaded", () => {

    let idcardValue = document.getElementById("txtPIDCard").value
    idCardOriginalValue = idcardValue;
    //console.log(idcardValue);
    //console.log(idCardOriginalValue);
    let maskedIdcardValue = idcardValue.replace(/^(\d{4})\d{5}(\d{4})$/, '$1xxxxx$2');
    //console.log(maskedIdcardValue);
    if (maskedIdcardValue != null && maskedIdcardValue != '') {
        let originalValue = txtPIDCard.value;
        let maskedValue = originalValue.replace(/^(\d{4})\d{5}(\d{4})$/, '$1xxxxx$2');
        idCardModifiedValue = maskedValue;
        txtPIDCard.value = maskedValue;
    }

    let idJurusticValue = document.getElementById("txtJVatID").value
    jurusticIdCardOriginalValue = idJurusticValue;
    //console.log(idJurusticValue);
    let maskedIdJurusticValue = idJurusticValue.replace(/^(\d{4})\d{5}(\d{4})$/, '$1xxxxx$2');
    //console.log(maskedIdJurusticValue);
    if (maskedIdJurusticValue != null && maskedIdJurusticValue != '') {
        let originalValue = txtJVatID.value;
        let maskedValue = originalValue.replace(/^(\d{4})\d{5}(\d{4})$/, '$1xxxxx$2');
        jurusticIdCardModifiedValue = maskedValue;
        txtJVatID.value = maskedValue;
    }

    let txtPPhoneValue = document.getElementById("txtPPhone").value
    phonePersonOriginalValue = txtPPhoneValue;
    let maskedtxtPPhoneValue = txtPPhoneValue.replace(/^(\d{2})\d{4}(\d{4})$/, '$1xxxx$2');
    console.log(phonePersonOriginalValue);
    if (maskedtxtPPhoneValue != null && maskedtxtPPhoneValue != '') {
        let originalValue = txtPPhone.value;
        let maskedValue = originalValue.replace(/^(\d{2})\d{4}(\d{4})$/, '$1xxxx$2');
        phonePersonModifiedValue = maskedValue;
        console.log(phonePersonModifiedValue)
        txtPPhone.value = maskedValue;
    }

    let txtJPhoneValue = document.getElementById("txtJPhone").value
    jurusticPhoneOriginalValue = txtJPhoneValue
    let maskedtxtJPhone = txtJPhoneValue.replace(/^(\d{2})\d{4}(\d{4})$/, '$1xxxx$2');
    //console.log(maskedtxtJPhone);
    if (maskedtxtJPhone != null && maskedtxtJPhone != '') {
        let originalValue = txtJPhone.value;
        let maskedValue = originalValue.replace(/^(\d{2})\d{4}(\d{4})$/, '$1xxxx$2');
        jurusticPhoneModifiedValue = maskedValue
        txtJPhone.value = maskedValue;
    }

    if (isDebugMode == "0") {
        CheckLoginMainLineWithRedirect("https://chatclinic.tcg.or.th/tcghealthcheck_dev/views/Profile/index");
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

function showHideFieldValue(filed) {

    switch (filed) {

        case "personIdCard":
            const idcardValue = document.getElementById('txtPIDCard').value
            //console.log(filedValue)
            if (idcardValue != idCardOriginalValue) {
                document.getElementById('txtPIDCard').value = idCardOriginalValue;
            }
            else {
                document.getElementById('txtPIDCard').value = idCardModifiedValue;
            }
            break;
        case "personPhone":
            const phonvalue = document.getElementById('txtPPhone').value
            //console.log(filedValue)
            if (phonvalue != phonePersonOriginalValue) {
                document.getElementById('txtPPhone').value = phonePersonOriginalValue;
            }
            else {
                document.getElementById('txtPPhone').value = phonePersonModifiedValue;
            }
            break;
        case "jurusticIdCard":
            const jurusticIdCard = document.getElementById('txtJVatID').value
            if (jurusticIdCard != jurusticIdCardOriginalValue) {
                document.getElementById('txtJVatID').value = jurusticIdCardOriginalValue
            }
            else {
                document.getElementById('txtJVatID').value = jurusticIdCardModifiedValue
            }
            break;
        case "jurusticPhone":
            const jurusticPhone = document.getElementById('txtJPhone').value
            if (jurusticPhone != jurusticPhoneOriginalValue) {
                document.getElementById('txtJPhone').value = jurusticPhoneOriginalValue
            }
            else {
                document.getElementById('txtJPhone').value = jurusticPhoneModifiedValue
            }
            break;
        default:
            break;
    }

}

var onloadCallback = function () {
    grecaptcha.render('Phtml_element', {
        'sitekey': '6LeW2owoAAAAAHx7cWk81dNFq3OW73tb62RynwQ6',
        'callback': ShowButtonConfirmStepP
    });

    grecaptcha.render('Jhtml_element', {
        'sitekey': '6LeW2owoAAAAAHx7cWk81dNFq3OW73tb62RynwQ6',
        'callback': ShowButtonConfirmStepJ
    });
};

function ShowButtonConfirmStepP() {
    var btn = document.getElementById("btnUpdatePersonalModal");
    btn.classList.remove("btn-disable");
}
function ShowButtonConfirmStepJ() {
    var btn = document.getElementById("btnUpdateJuristicModal");
    btn.classList.remove("btn-disable");
}

function ShowModal(type) {
    if (type === '1') {
        const modalP = document.getElementById("updatePersonalModal");
        const modalPDiv = new bootstrap.Modal(modalP);

        modalPDiv.show();
    } else {
        const modalJ = document.getElementById("updateCompanyModal");
        const modalJDiv = new bootstrap.Modal(modalJ);

        modalJDiv.show();
    }

}
function HideModal(name) {
    var modalPer = document.getElementById(name);
    var modalPerDiv = new bootstrap.Modal(modalPer);

    modalPer.style.display = "none";

    var mainTheme = document.getElementsByClassName("theme-light");
    mainTheme[0].style.overflow = "auto";

    var modalBackLog = document.getElementsByClassName("modal-backdrop");
    for (var i = 0; i < modalBackLog.length; i++) {
        modalBackLog[i].style.display = "none";
    }
}

function BindingUpdatedData(type) {
    if (type === '1') {
        var ddlP = document.getElementById("ddlTitlePersonal");
        document.getElementById("txtPIDCard").value = document.getElementById("txtUpdatePIDCard").value;
        document.getElementById("txtPTitle").value = ddlP.options[ddlP.selectedIndex].text;
        document.getElementById("txtPName").value = document.getElementById("txtUpdatePName").value;
        document.getElementById("txtPLastName").value = document.getElementById("txtUpdatePLastName").value;
        document.getElementById("txtEmail").value = document.getElementById("txtUpdatePEmail").value;
        document.getElementById("txtPPhone").value = document.getElementById("txtUpdatePMobilePhone").value;

    } else {
        var ddlC = document.getElementById("ddlTitleCompany");
        document.getElementById("txtJVatID").value = document.getElementById("txtUpdateJID").value;
        document.getElementById("txtJTitle").value = ddlC.options[ddlC.selectedIndex].text;;
        document.getElementById("txtJName").value = document.getElementById("txtUpdateJName").value;
        document.getElementById("txtJEmail").value = document.getElementById("txtUpdateJEmail").value;
        document.getElementById("txtJPhone").value = document.getElementById("txtUpdateJMobilePhone").value;

    }
}

function ValidatePersonalForm() {
    var result = true;
    var txtName = document.getElementById("txtUpdatePName");
    var txtLastName = document.getElementById("txtUpdatePLastName");
    var txtIDCard = document.getElementById("txtUpdatePIDCard");
    var txtMobile = document.getElementById("txtUpdatePMobilePhone");
    var txtEmail = document.getElementById("txtUpdatePEmail");

    if (txtName.value === "") {
        txtName.style.borderColor = 'red';
        result = false;
    } else {
        txtName.style.borderColor = 'silver';
    }

    if (txtLastName.value === "") {
        txtLastName.style.borderColor = 'red';
        result = false;
    } else {
        txtLastName.style.borderColor = 'silver';
    }

    if (txtIDCard.value === "") {
        txtIDCard.style.borderColor = 'red';
        result = false;
    } else {
        txtIDCard.style.borderColor = 'silver';
    }
    if (txtIDCard.value.length !== 13) {
        txtIDCard.style.borderColor = 'red';
        result = false;
    } else {
        txtIDCard.style.borderColor = 'silver';
    }

    if (txtMobile.value === "") {
        txtMobile.style.borderColor = 'red';
        result = false;
    } else {
        txtMobile.style.borderColor = 'silver';
    }

    if (txtEmail.value === "") {
        txtEmail.style.borderColor = 'red';
        result = false;
    } else {
        txtEmail.style.borderColor = 'silver';
    }
    return result;
}
function ValidateCompanyForm() {
    var result = true;
    var txtJName = document.getElementById("txtUpdateJName");
    var txtJID = document.getElementById("txtUpdateJID");
    var txtJMobilePhone = document.getElementById("txtUpdateJMobilePhone");
    var txtJEmail = document.getElementById("txtUpdateJEmail");

    if (txtJName.value === "") {
        txtJName.style.borderColor = 'red';
        result = false;
    } else {
        txtJName.style.borderColor = 'silver';
    }

    if (txtJID.value === "") {
        txtJID.style.borderColor = 'red';
        result = false;
    } else {
        txtJID.style.borderColor = 'silver';
    }

    if (txtJMobilePhone.value === "") {
        txtJMobilePhone.style.borderColor = 'red';
        result = false;
    } else {
        txtJMobilePhone.style.borderColor = 'silver';
    }

    if (txtJEmail.value === "") {
        txtJEmail.style.borderColor = 'red';
        result = false;
    } else {
        txtJEmail.style.borderColor = 'silver';
    }

    return result;
}

function GeneratePersonalObj(type) {
    if (type === '1') {
        var ddlPersonal = document.getElementById("ddlTitlePersonal");
        var pObj = {
            Code: document.getElementById("hddPCustomerProfileCode").value,
            IdCardType: "1",
            IdCard: document.getElementById("txtUpdatePIDCard").value,
            TitleName: ddlPersonal.value,
            TitleCode: ddlPersonal.value,
            Name: document.getElementById("txtUpdatePName").value,
            SureName: document.getElementById("txtUpdatePLastName").value,
            EmailAddress: document.getElementById("txtUpdatePEmail").value,
            MobileNumber: document.getElementById("txtUpdatePMobilePhone").value,
            CreateBy: "LineOA"
        };
        return pObj;
    } else {
        var ddlCompany = document.getElementById("ddlTitleCompany");
        var cObj = {
            Code: document.getElementById("hddJCustomerProfileCode").value,
            IdCardType: "2",
            IdCard: document.getElementById("txtUpdateJID").value,
            TitleName: ddlCompany.value,
            TitleCode: ddlCompany.value,
            Name: document.getElementById("txtUpdateJName").value,
            CompanyName: document.getElementById("txtUpdateJName").value,
            EmailAddress: document.getElementById("txtUpdateJEmail").value,
            MobileNumber: document.getElementById("txtUpdateJMobilePhone").value,
            CreateBy: "LineOA"
        };
        return cObj;
    }
}
function GetIsIdentify() {

}

function UpdateProfile(type) {
    var isPassValidate = false;

    if (type === '1') {
        isPassValidate = ValidatePersonalForm();

    } else {
        isPassValidate = ValidateCompanyForm();

    }


    if (isPassValidate) {
        var bufferObj = GeneratePersonalObj(type);
        var result = InsertCustomerProfileHistory(bufferObj);
        if (result === '"OK"') {

            BindingUpdatedData(type);
            HideModal('updatePersonalModal');
            HideModal('updateCompanyModal');
            FinishModal(true);
        } else {

            BindingUpdatedData(type);
            HideModal('updatePersonalModal');
            HideModal('updateCompanyModal');
            FinishModal(false);
        }
    }
}
function FinishModal(status) {
    if (status === true) {
        const modalSuccess = document.getElementById("confirmUpdateDataModal");
        const modalSuccessDiv = new bootstrap.Modal(modalSuccess);

        modalSuccessDiv.show();
    } else {
        const modalFail = document.getElementById("alertUpdateDataModal");
        const modalFailDiv = new bootstrap.Modal(modalFail);

        modalFailDiv.show();

    }

}