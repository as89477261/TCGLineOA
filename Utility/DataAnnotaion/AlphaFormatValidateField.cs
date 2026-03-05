using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

public class AlphaFormatValidateField : ValidationAttribute
{
    public string errorMessage = "Input contains wrong character";
    public string typeValidate = "";

    public AlphaFormatValidateField()
    {
        typeValidate = "";
    }

    public AlphaFormatValidateField(string type)
    {
        typeValidate = type;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var finalErrorMessage = validationContext.DisplayName + ":" + errorMessage;
        var valueString = value != null ? value.ToString() : null;

        if (string.IsNullOrWhiteSpace(valueString))
            // No value, so return success.
            return ValidationResult.Success;

        var htmlFormat = "<(\"[^\"]*\"|'[^']*'|[^'\">])*>";
        var regHtmlFormat = new Regex(htmlFormat);
        if (regHtmlFormat.Match(value.ToString()).Success) return new ValidationResult(finalErrorMessage);

        var specialFormat = "";
        switch (typeValidate)
        {
            case "id":
                specialFormat = @"\!#$%&()=?»«@£§€{};'<>_,";
                break;
            case "ndidrefid":
                specialFormat = @"\!#$%&()=?»«@£§€{};'<>_,";
                break;
            case "partial":
                specialFormat = @"\!#$%&=?»«£§€{};";
                break;
            case "phone":
                specialFormat = @"\|!#$%&()=?»«@£§€{};'<>_,";
                break;
            case "email":
                specialFormat = @"\|!#$%&()=?»«£§€{};'<>,";
                break;
            case "datetime":
                specialFormat = @"\|!#$%&()=?»«@£§€{};'<>_,";
                break;
            case "decimal":
                specialFormat = @"\|!#$%&()=?»«@£§€{};'<>_";
                break;
            case "laserid":
                specialFormat = @"\|!#$%&()=?»«@£§€{};'<>_";
                break;
            case "htmlpath":
                specialFormat = @"|!#$%&()=»«£§€{}'<>";
                break;
            default:
                specialFormat = @"\|!#$%&()=?»«@£§€{};'<>_,";
                break;
        }

        var isContainSpecialformat = specialFormat.Where(x => valueString.Contains(x)).Any();
        if (isContainSpecialformat) return new ValidationResult(finalErrorMessage);


        // Return success
        return ValidationResult.Success;
    }
}