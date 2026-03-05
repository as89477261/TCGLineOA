//function ShowModalConfirmApproved() {
//    const containerApproved = document.getElementById("ChooseBankNDIDModal7_2");
//    const modalApproved = new bootstrap.Modal(containerApproved);
//    modalApproved.show();

//    $('.modal-backdrop').fadeOut(0);
//}

//function onlyOne(checkbox) {
//    //console.log(checkbox);
//    var checkboxes = document.getElementsByName('check')
//    //console.log(checkboxes);
//    checkboxes.forEach((item) => {
//        if (item !== checkbox)
//            //console.log(item.checked)
//            item.checked = false
//    })
//}

//function GenerateObjPersonalChooseBank() {
//    console.log(1);
//    var chooseBank = "";
//    var inputs = document.querySelectorAll("input[type=checkbox]");
//    for (var i = 0; i < inputs.length; i++) {
//        if (inputs[i].type.toLowerCase() === 'checkbox') {
//            if (inputs[i].checked === true) {
//                chooseBank = inputs[i].value;
//            }
//        }
//    }
//    return chooseBank;
//}


//// Page Utility Function
//function CheckChooseBank() {
//    var checkCount = 0;
//    var inputs = document.querySelectorAll("input[type=checkbox]");
//    for (var i = 0; i < inputs.length; i++) {
//        if (inputs[i].checked === true) {
//            checkCount++;
//        }
//    }

//    if (checkCount > 0) {
//        return true;
//    } else {
//        return false;
//    }
//}

//// Validation
//function Validation() {
//    var result = true;
//    var buff = CheckChooseBank();
//    if (buff == false) {
//        console.log("Step 1 Check Personal Choose Bank is : " + buff)
//        result = false;
//    }
//    return result;
//}

//function ShowModalConfirmApproved() {
//    const containerApproved = document.getElementById("ChooseBankNDIDModal7_2");
//    const modalApproved = new bootstrap.Modal(containerApproved);
//    modalApproved.show();
//}

//document.querySelectorAll("[data-trigger-switch]").forEach((item) => {
//    item.addEventListener("click", function (e) {
//        e.preventDefault();
//        const targetSwitch = document.getElementById(this.getAttribute("data-trigger-switch"));
//        if (targetSwitch) {
//            targetSwitch.checked = !targetSwitch.checked;
//            onlyOne(targetSwitch);
//        }
//    });
//});


function ShowModalConfirmApproved() {
    const containerApproved = document.getElementById("ChooseBankNDIDModal7_2");
    const modalApproved = new bootstrap.Modal(containerApproved);
    modalApproved.show();

    $('.modal-backdrop').fadeOut(0);
}

function onlyOne(checkbox) {
    var checkboxes = document.getElementsByName('check');
    checkboxes.forEach((item) => {
        if (item !== checkbox) item.checked = false;
    });
}

// ฟังก์ชันเพื่อให้ data-trigger-switch ทำงาน
document.querySelectorAll("[data-trigger-switch]").forEach((item) => {
    item.addEventListener("click", function (e) {
        e.preventDefault();
        const targetSwitch = document.getElementById(this.getAttribute("data-trigger-switch"));
        if (targetSwitch) {
            targetSwitch.checked = !targetSwitch.checked;
            onlyOne(targetSwitch);
        }
    });
});
