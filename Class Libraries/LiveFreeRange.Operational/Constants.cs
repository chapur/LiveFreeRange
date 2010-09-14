using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Operational
{
    public static class CategoryConstants
    {
        public const string Clothing = "Clothing";
        public const string Jewellery = "Jewellery";
        public const string Gifts = "Gifts";
    }

    public static class SizeConstants
    {
        public const string ExtraSmall = "extrasmall";
        public const string Small = "small";
        public const string Medium = "medium";
        public const string Large = "large";
        public const string ExtraLarge = "extralarge";
    }

    public static class SizeConstantsShort
    {
        public const string ExtraSmall = "xs";
        public const string Small = "s";
        public const string Medium = "m";
        public const string Large = "l";
        public const string ExtraLarge = "xl";
    }

    public static class SubCategoryConstants
    {
        public const string TShirt = "tshirt";
        public const string Hoody = "hoody";
    }

    public static class EmailAddressConstants
    {
        public const string Jennifer = "jb@livefreerange.co.uk";
        public const string Simon = "simonbegg@hotmail.com";
        public const string Contact = "contact@livefreerange.co.uk";
        public const string Sales = "sales@livefreerange.co.uk";
    }

    public static class CurrencyConstants
    {
        public const string Gbp = "GBP";
        public const string Usd = "USD";
    }

    public class PaypalConstants
    {
        public const string PayPalSandboxApiPassword = "F2CPGRTJCTMKTJTQ";
        public const string PayPalSandboxApiUserName = "simonbegg_api1.hotmail.com";
        public const string PayPalSandboxApiUrl = "https://api-aa.sandbox.paypal.com/2.0/";
        public const string PayPalSandboxApiSignature = "";
    }
}
