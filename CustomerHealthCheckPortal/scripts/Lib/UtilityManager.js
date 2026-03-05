function getQueryString() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}
function getDate() {
    let d = new Date();
    let date = d.getFullYear().toString() + "-" + ((d.getMonth() + 1).toString().length == 2 ? (d.getMonth() + 1).toString() : "0" + (d.getMonth() + 1).toString()) + "-" + (d.getDate().toString().length == 2 ? d.getDate().toString() : "0" + d.getDate().toString())
    return date;
}
function getDateTime() {
    let d = new Date();
    let date = d.getFullYear().toString() + "-" + ((d.getMonth() + 1).toString().length == 2 ? (d.getMonth() + 1).toString() : "0" + (d.getMonth() + 1).toString()) + "-" + (d.getDate().toString().length == 2 ? d.getDate().toString() : "0" + d.getDate().toString())
    let time = d.toLocaleString('en-US', { timeZone: 'Europe/Istanbul' }).split(',')[1];
    filterData = date + time
    return filterData;
}
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

function isNumber(evt) {

    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

function numberMobile(e) {
    var value = e.target.value.replace(/[^\d]/g, '');
    var length = value.length;

    value = addCommas(value);

    e.target.value = value

    return false;
}

function addCommas(nStr) {
    nStr += '';
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}

function ValidateEmail(email) {
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
}

function ToGlobalDate(date) {
    var bufferDate = date.split('/');
    if (bufferDate.length == 3) {
        var result = (parseInt(bufferDate[2]) - 543).toString() + "-" + bufferDate[1] + "-" + bufferDate[0];
        return result;
    }
    return date;
}
function ToNDIDConnextDate(date) {
    var bufferDate = date.split('/');
    if (bufferDate.length == 3) {
        var result = (parseInt(bufferDate[2])).toString() + "" + bufferDate[1] + "" + bufferDate[0];
        return result;
    }
    return date;
}

// disable key in
function filterDigits(eventInstance) {
    var eventInstance = eventInstance || window.event;
    var key = eventInstance.keyCode || eventInstance.which;
    if ((47 < key) && (key < 58) || key == 45 || key == 8) {
        return true;
    } else {
        if (eventInstance.preventDefault)
            eventInstance.preventDefault();
        eventInstance.returnValue = false;
        return false;
    } //if
} //filterDigits
function LoaderActive() {
    loader.classList.remove("loader--hidden");
    loader.classList.add("loader--show");
    return false;
}
function LoaderInActive() {
    loader.classList.remove("loader--show");
    loader.classList.add("loader--hidden");
    return false;
}
function randomString(len, charSet) {
    charSet = charSet || 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var randomString = '';
    for (var i = 0; i < len; i++) {
        var randomPoz = Math.floor(Math.random() * charSet.length);
        randomString += charSet.substring(randomPoz, randomPoz + 1);
    }
    return randomString;
}
function GenerateUUID() { // Public Domain/MIT
    var d = new Date().getTime();//Timestamp
    var d2 = ((typeof performance !== 'undefined') && performance.now && (performance.now() * 1000)) || 0;//Time in microseconds since page-load or 0 if unsupported
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16;//random number between 0 and 16
        if (d > 0) {//Use timestamp until depleted
            r = (d + r) % 16 | 0;
            d = Math.floor(d / 16);
        } else {//Use microseconds since page-load if supported
            r = (d2 + r) % 16 | 0;
            d2 = Math.floor(d2 / 16);
        }
        return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
    });
}

// Log
function LocalLog(message) {
    if (isDebugMode == "1") {
        console.log(message);
    }
}
function LocalLogHttp(message) {
    if (isDebugMode == "1") {
        if (isHttpManagerDubugMode == '1') {
            console.log(message);
        }
    }
}



// Login Line
function CheckLoginMainLine() {
    liff.init({ liffId: liffKey, withLoginOnExternalBrowser: true })
        .then(() => {
            if (liff.isLoggedIn()) {

            } else {
                liff.login({ redirectUri: fullHost + "/views/RequestInfo/index" })
            }
        })
        .catch((err) => {
            console.log(err.code, err.message);
        });
}

function CheckLoginMainLineWithRedirect(redirectPage) {
    liff.init({ liffId: liffKey, withLoginOnExternalBrowser: true })
        .then(() => {
            if (liff.isLoggedIn()) {

            } else {
                liff.login({ redirectUri: redirectPage })
            }
        })
        .catch((err) => {
            console.log(err.code, err.message);
        });
}

