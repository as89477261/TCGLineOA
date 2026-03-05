document.addEventListener("DOMContentLoaded", () => {

    document.querySelectorAll('.card-body h5').forEach(function (element) {

        console.log('element', element);

        let currentText = element.innerText;
        //console.log(currentText);

        if (currentText.includes('หนังสือสัญญาค้ำประกัน เลขที่ :')) {

            let cleanCurrentText = currentText.replace(/\s+:\s+/, ': ').trim();
            console.log(cleanCurrentText);

            let modifiedText = cleanCurrentText.replace(/(\d{4})\d{4}/, '$1xxxx');
            console.log(modifiedText);

            console.log(currentText);
            element.innerText = modifiedText

        }

    }); 

    // Data Marking ส่วน เลข LG ซ้ายบนหน้าจอ
    const strongElements = document.querySelectorAll('.card-top.no-click.font-12.p-3.color-black.font-monospace');

    strongElements.forEach(element => {
        let content = element.textContent.trim(); // ดึงข้อความใน element
        //console.log(content);

        // ตรวจสอบว่ามีตัวเลขเพียงพอและทำการ mark 4 ตัวหลัง
        if (content.length >= 4) {

            let cleanCurrentText = content.trim();
            //console.log(cleanCurrentText);
            let modifiedText = cleanCurrentText.slice(0, 4) + 'xxxx';
            //console.log(modifiedText);

            element.textContent = modifiedText;
        }
    });

    if (isDebugMode == "0") {
        CheckLoginMainLineWithRedirect("https://chatclinic.tcg.or.th/tcghealthcheck_dev/views/LG/index");
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
  
    const myCarouselElement = document.querySelector('[data-bs-target="#carouselCardLGNew"]')
    const carousel = new bootstrap.Carousel(myCarouselElement, {
        interval: 5000,
        touch: true
    })


    //document.addEventListener("DOMContentLoaded", function () {
    //    setTimeout(function () {
    //        const myCarouselElement = document.querySelector('[data-bs-target="#carouselCardLGNew"]');
    //        if (myCarouselElement) {
    //            const carousel = new bootstrap.Carousel(myCarouselElement, {
    //                interval: 5000,
    //                touch: true
    //            });
    //        } else {
    //            console.error("Element #carouselCardLGNew ไม่พบใน DOM");
    //        }
    //    }, 1000); // หน่วงเวลาให้ Repeater โหลดเสร็จก่อน
    //    return true;
    //});


});

function btnDownloadLG() {
    window.location.href + host
    //        ('C:/Users/application1/LG/6606089.pdf'); 
};

//mylg_items;

//document.addEventListener('DOMContentLoaded', () => {

//    //var bufferCookie = getCookie("mylg_items");
//    //var bufferObject = JSON.parse(bufferCookie);
//    //alert(bufferObject);
//});
//var test;
//function BindingMYLGDetail(index) {

//    var bufferCookie = getCookie("mylg_items");
//    if (bufferCookie != "" && bufferCookie.length > 0) { 

//        bufferCookie = bufferCookie;
//        var bufferObject = JSON.parse(bufferCookie);
//        console.log("index is : " + index);

//        if (bufferObject != null) {
//            console.log("bufferObject is : " + bufferObject.toString());
//            var buffer = bufferObject[index];
//            if (buffer != null) {


//                test = buffer;
//                console.log("buffer is : " + buffer.toString());

//                document.getElementById("ltlProjectName").innerHTML = buffer.ProjectName.replace(/\+/g, ' ');
//                document.getElementById("ltlBankName").innerHTML = buffer.BankName.replace(/\+/g, ' ');
//                document.getElementById("ltlCreateDate").innerHTML = buffer.CreateDate.replace(/\+/g, ' ');
//                document.getElementById("ltlRequestName").innerHTML = buffer.RequestName.replace(/\+/g, ' ');
//                document.getElementById("ltlGuaranteePrice").innerHTML = SetFormatMoney(buffer.GuaranteePrice.replace(/\+/g, ' '));
//                document.getElementById("ltlObjective").innerHTML = buffer.Objective.replace(/\+/g, ' ');

//            }

//        }
//    }
//}

//function SetFormatMoney(input) {
//    var amt = "";
//    for (let i = input.length - 1, j = 1; i >= 0; i--, j++) {
//        amt = input[i] + amt;
//        if (j % 3 == 0 && i != 0) { amt = "," + amt; }
//    }
//    return amt;
//}



//const container1 = document.getElementById("checkRegisterModal");
//const container2 = document.getElementById("FinishModal");
//const container3 = document.getElementById("ErrorModal");

//const modalConfirm = new bootstrap.Modal(container1);
//const modalFinish = new bootstrap.Modal(container2);
//const modalError = new bootstrap.Modal(container3);

//document.addEventListener('DOMContentLoaded', () => {

//});


//function OpenFinishModal() {
//    if (ValidateForm() === true) {
//        console.log("Validation is true");
//        modalConfirm.show();

//    } else {
//        console.log("Validation is false");

//    }

//}
//function KeepDataAndGoStep2(package) {
//    console.log("Keep Data Step 1");
//    setCookie("debtPID", package, 36500);

//    console.log("Choose debt package : " + package);
//    redirectToDebtStep2();

//}
//function KeepDataAndGoFinish() {
//    console.log("Keep Data Step 2");

//    var objCustomerProfile = GenerateCustomerProfileObject();
//    var cusID = InsertCustomerProfile(objCustomerProfile);

//    if (cusID !== "") {
//        var objFormRegister = GenerateFormRegisterObject(cusID);
//        var objFormRegisterTopUp = GenerateUIDMapDebtEventObject();

//        var resultFormRegister = InsertFormFARegister(objFormRegister);
//        var resultFormRegisterTopUp = InsertUIDMapFAEvent(objFormRegisterTopUp);

//        console.log(resultFormRegister);

//        if (resultFormRegister === '"OK"') {
//            modalFinish.show();
//        } else {
//            modalError.show();
//        }
//    }

//}
//function OpenDebtPackage(eventCode) {
//    let container4 = document.getElementById("ConfirmTopUpModal");
//    let modalConfirmTopUp = new bootstrap.Modal(container4);

//    var eventFACode = "";
//    if (eventCode.toString().length == 1) {
//        eventFACode = "00" + eventCode.toString();
//    } else if (eventCode.toString().length == 2) {
//        eventFACode = "0" + eventCode.toString();
//    } else if (eventCode.toString().length == 3) {
//        eventFACode = eventCode.toString();
//    }

//    setCookie("debtEID", eventFACode, 36500);

//    switch (eventFACode) {
//        case '004':
//            modalConfirmTopUp.show();
//            break;
//        default:
//            break;
//    }
//}

//function BindingPersonal() {
//    document.getElementById('ddlTitle').value = getCookie("pTitle");
//    document.getElementById('txtFirstName').value = getCookie("pName");
//    document.getElementById('txtLastName').value = getCookie("pLastName");
//    document.getElementById('txtIDCard').value = getCookie("pIDCard");
//    document.getElementById('txtBusinessName').value = getCookie("pCompany");
//    document.getElementById('ddlProvince').value = getCookie("pProvince");
//    document.getElementById('txtPhone').value = getCookie("pMobile");
//}
//function BindingJuristic() {
//    document.getElementById('ddlTitle').value = getCookie("jTitle");
//    document.getElementById('txtFirstName').value = getCookie("jName");
//    document.getElementById('txtLastName').value = getCookie("jLastName");
//    document.getElementById('txtIDCard').value = getCookie("jIDCard");
//    document.getElementById('txtBusinessName').value = getCookie("jCompany");
//    document.getElementById('ddlProvince').value = getCookie("jProvince");
//    document.getElementById('txtPhone').value = getCookie("jMobile");
//}
//function ValidateForm() {
//    var result = true;

//    var ddlTitle = document.getElementById("ddlTitle");
//    var txtFirstName = document.getElementById("txtFirstName");
//    var txtLastName = document.getElementById("txtLastName");
//    var txtBusinessName = document.getElementById("txtBusinessName");
//    var ddlBusinessPosition = document.getElementById("ddlBusinessPosition");
//    var txtIdCard = document.getElementById("txtIDCard");
//    var ddlProvince = document.getElementById("ddlProvince");
//    var txtPhone = document.getElementById("txtPhone");
//    var ddlIncome = document.getElementById("ddlIncome");

//    console.log("Title : " + ddlTitle.value);
//    if (ddlTitle.value === "") {
//        ddlTitle.style.border = "1px solid #CF0A0A";
//        result = false;
//    } else {
//        ddlTitle.style.border = "";
//    }

//    if (txtFirstName.value === "") {
//        txtFirstName.style.border = "1px solid #CF0A0A";
//        result = false;
//    } else {
//        txtFirstName.style.border = "";
//    }

//    if (txtLastName.value === "") {
//        txtLastName.style.border = "1px solid #CF0A0A";
//        result = false;
//    } else {
//        txtLastName.style.border = "";
//    }
//    if (txtBusinessName.value === "") {
//        txtBusinessName.style.border = "1px solid #CF0A0A";
//        result = false;
//    } else {
//        txtBusinessName.style.border = "";
//    }
//    if (ddlBusinessPosition.value === "") {
//        ddlBusinessPosition.style.border = "1px solid #CF0A0A";
//        result = false;
//    } else {
//        ddlBusinessPosition.style.border = "";
//    }



//    if (txtIdCard.value === "") {
//        txtIdCard.style.border = "1px solid #CF0A0A";
//        result = false;
//    } else {
//        if (txtIdCard.value.length === 13 || txtIdCard.value.length === 10) {
//            txtIdCard.style.border = "";
//        } else {
//            txtIdCard.style.border = "1px solid #CF0A0A";
//            result = false;
//        }
//    }





//    if (ddlProvince.value === "") {
//        ddlProvince.style.border = "1px solid #CF0A0A";
//        result = false;
//    } else {
//        ddlProvince.style.border = "";
//    }

//    if (txtPhone.value === "") {
//        txtPhone.style.border = "1px solid #CF0A0A";
//        result = false;
//    } else {
//        if (txtPhone.value.length === 9 || txtPhone.value.length === 10) {
//            txtPhone.style.border = "";
//        } else {
//            txtPhone.style.border = "1px solid #CF0A0A";
//            result = false;
//        }
//    }




//    if (ddlIncome.value === "") {
//        ddlIncome.style.border = "1px solid #CF0A0A";
//        result = false;
//    } else {
//        ddlIncome.style.border = "";
//    }

//    return result;
//}


//function GenFormatServiceObject() {
//    var TitleName = document.getElementById("ddlTitle").value;
//    switch (TitleName) {
//        case "001":
//            return 1;
//        case "002":
//            return 1;
//        case "003":
//            return 1;
//        case "004":
//            return 2;
//        case "005":
//            return 2;
//        case "006":
//            return 2;
//        default:
//            return 1;
//    }
//}
//function GenerateCustomerProfileObject() {
//    var Obj = {
//        TitleName: document.getElementById("ddlTitle").value,
//        UserFirstName: document.getElementById("txtFirstName").value,
//        UserLastName: document.getElementById("txtLastName").value,
//        CompanyName: document.getElementById("txtBusinessName").value,
//        PositionInCompany: document.getElementById("ddlBusinessPosition").value,
//        IdCard: document.getElementById("txtIDCard").value,
//        Province: document.getElementById("ddlProvince").value,
//        Mobile: document.getElementById("txtPhone").value,
//        TypeCompany: 4,
//        FormatService: GenFormatServiceObject(),
//        TypeProductOrService: '-',
//        CreateBy: '9991'
//    };
//    console.log("Generate CustomerProfile Object");
//    return Obj;

//}
//function GenerateFormRegisterObject(cusID) {

//    var cusIDNumber = parseInt(cusID.replace('"', ''));
//    var packageID = getCookie("debtPID");
//    var incomeData = document.getElementById('ddlIncome').value;
//    var uid = getCookie("uid");
//    var Obj = {
//        UID: uid,
//        ApplicationId: '2',
//        CustomerProfileId: cusIDNumber,
//        ChannelId: '2',
//        CurrentStatusId: '80',
//        CreateBy: '9991',
//        FA_Ref: document.getElementById("txtIDCard").value,
//        Dept_Recon_ObjectId: packageID,
//        Dept_Recon_Money: incomeData

//    };
//    console.log("Generate FormRegister Object");
//    return Obj;

//}
//function GenerateUIDMapTransactionObject(cusID) {


//    var packageID = getCookie("debtPID");
//    var incomeData = document.getElementById('ddlIncome').value;
//    var Obj = {
//        ApplicationId: '2',
//        CustomerProfileId: cusIDNumber,
//        ChannelId: '2',
//        CurrentStatusId: '80',
//        CreateBy: '9991',
//        Dept_Recon_ObjectId: packageID,
//        Dept_Recon_Money: incomeData
//    };
//    console.log("Generate FormRegister Object");
//    return Obj;

//}
//function GenerateUIDMapDebtEventObject() {

//    var eventCode = getCookie("debtEID");
//    var uid = getCookie("uid");
//    var idCard = "";
//    var pidCard = getCookie("pIDCard");
//    var jidCard = getCookie("jIDCard");
//    var txtIdCard = document.getElementById("txtIDCard");

//    if (txtIdCard != null && txtIdCard != 'undefined' && txtIdCard != '') {
//        idCard = txtIdCard.value;
//    } else {
//        idCard = (pidCard != null && pidCard != 'undefined' && pidCard != '' ? pidCard : jidCard);
//    }

//    var Obj = {
//        UID: uid,
//        EventCode: eventCode,
//        IDCard: idCard,
//        CreatedBy: 'system'
//    };
//    console.log("Generate UIDMapFAEvent Object");
//    return Obj;
//}


//function RegisterUIDMapDebtEvent() {
//    var obj = GenerateUIDMapDebtEventObject();
//    var result = InsertUIDMapFAEvent(obj);

//    console.log(result);
//    if (result == '"OK"') {
//        swal("เสร็จสิ้น", "ระบบบันทึกผลการลงทะเบียนของท่านเรียบร้อยแล้ว", "success").then(() => { redirectToMain(); });
//    } else {
//        swal("เกิดข้อผิดพลาด", "ระบบไม่สามารถบันทึกผลการลงทะเบียนได้", "warning");
//    }
//}


//let moreMenus = document.getElementsByClassName("moremenu");
//for (let i = 0; i < moreMenus.length; i++) {
//    document.getElementsByClassName("moremenu")[i].addEventListener("click", function () {
//        console.log(this.dataset.id);
//        document.getElementById('payment').setAttribute('onclick', `redirectToMyBill('${this.dataset.id}')`);
//    });
//}

//let moreMenus = document.getElementsByClassName("moremenu");
//for (let i = 0; i < moreMenus.length; i++) {
//    moreMenus[i].addEventListener("click", function () {
//        console.log(this.dataset.id);

//        const paymentElement = document.getElementById('payment');
//        if (paymentElement) {
//            paymentElement.setAttribute('onclick', `redirectToMyBill('${this.dataset.id}')`);
//        } else {
//            console.error("Element with id 'payment' not found!");
//        }
//    });
//}

document.addEventListener("DOMContentLoaded", function () {
    let moreMenus = document.getElementsByClassName("moremenu");
    for (let i = 0; i < moreMenus.length; i++) {
        moreMenus[i].addEventListener("click", function () {
            console.log(this.dataset.id);

            const paymentElement = document.getElementById('payment');
            if (paymentElement) {
                paymentElement.setAttribute('onclick', `redirectToMyBill('${this.dataset.id}')`);
            } else {
                console.error("Element with id 'payment' not found!");
            }
        });
    }
});

document.querySelector(".carousel-control-next").addEventListener("click", function () {
    console.log("Next button clicked");
    var myCarousel = new bootstrap.Carousel(document.querySelector('[data-bs-target="#carouselCardLGNew"]'));
    console.log(myCarousel);

});

document.querySelector(".carousel-control-prev").addEventListener("click", function () {
    console.log("Prev button clicked");
    var myCarousel = new bootstrap.Carousel(document.querySelector('[data-bs-target="#carouselCardLGNew"]'));
    console.log(myCarousel);
});

