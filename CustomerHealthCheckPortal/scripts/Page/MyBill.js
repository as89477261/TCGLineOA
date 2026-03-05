document.addEventListener("DOMContentLoaded", () => {

    // update 02092567 : by nut 
    document.querySelectorAll('.accordion-button span strong').forEach(function (element) {
        //console.log('element', element);
        let currentText = element.innerText;
        //console.log('currentText LG NO :', currentText);
        if (currentText.includes('LG No')) {

            let lastFourDigits = currentText.slice(-4);
            //console.log('lastFourDigits', lastFourDigits);

            let modifiedText = 'xxxx' + lastFourDigits;
            //console.log('modifiedText', modifiedText);

            element.innerText = currentText.replace(/LG No\s+\d{8}/, `LG No ${modifiedText}`);
            //console.log('element : ', element);

        }
    });

    document.querySelectorAll('.offcanvas a').forEach(function (element) {

        //console.log('element', element);

        let currentText = element.innerText;
        //console.log(currentText);

        if (currentText.includes('ค่าธรรมเนียมดำเนินการค้ำประกัน LG :')) {

            let cleanCurrentText = currentText.replace(/\s+:\s+/, ': ').trim();
            console.log(cleanCurrentText);

            let modifiedText = cleanCurrentText.replace(/(\d{4})\d{4}/, '$1xxxx');

            //console.log(modifiedText);

            element.innerText = modifiedText


        }

    }); 


    if (isDebugMode == "0") {
        CheckLoginMainLineWithRedirect("https://chatclinic.tcg.or.th/tcghealthcheck_dev/views/bill/index");
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