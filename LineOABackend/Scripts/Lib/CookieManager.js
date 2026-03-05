var obj = {};


function setCookieManual(cname, cvalue, exdays) {

    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
function getCookieManual(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function DecryptedData(dataObj) {
    var key = CryptoJS.enc.Utf8.parse(headerCode + partialCode);
    var iv = CryptoJS.enc.Utf8.parse(headerCode + partialCode);
    //var bufferEncryptedObj = CryptoJS.AES.decrypt(dataObj, key, { mode: CryptoJS.mode.ECB, padding: CryptoJS.pad.Pkcs7 });

    var bufferEncryptedObj = CryptoJS.AES.decrypt(dataObj, key, {
        keySize: 128 / 8,
        iv: iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7
    });
    var decryptedData = bufferEncryptedObj.toString(CryptoJS.enc.Utf8)
    //console.log(decryptedData);

    return decryptedData;
}
function EncryptedData(dataObj) {
    var key = CryptoJS.enc.Utf8.parse(headerCode + partialCode);
    var iv = CryptoJS.enc.Utf8.parse(headerCode + partialCode);

    //var encryptedlogin = CryptoJS.AES.encrypt(dataObj, key, { mode: CryptoJS.mode.ECB, padding: CryptoJS.pad.Pkcs7 });

    var encryptedlogin = CryptoJS.AES.encrypt(dataObj, key,
        {
            keySize: 128 / 8,
            iv: iv,
            mode: CryptoJS.mode.CBC,
            padding: CryptoJS.pad.Pkcs7
        });


    return encryptedlogin;
}

function setCookieDebug(cname, cvalue) {

    console.log("Set Cookie Step1 : Enquiry line OA cookie");
    var dataObj = getCookieManual("lineoa");

    console.log("Set Cookie Step2 : line OA cookie is : " + dataObj);
    if (typeof dataObj != 'undefined' && dataObj != "") {

        var decryptedData = DecryptedData(dataObj)
        console.log("Set Cookie Step3 : Decrypted line OA cookie is : " + decryptedData);

        if (decryptedData != '') {
            obj = JSON.parse(decryptedData);
        }
    }

    obj[cname] = cvalue;
    console.log("Set Cookie Step4 : " + cname + " is => " + cvalue + " added to line OA cookie")

    var bufferObj = JSON.stringify(obj);
    console.log("Set Cookie Step5 : line OA cookie is " + bufferObj);

    var resultObj = EncryptedData(bufferObj);
    console.log("Set Cookie Step6 : line OA cookie Encrypted is " + resultObj);

    var a = encodeURIComponent(resultObj);
    console.log("Set Cookie Step7 : line OA cookie Encrypted is " + a);

    // setCookie1('lineoa1', resultObj.toString(), 365);
    setCookieManual('lineoa', a, 365);
}
function getCookieDebug(cname) {
    var buffObj;

    console.log("Get Cookie Step1 : Enquiry line OA cookie");
    var dataObj = getCookieManual("lineoa");

    console.log("Get Cookie Step2 : line OA cookie is : " + dataObj);
    if (typeof dataObj != 'undefined' && dataObj != "") {

        var bufferDecryptedObj = DecryptedData(dataObj);
        console.log("Get Cookie Step3 : Decrypted line OA cookie is : " + bufferDecryptedObj);

        var decryptedData = bufferDecryptedObj.toString(CryptoJS.enc.Utf8)
        console.log("Get Cookie Step4 : line OA cookie Decrypted is " + decryptedData);

        if (decryptedData != '') {
            buffObj = JSON.parse(decryptedData);
            console.log("Get Cookie Step5 : JSON Decrypted is " + buffObj);
        }
    }

    return buffObj[cname];

}

function setCookie(cname, cvalue) {

    //console.log("Set Cookie Step1 : Enquiry line OA cookie");
    var dataObj = getCookieManual("lineoa");

    //console.log("Set Cookie Step2 : line OA cookie is : " + dataObj);
    if (typeof dataObj != 'undefined' && dataObj != "") {

        var decryptedData = DecryptedData(dataObj)
        //console.log("Set Cookie Step3 : Decrypted line OA cookie is : " + decryptedData);

        if (decryptedData != '') {
            obj = JSON.parse(decryptedData);
        }
    }

    obj[cname] = cvalue;
    //console.log("Set Cookie Step4 : " + cname + " is => " + cvalue + " added to line OA cookie")

    var bufferObj = JSON.stringify(obj);
    //console.log("Set Cookie Step5 : line OA cookie is " + bufferObj);

    var resultObj = EncryptedData(bufferObj);
    //console.log("Set Cookie Step6 : line OA cookie Encrypted is " + resultObj);

    var a = encodeURIComponent(resultObj);
    //console.log("Set Cookie Step7 : line OA cookie Encrypted is " + a);

    // setCookie1('lineoa1', resultObj.toString(), 365);
    setCookieManual('lineoa', a, 365);
}
function getCookie(cname) {
    var buffObj;

    //console.log("Get Cookie Step1 : Enquiry line OA cookie");
    var dataObj = getCookieManual("lineoa");

    //console.log("Get Cookie Step2 : line OA cookie is : " + dataObj);
    if (typeof dataObj != 'undefined' && dataObj != "") {

        var bufferDecryptedObj = DecryptedData(dataObj);
        //console.log("Get Cookie Step3 : Decrypted line OA cookie is : " + bufferDecryptedObj);

        var decryptedData = bufferDecryptedObj.toString(CryptoJS.enc.Utf8)
        //console.log("Get Cookie Step4 : line OA cookie Decrypted is " + decryptedData);

        if (decryptedData != '') {
            buffObj = JSON.parse(decryptedData);
            //console.log("Get Cookie Step5 : JSON Decrypted is " + buffObj);
        }
    }

    return buffObj[cname];

}
