using QRCoder;

public class QCCode
{
    public byte[] GenerateMyQCCode(string QCText)
    {
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(QCText, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new BitmapByteQRCode(qrCodeData);
        var qrCodeAsBitmapByteArr = qrCode.GetGraphic(20);


        return qrCodeAsBitmapByteArr;
    }
}