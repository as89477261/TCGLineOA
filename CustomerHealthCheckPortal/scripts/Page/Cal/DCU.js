let resultCal = [];

document.addEventListener('DOMContentLoaded', () => {

    const _uid = getCookie('uid');

    if (_uid) {
        KeepLogActivity("DCU_CalDebt", _uid, "OPEN_PAGE_CAL_DCU");
    }

});
document.getElementById("btnRegister").addEventListener("click", function () {

    const _uid = getCookie('uid');

    const ResultCal = resultCal
    const textResultCal = JSON.stringify(ResultCal);
    console.log(textResultCal);

    if (_uid) {
        KeepLogActivity("DCU_CalDebt", _uid, 'DIRECT_PAGE_TO_Debt' + 'ResultCal :' + textResultCal);
    }

});

function validate() {
    var result = true;
    var aessetAmount = document.getElementById('b1');
    var debtAmount = document.getElementById('b2');

    if (aessetAmount.value == "") {
        aessetAmount.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        aessetAmount.style.border = "";
    }

    if (debtAmount.value == "") {
        debtAmount.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        debtAmount.style.border = "";
    }
    return result;
}
function calculateDCU() {

    const isValid = validate();
    console.log('Valid is:', isValid);

    if (isValid === true) {

        var pnlInfo = document.getElementById('pnlInfo');
        var pnlResult_DCU = document.getElementById('pnlResult_DCU');

        var param1 = document.getElementById('b1').value;
        var param2 = document.getElementById('b2').value;
        //var param3 = document.getElementById('').value;

        let lblParam1 = document.getElementById('lblParam1');
        let lblParam2 = document.getElementById('lblParam2');

        // Calculate
        var result = (param1 * 100) * 6 / param2

        result.toFixed(2);

        resultCal = {
            canPayDebtPerMonth: param1,
            debtAmountTotal: param2,
            resultCalDCU: result
        }

        //alert(result);

        //การแสดงผลจากเงื่อนไข 
        let cardResultTittle = document.getElementById('cardResultTittle');
        let cardResultDetail = document.getElementById('cardResultDetail');

        if (result < 1) {
            cardResultTittle.innerHTML = 'มาตรการที่ 1'
            cardResultTittle.classList.add("color-violet-dark")
            cardResultDetail.innerHTML = 'คุณเป็นลูกหนี้ที่ดีได้ <br/> หากมีวินัยในการชำระเงินเราช่วยคุณได้ <br/>  เหมาะสำหรับแพ็คแก็จ <br/> <strong> ลูกหนี้ดี ไม่มีแรงผ่อน <strong/> '
            changeIconAndColor('bi-check-circle-fill', 'color-violet-dark');

            const accItem = document.getElementById('accitem1');
            const accCollapse = document.getElementById('accordion1-2');
            const accButton = accItem.querySelector('button.accordion-button');

            accCollapse.classList.add('show'); // แสดงเนื้อหา
            accButton.classList.remove('collapsed'); // ลบคลาส collapsed ออกจากปุ่ม
            accButton.setAttribute('aria-expanded', 'true'); // ตั้งค่าให้เปิดอยู่

            setCookie("debtPID", '1', 36500);

        }
        if (result >= 1 && result < 10) {
            cardResultTittle.innerHTML = 'มาตรการที่ 2'
            cardResultTittle.classList.add("color-yellow-dark")
            cardResultDetail.innerHTML = 'คุณต้องการคำปรึกษา <br/> เหมาะสำหรับแพ็คเกจ <br/> <strong>  ลูกหนี้ดี มีบสย.ช่วยเหลือ<strong/> '
            changeIconAndColor('bi-check-circle-fill', 'color-yellow-dark');

            const accItem = document.getElementById('accitem2');
            const accCollapse = document.getElementById('accordionggg1-2');
            const accButton = accItem.querySelector('button.accordion-button');

            accCollapse.classList.add('show'); // แสดงเนื้อหา
            accButton.classList.remove('collapsed'); // ลบคลาส collapsed ออกจากปุ่ม
            accButton.setAttribute('aria-expanded', 'true'); // ตั้งค่าให้เปิดอยู่


            setCookie("debtPID", '2', 36500);

        }
        if (result >= 10) {
            cardResultTittle.innerHTML = 'มาตรการที่ 3'
            cardResultTittle.classList.add("color-green-dark")
            cardResultDetail.innerHTML = 'คุณคือผู้มีวินัยและความรับผิดชอบ  <br/> สามารถดูแลธุรกิจได้เป็นอย่างดี  <br/> เหมาะสำหรับ แพ็คเกจ  <br/>  <strong> ลูกหนี้ดี มีวินัย <strong/> '
            changeIconAndColor('bi-check-circle-fill', 'color-green-dark');

            const accItem = document.getElementById('accitem3');
            const accCollapse = document.getElementById('accordionggg1-3');
            const accButton = accItem.querySelector('button.accordion-button');

            accCollapse.classList.add('show'); // แสดงเนื้อหา
            accButton.classList.remove('collapsed'); // ลบคลาส collapsed ออกจากปุ่ม
            accButton.setAttribute('aria-expanded', 'true'); // ตั้งค่าให้เปิดอยู่

            setCookie("debtPID", '3', 36500);
        }

        pnlResult_DCU.style.display = "block";
        pnlInfo.style.display = "none";

    } else {
        swal('ข้อมูลไม่ถูกต้อง', 'กรอกข้อมูลให้ครบถ้วน', 'warning')
    }
}

function Reset() {
    const _uid = getCookie('uid');

    let cardResultTittle = document.getElementById('cardResultTittle');
    let cardResultDetail = document.getElementById('cardResultDetail');
    let param1 = document.getElementById('b1');
    let param2 = document.getElementById('b2');

    resetCalDCU();

    cardResultTittle.innerHTML = ''
    cardResultTittle.classList.remove("color-violet-dark", "color-yellow-dark", "color-green-dark");
    cardResultDetail.innerHTML = ''
    param1.value = ''
    param2.value = ''

    if (_uid) {
        KeepLogActivity("DCU_CalDebt", _uid, "RESET_CAL_DCU");
    }

    pnlResult_DCU.style.display = "none";
    pnlInfo.style.display = "block";

}

function changeIconAndColor(newIconClass, newColorClass) {
    const iconElement = document.querySelector(".bi-check-circle-fill");

    // ลบสีเดิมออก
    iconElement.classList.remove("color-green-dark", "color-yellow-dark", "color-violet-dark");

    // เปลี่ยน Icon ถ้ามีการระบุใหม่
    if (newIconClass) {
        iconElement.classList.remove(...Array.from(iconElement.classList).filter(cls => cls.startsWith("bi-")));
        iconElement.classList.add(newIconClass);
    }

    // เพิ่มสีใหม่ที่ต้องการ
    if (newColorClass) {
        iconElement.classList.add(newColorClass);
    }
}

function resetCalDCU() {

    const accordionIDs = ['accordion1-2', 'accordionggg1-2', 'accordionggg1-3'];

    accordionIDs.forEach(id => {
        const accCollapse = document.getElementById(id);
        const accButton = document.querySelector(`button[data-bs-target="#${id}"]`);


        if (accCollapse && accButton) {
            // ซ่อนเนื้อหา
            accCollapse.classList.remove('show');

            // ปรับสถานะของปุ่มให้เป็น collapsed
            accButton.classList.add('collapsed');
            accButton.setAttribute('aria-expanded', 'false');
        }
    });


}


async function checkEndLevel(data) {
    const resultObj = data.RESULT_OBJ;
    let hasTrue = false;
    let hasFalse = false;

    for (const item of resultObj) {
        if (item.EndLevel === true) hasTrue = true;
        if (item.EndLevel === false) hasFalse = true;
    }

    if (hasTrue && hasFalse) return 2; // มีรายการที่ยังไม่ปิด บางรายการ
    if (hasFalse) return 0; //มีรายการที่ยังไม่ปิดทั้งหมด
    if (hasTrue) return 1; //ปิดรายการแล้วทั้งหมด 

    return -1; // กรณีไม่มีข้อมูลใน RESULT_OBJ
}


async function handleCheckEndLevelResult(resultcheckEndLevel) {

    switch (resultcheckEndLevel) {
        case 1:
            redirectToDebtStep2();
            break;
        case 0:
            redirectToDebtStep1();
            break;
        case 2:
            redirectToDebtStep1();
            break;
        case -1:
            redirectToDebtStep2();
            break;
        default:
            redirectToMain();
            break;
    }
}
async function KeepDataAndGoDebtRegisterPage() {

    try {
        const _uid = getCookie('uid');
        if (_uid) {

            const buffer = await GetUidTransFA(_uid);
            console.log(buffer);

            if (buffer) {

                const resultBuffer = JSON.parse(buffer);
                console.log(resultBuffer);

                const resultcheckEndLevel = await checkEndLevel(resultBuffer);  // ตรวจสอบรายการ ในการปิดงาน

                console.log("ผลลัพธ์ที่ได้:", resultcheckEndLevel);

                await handleCheckEndLevelResult(resultcheckEndLevel);

            }

        } else {

            redirectToLanding();

        }
    }
    catch (error) {
        console.error('เกิดข้อผิดพลาด:', error.message);
    }

}


