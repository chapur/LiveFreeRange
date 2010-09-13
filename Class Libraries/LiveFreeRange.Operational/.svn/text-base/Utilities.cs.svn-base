using System;
using System.Text;
using System.IO;
using System.Web;

namespace LiveFreeRange.Operational
{
    public class Utilities
    {
        public static string FormatText(string text, bool allow)
        {
            string formatted = "";

            StringBuilder sb = new StringBuilder(text);
            sb.Replace(" ", "&nbsp;");
            if (!allow)
            {
                sb.Replace("<br />", Environment.NewLine);
                sb.Replace("&nbsp;", " ");
                formatted = sb.ToString();
            }
            else
            {
                StringReader sr = new StringReader(sb.ToString());
                StringWriter sw = new StringWriter();
                while (sr.Peek() > -1)
                {
                    string temp = sr.ReadLine();
                    sw.Write(temp + "<br />");
                }

                formatted = sw.GetStringBuilder().ToString();
            }
            return formatted;
        }

        public static void LogException(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("~/Exception/LogFile.txt"), true))
            {
                sw.WriteLine(DateTime.Now.ToShortDateString() + Environment.NewLine + ex.InnerException.ToString() + Environment.NewLine + Environment.NewLine);
            }
        }

        public static string GetCartGUID()
        {
            if (HttpContext.Current.Request.Cookies["LiveFreeRange"] != null)
            {
                return HttpContext.Current.Request.Cookies["LiveFreeRange"]["CartId"].ToString();
            }
            else
            {
                Guid CartGUID = Guid.NewGuid();
                HttpCookie cookie = new HttpCookie("LiveFreeRange");
                cookie.Values.Add("CartId", CartGUID.ToString());
                cookie.Expires = DateTime.Now.AddDays(30);
                HttpContext.Current.Response.AppendCookie(cookie);

                return CartGUID.ToString();
            }
        }

        public static void DeleteCartGUID()
        {
            if (HttpContext.Current.Request.Cookies["LiveFreeRange"] != null)
            {
                HttpCookie cookie = new HttpCookie("LiveFreeRange");
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static int GetSize(string size)
        {
            int result;

            switch (size)
            {
                case SizeConstantsShort.Small:
                    result = 1;
                    break;
                case SizeConstantsShort.Medium:
                    result = 2;
                    break;
                case SizeConstantsShort.Large:
                    result = 3;
                    break;
                case SizeConstantsShort.ExtraLarge:
                    result = 4;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

    }
}
