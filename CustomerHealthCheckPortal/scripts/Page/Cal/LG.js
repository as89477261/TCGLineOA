let resultCal = [];

document.addEventListener('DOMContentLoaded', () => {
    const _uid = getCookie('uid');

    if (_uid) {
        KeepLogActivity("DCU_CalLoanPayment", _uid, "OPEN_PAGE_CAL_LG");
    }
    AddonUI();
});

document.getElementById("btnRegister").addEventListener("click", function () {
    const _uid = getCookie('uid');

    const ResultCal = resultCal;
    let textResultCal = JSON.stringify(ResultCal);
    console.log(textResultCal);

    if (_uid) {
        KeepLogActivity("DCU_CalLoanPayment", _uid, "DIRECT_PAGE_TO_PGS" + textResultCal);
    }
});

function validate() {
    var result = true;
    var loanAmount = document.getElementById('a1'); // จำนวนเงินที่ขอสินเชื่อ 
    var interestAmount = document.getElementById('a2'); // ดอกเบี้ย
    var loanYear = document.getElementById('a3'); // ระยะเวลาการชำระ
    var rateInterestTCG = document.getElementById('a4'); // อัตราค่าธรรมเนียม บสย. 

    if (loanAmount.value == "") {
        loanAmount.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        loanAmount.style.border = "";
    }

    if (interestAmount.value == "") {

        interestAmount.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        interestAmount.style.border = "";
    }

    if (loanYear.value == "") {
        loanYear.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        loanYear.style.border = "";
    }

    if (rateInterestTCG.value == "") {
        rateInterestTCG.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        rateInterestTCG.style.border = "";
    }

    return result;
}
function calculateLoadTotal(principal, bankInterestRate, loanTermYears, tcgInterestRate) {
    const loanTermMonths = loanTermYears * 12; // จำนวนงวดที่ผ่อนชำระทั้งหมด

    principal = parseFloat(principal); // จำนวนเงินที่ขอสินเชื่อ
    bankInterestRate = parseFloat(bankInterestRate); // ดอกเบี้ย
    loanTermYears = parseFloat(loanTermYears); // ระยะเวลาการชำระ (ปี)
    tcgInterestRate = parseFloat(tcgInterestRate); // อัตราค่าธรรมเนียม (ร้อยละ/ปี)

    // principal จำนวนเงินที่ขอสินเชื่อ
    // bankInterestRate ดอกเบี้ย
    // loanTermYears ระยะเวลาการชำระ (ปี)
    // tcgInterestRate อัตราค่าธรรมเนียม (ร้อยละ/ปี)

    // คำนวณดอกเบี้ยทั้งหมด
    const totalBankInterest = ((principal * (bankInterestRate / 100)) * loanTermYears);
    console.log('totalBankInterest', totalBankInterest);
    const totalTcgInterest = ((principal * (tcgInterestRate / 100)) * loanTermYears);
    console.log('totalTcgInterest', totalTcgInterest);

    // คำนวณดอกเบี้ยต่อเดือน
    const bankInterestPerMonth = totalBankInterest / loanTermMonths;
    const bankInterestPerYear = totalBankInterest / loanTermYears;
    console.log('bankInterestPerMonth', bankInterestPerMonth);
    const tcgInterestPerMonth = totalTcgInterest / loanTermMonths;
    const tcgInterestPerYear = totalTcgInterest / loanTermYears;
    console.log('tcgInterestPerMonth', tcgInterestPerMonth);

    // คำนวณเงินต้นที่ต้องจ่ายต่อเดือน
    const principalPerMonth = principal / loanTermMonths;
    const principalPerYear = principal / loanTermYears;
    console.log('principalPerMonth', principalPerMonth);

    const principalAndInterestPerMonth = principalPerMonth + bankInterestPerMonth;
    const principalAndInterestPerYear = principalPerYear + bankInterestPerYear;
    // คำนวณเงินที่ต้องชำระต่อเดือน
    const bankMonthlyPayment = bankInterestPerMonth;
    console.log('bankMonthlyPayment', bankMonthlyPayment);
    const tcgMonthlyPayment = tcgInterestPerMonth;
    console.log('tcgMonthlyPayment', tcgMonthlyPayment);
    // คำนวณชำระต่อเดือนแบบพิเศษ
    const specialMonthlyPayment = (principal / loanTermMonths) + bankMonthlyPayment + tcgMonthlyPayment
    const specialYearPayment = principalPerYear + bankInterestPerYear + tcgInterestPerYear
    console.log('specialMonthlyPayment', specialMonthlyPayment)

    return {
        totalBankInterest: totalBankInterest.toFixed(2),
        totalTcgInterest: totalTcgInterest.toFixed(2),
        bankInterestRate: bankInterestRate,
        loanTermYears: loanTermYears,
        tcgInterestRate: tcgInterestRate,
        tcgInterestPerYear: tcgInterestPerYear.toFixed(2),
        principal: principal,
        principalPerMonth: principalPerMonth,
        principalPerYear: principalPerYear,
        principalAndInterestPerMonth: principalAndInterestPerMonth,
        principalAndInterestPerYear: principalAndInterestPerYear,
        //ZoneCal
        bankMonthlyPayment: bankMonthlyPayment.toFixed(2),
        tcgMonthlyPayment: tcgMonthlyPayment.toFixed(2),
        bankAndTcgMonthlyPayment: specialMonthlyPayment.toFixed(2),
        bankAndTcgYearPayment: specialYearPayment.toFixed(2)
    };
}
function calculateLG() {

    const isValid = validate();
    console.log('Valid is:', isValid);

    if (isValid === true) {

        let pnlInfo = document.getElementById('pnlInfo');
        let pnlResult_LG = document.getElementById('pnlResult_LG');

        let _principal = document.getElementById('hddParam1').value.replaceAll (",", "");
        let _bankInterestRate = document.getElementById('a2').value.replaceAll(",", "");
        let _loanTermYears = document.getElementById('a3').value.replaceAll(",", "");
        let _tcgInterestRate = document.getElementById('a4').value.replaceAll(",", "");

        let lblParam1 = document.getElementById('lblParam1');
        let lblParam2 = document.getElementById('lblParam2');
        let lblParam3 = document.getElementById('lblParam3');
        let lblParam4 = document.getElementById('lblParam4');
        let lblBankPayPerMonth = document.getElementById('lblBankPayPerMonth');
        let lblBankPayPerYear = document.getElementById('lblBankPayPerYear');
        let lblTcgPayPerMonth = document.getElementById('lblTcgPayPerMonth');
        let lblTotalPayPerMonth = document.getElementById('lblTotalPayPerMonth');
        //// Calculate

        let result = calculateLoadTotal(_principal, _bankInterestRate, _loanTermYears, _tcgInterestRate)  // Sample Cal

        //console.log(result);

        resultCal = result;
        console.log('resultCal', resultCal)

        if (result) {
            pnlInfo.style.display = "none";
            pnlResult_LG.style.display = "block";

            lblParam1.innerHTML = accounting.formatNumber(result.principal, 0, ',', '.')
            lblParam2.innerHTML = result.bankInterestRate + '%'
            lblParam3.innerHTML = result.loanTermYears + ' ปี'
            lblParam4.innerHTML = result.tcgInterestRate + '%'
            lblBankPayPerMonth.innerHTML = accounting.formatNumber(result.principalAndInterestPerMonth, 2, ',', '.')
            lblBankPayPerYear.innerHTML = accounting.formatNumber(result.principalAndInterestPerYear, 2, ',', '.')
            lblTcgPayPerMonth.innerHTML = accounting.formatNumber(result.tcgInterestPerYear, 2, ',', '.')
            lblTotalPayPerMonth.innerHTML = accounting.formatNumber(result.bankAndTcgYearPayment, 2, ',', '.')
        };


        //lblParam2.innerHTML = param2;
        //lblParam3.innerHTML = param3;
        //lblTCGPayPerYear.innerHTML = ((param1 * param2) / 100);
        //lblSummaryAmountPerYear.innerHTML = ((param1 * param2) / 100) * param3;

        //pnlResult_LG.style.display = "block";
        //pnlInfo.style.display = "none";

    }
    else {
        swal('ข้อมูลไม่ถูกต้อง', 'กรอกข้อมูลให้ครบถ้วน', 'warning')
    }
}

function Reset() {
    const _uid = getCookie('uid');
    var pnlInfo = document.getElementById('pnlInfo');
    var pnlResult_LG = document.getElementById('pnlResult_LG');

    var param1 = document.getElementById('a1');
    var param2 = document.getElementById('a2');
    var param3 = document.getElementById('a3');
    var param4 = document.getElementById('a4');

    param1.value = "";
    param2.value = "";
    param3.value = "";
    param4.value = "";

    if (_uid) {
        KeepLogActivity("DCU_CalLoanPayment", _uid, "RESET_CAL_LG");
    }

    pnlResult_LG.style.display = "none";
    pnlInfo.style.display = "block";
}


function AddonUI() {

    $("input[id$='a1']").change(function () {
        document.getElementById('hddParam1').value = $("input[id$='a1']").val()
        $("input[id$='a1']").val(accounting.formatNumber($("input[id$='a1']").val(), 0, ',', '.'));

    });

    //$("input[id$='a2']").change(function () {
    //    $("input[id$='a2']").val(accounting.formatNumber($("input[id$='a2']").val(), 0, ',', '.'));
    //});

    $("input[id$='a3']").change(function () {
        $("input[id$='a3']").val(accounting.formatNumber($("input[id$='a3']").val(), 0, ',', '.'));
    });

}





