var cameraStream = null
//const canvas = document.querySelector('#canvas')
const stream = document.querySelector('#stream')
//const camera = document.querySelector('#camera')
const fileInput = document.querySelector('#file')
//const snapshot = document.querySelector('#snapshot')
//const previewImage = document.querySelector('#snapshot img')

//Buffer 
const hddSelectPicNumber = document.querySelector('#hddSelectPicNumber')

// button
const btnStream1 = document.querySelector('#btnStream1')
const btnStream2 = document.querySelector('#btnStream2')
const btnStream3 = document.querySelector('#btnStream3')
const btnCapture = document.querySelector('#camera div')

function btnStream1Onclick(picNumber) {
    hddSelectPicNumber.value = picNumber;
    SwitchCameraView(picNumber, true);
    startStreaming()

}

function btnCaptureOnclick() {
    var picNumber = hddSelectPicNumber.value;

    captureSnapshot(picNumber)
    SwitchCameraView(picNumber, false)
    stopStreaming()
}



const startStreaming = () => {
    const mediaSupport = 'mediaDevices' in navigator
    if (mediaSupport && null == cameraStream) {
        navigator.mediaDevices.getUserMedia({ video: { facingMode: 'environment' } }).then(function (mediaStream) {
            cameraStream = mediaStream
            stream.srcObject = mediaStream
            stream.play()
        }).catch(function (err) {
            console.log("Unable to access camera: " + err)
        })
    } else {
        alert('Your browser does not support media devices.')
        return
    }
}

const captureSnapshot = (picNumber) => {
    var canvasName = "#canvas" + picNumber;
    var hddBuffer = "#hddImage" + picNumber;
    var previewImageName = "#snapshot" + picNumber + " img";

    const canvas = document.querySelector(canvasName)
    const hddValue = document.querySelector(hddBuffer)
    const previewImage = document.querySelector(previewImageName)

    if (null != cameraStream) {
        var ctx = canvas.getContext('2d')
        ctx.drawImage(stream, 0, 0, canvas.width, canvas.height)
        var bufferSrc = canvas.toDataURL("image/png")


        console.log(bufferSrc);
        previewImage.src = bufferSrc
        hddValue.value = bufferSrc.toString();
    }
}

const stopStreaming = () => {
    if (null != cameraStream) {
        const track = cameraStream.getTracks()[0]
        track.stop()
        stream.load()
        cameraStream = null
    }
}

fileInput.onchange = (event) => {
    const file = event.target.files[0]
    const validImageTypes = ['image/gif', 'image/jpeg', 'image/png']
    if (file) {
        if (validImageTypes.includes(file.type)) {
            previewImage.style.objectFit = "contain"
            if (liff.isInClient()) {
                previewImage.style.objectFit = "cover"
            }
            camera.style.display = "none"
            snapshot.style.display = "block"
            getBase64(file)
            stopStreaming()
        }
    }
}

const getBase64 = (file) => {
    var reader = new FileReader()
    reader.readAsDataURL(file)
    reader.onload = function () {
        previewImage.src = reader.result
    }
    reader.onerror = function (error) {
        console.log("Error: ", error)
    }
}
function SwitchCameraView(picNumber, isCameraOn) {
    var camera = document.querySelector('#camera')
    var snapshot = document.querySelector('#snapshot' + picNumber)

    if (isCameraOn === true) {
        camera.style.display = "block"
        snapshot.style.display = "none"
    } else {
        camera.style.display = "none"
        snapshot.style.display = "block"
    }


}



function ValidateStep1() {
    var result = true;
    var msgText = "";
    var hddImage1 = document.querySelector('#hddImage1')
    var hddImage2 = document.querySelector('#hddImage2')
    var hddImage3 = document.querySelector('#hddImage3')
    var lblValidateComment = document.querySelector('#lblValidateComment')
    
    //alert(hddImage1.value);

    if (hddImage1.value === "") { 
        msgText += "** กรุณาอัพโหลดรูปภาพหน้าบัตรประจำตัวประชาชน <br />";
        result = false;}

    if (hddImage2.value === "") { 
        msgText += "** กรุณาอัพโหลดรูปภาพหลังบัตรประจำตัวประชาชน <br />";
        result = false;}

    if (hddImage3.value === "") { 
        msgText += "** กรุณาอัพโหลดรูปภาพตนเองคู่กับหน้าบัตรประจำตัวประชาชน <br />";
        result = false;
    }

    lblValidateComment.innerHTML = msgText;
    console.log("msg : " + msgText);
    console.log("Validate image is : " + result);
    return result;
}