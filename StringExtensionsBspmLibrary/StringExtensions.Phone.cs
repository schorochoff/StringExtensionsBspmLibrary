namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {
        ///// <summary>
        ///// Returns true if the value is a valid phone number.
        ///// Source : https://www.softfluent.fr/blog/validation-numeros-telephone-avec-libphonenumber/
        ///// </summary>
        ///// <param name="phoneNumber"></param>
        ///// <param name="defaultRegion"></param>
        ///// <returns></returns>
        //public static PhoneNumber? GetPhoneNumber(this string phoneNumber, string defaultRegion = "BE")
        //{
        //    try
        //    {
        //        //Création de l'intance PhoneNumberUtil
        //        var phoneUtil = PhoneNumberUtil.GetInstance();
        //        PhoneNumber number = null;
        //        //Si le numéro contient l'indicatif + ou le 00
        //        if (phoneNumber.StartsWith("+") || phoneNumber.StartsWith("00"))
        //        {
        //            if (phoneNumber.StartsWith("00"))
        //            {
        //                phoneNumber = "+" + phoneNumber.Remove(0, 2);
        //            }

        //            return phoneUtil.Parse(phoneNumber, "");
        //        }
        //        else
        //        {
        //            return phoneUtil.Parse(phoneNumber, defaultRegion);
        //        }
        //    }
        //    catch (NumberParseException)
        //    {
        //        //LOG
        //        return null;
        //    }
        //}



        ///// <summary>
        ///// Returns true if the value is a valid phone number.
        ///// </summary>
        ///// <param name="phoneNumber"></param>
        ///// <param name="defaultRegion"></param>
        ///// <returns></returns>
        //public static bool IsValidPhoneNumber(this string phoneNumber, string defaultRegion = "BE", PhoneNumberType? phoneNumberType = null)
        //{
        //    var phoneUtil = PhoneNumberUtil.GetInstance();
        //    var number = GetPhoneNumber(phoneNumber);

        //    if (number != null)
        //    {
        //        string regionCode = phoneUtil.GetRegionCodeForNumber(number);
        //        // Validation du numéro qui correspond à la région trouvées
        //        var isPhoneNumber = phoneUtil.IsValidNumberForRegion(number, regionCode);
        //        var isPhoneTypeRespected = phoneNumberType == null || phoneUtil.GetNumberType(number) == phoneNumberType;
        //        return isPhoneNumber && isPhoneTypeRespected;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        /////  Returns the region code of the phonenumber when the number is valid (valid = with prefix or belgian number).
        ///// </summary>
        ///// <param name="phoneNumber"></param>
        ///// <returns></returns>
        //public static string? GetPhoneNumberRegionCode(this string phoneNumber)
        //{
        //    var number = GetPhoneNumber(phoneNumber);
        //    if (number != null)
        //    {
        //        var phoneUtil = PhoneNumberUtil.GetInstance();
        //        string regionCode = phoneUtil.GetRegionCodeForNumber(number);
        //        if (phoneUtil.IsValidNumberForRegion(number, regionCode))
        //            return regionCode.ToUpper();
        //        else
        //            return null;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        /////  Returns the phonenumber without his national code when the number is valid. 
        /////  Return Null when the phoneNumber has no prefix and is not a belgian number.
        ///// </summary>
        ///// <param name="phoneNumber"></param>
        ///// <returns></returns>
        //public static string? GetNationalNumber(this string phoneNumber)
        //{
        //    var number = GetPhoneNumber(phoneNumber);
        //    if (number != null)
        //    {
        //        var phoneUtil = PhoneNumberUtil.GetInstance();
        //        string regionCode = phoneUtil.GetRegionCodeForNumber(number);
        //        if (phoneUtil.IsValidNumberForRegion(number, regionCode))
        //            return phoneUtil.GetNationalSignificantNumber(number);
        //        else
        //            return null;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
