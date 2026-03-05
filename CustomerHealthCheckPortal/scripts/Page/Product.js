
const container = document.getElementById("confirmFinishStep");
const modal = new bootstrap.Modal(container);

document.getElementById("btnCFClose").addEventListener("click", function () {
    modal.hide();
});
document.getElementById("btnCFSave").addEventListener("click", function () {

    loaderStep4(true);
});

function loaderStep4(isShow) {
    if (isShow) {
        var cfBodyWording = document.getElementById("confirmFinishStepPanel");
        var cfBodyLoader = document.getElementById("confirmFinishStepLoader");
        var cfBtnClose = document.getElementById("btnCFClose");
        var cfBtnSubmit = document.getElementById("btnCFSave");

        //cfBodyWording.style.display = "none";
        //cfBodyLoader.style.display = "block";
        cfBtnClose.classList.add("disableOnLoading");
        cfBtnSubmit.classList.add("disableOnLoading");
        cfBtnSubmit.innerText = "กำลังบันทึก . . .";
    }
}
function KeepHealthCheckCookie(itemID) {

    setCookie("hcid", itemID, 3650);
    console.log(getCookie("hcid"));
    redirectToStep3();

}
function KeepProductCookie(productID) {
    setCookie("pid", productID, 3650);
    let uid = getCookie("uid");

    console.log("Step2 Get UID : " + uid + " PID : " + productID);

    var result = GetApprochByUIDAndPCode(productID, uid);
    console.log("Step2 Get IsRegisterProdicut is : " + result);
    if (result === '"OK"') {
        const modalElement = document.getElementById("checkRegisterModal");
        const modalDiv = new bootstrap.Modal(modalElement);

        modalDiv.show();
    } else {
        redirectToStep2();
    }
}

function CheckSendBank() {
    var checkCount = 0;
    var inputs = document.querySelectorAll("input[type=checkbox]");
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].checked === true) {
            checkCount++;
        }
    }

    if (checkCount > 0) {
        var confirmFinishModal = bootstrap.Modal.getOrCreateInstance(document.getElementById('confirmFinishStep'));
        confirmFinishModal.show();
    } else {
        var notFoundModal = bootstrap.Modal.getOrCreateInstance(document.getElementById('NotFoundBank'));
        notFoundModal.show();
    }
}
function CheckRegisterSameProduct() {

}

function GenerateUIDObject() {

    var lstObj = [];
    var inputs = document.querySelectorAll("input[type=checkbox]");

    for (var i = 0; i < inputs.length; i++) {

        if (inputs[i].type.toLowerCase() === 'checkbox') {

            if (inputs[i].checked === true) {
                var bankEmail = inputs[i].value;
                var bankCode = inputs[i].id.replace('switch-', '');
                var obj = {
                    ApprochID: getCookie("approchid"),
                    BankCode: bankCode,
                    BankEmail: bankEmail,
                    CreatedBy: 'system'
                };
                lstObj.push(obj);
            }
        }
    }
    return lstObj;
}

function FinishStep() {



    var resultCallAPI = "";
    let promise = new Promise(function (resolve, reject) {
        setTimeout(() => resolve(1), 1000);
    });

    promise.then(function (result) {

        return result * 2;
    });

    promise.then(function (result) {
        var approchID = getCookie("approchid");
        var buffer = GenerateUIDObject();
        resultCallAPI = InsertApprochMapBank(buffer, approchID);
        return result * 2;
    });

    promise.then(function (result) {

        if (resultCallAPI != "undefined" && resultCallAPI === '"OK"') {
            modal.hide();

            var successFinishModal = bootstrap.Modal.getOrCreateInstance(document.getElementById('successFinishStep'));
            successFinishModal.show();
        }
        return result * 2;
    });
}

