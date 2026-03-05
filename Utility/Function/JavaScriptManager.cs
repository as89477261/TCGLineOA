public class JavaScriptManager
{
    public static string GenerateDialog(string title, string message)
    {
        var BasicPopup = "swal({" +
                         " title: \"" + title + "\", " +
                         " text: \" " + message + " \"," +
                         " html: true });"; //$('.modal-backdrop').hide();$('body').removeClass('modal-open'); ";

        return BasicPopup;
    }

    public static string GenerateDialogWithStatus(string title, string message, string success)
    {
        var BasicPopup = "swal({" +
                         " title: \"" + title + "\", " +
                         " text: \" " + message + " \"," +
                         " html: true," +
                         "  type: '" + success +
                         "' });$('.modal-backdrop').hide();$('body').removeClass('modal-open'); ";

        return BasicPopup;
    }

    public static string GenerateSuccessDialog(string title, string message)
    {
        var BasicPopup = "swal({" +
                         " title: \"" + title + "\", " +
                         " text: \" " + message + " \"," +
                         " html: true ,type: 'success'}).then(() => { var modal = $('.modal-backdrop');  " +
                         " if(typeof modal != 'undefined') " +
                         " { modal.css('display','none'); }});"; //$('.modal-backdrop').hide();$('body').removeClass('modal-open'); ";

        return BasicPopup;
    }

    public static string GenerateSuccessDialogNotDownBackdrop(string title, string message)
    {
        var BasicPopup = "swal({" +
                         " title: \"" + title + "\", " +
                         " text: \" " + message + " \"," +
                         " html: true ,type: 'success'});"; //$('.modal-backdrop').hide();$('body').removeClass('modal-open'); ";

        return BasicPopup;
    }

    public static string GenerateSuccessDialog(string title, string message, string nextPage)
    {
        var BasicPopup = "swal({" +
                         " title: \"" + title + "\", " +
                         " text: \" " + message + " \"," +
                         " html: true ,type: 'success'}).then(() => { window.location.href = '" + nextPage +
                         "';});"; //$('.modal-backdrop').hide();$('body').removeClass('modal-open'); ";

        return BasicPopup;
    }

    public static string GenerateShowModal(string controlID)
    {
        var script = "$('#" + controlID + "').modal('show');";
        return script;
    }

    public static string GenerateHideModal(string controlID)
    {
        var script = "$('#" + controlID +
                     "').modal('hide');$('body').removeClass('modal-open');$('.modal-backdrop').fadeOut(400); ";
        // var script = " $('#" + controlID + "').modal('hide');";

        return script;
    }

    public static string GenerateAlert(string message)
    {
        var BasicPopup = "alert('" + message + "')";

        return BasicPopup;
    }

    public static string GenerateGoogleMap(string width, string height, string src)
    {
        var bufferGoogleMap = "<iframe width=\"" + width + "\" height=\"" + height +
                              "\" frameborder=\"0\" scrolling=\"no\" marginheight=\"0\" " +
                              " marginwidth=\"0\" src = \"" + src + "\"></iframe>";
        return bufferGoogleMap;
    }
}