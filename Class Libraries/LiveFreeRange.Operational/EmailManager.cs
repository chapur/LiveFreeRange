using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;

namespace LiveFreeRange.Operational
{
    public class EmailManager
    {
        public EmailManager()
        { 
        
        }
        
        public void Send(EmailContents emailContents)
        {
            SmtpClient client = new SmtpClient(SMTPServerName);
            client.UseDefaultCredentials = true;
            MailAddress from = new MailAddress(emailContents.FromEmailAddress, emailContents.FromName);
            MailAddress to = new MailAddress(ToAddress);
            MailAddress bcc = new MailAddress(emailContents.Bcc);
            MailAddress cc = new MailAddress(emailContents.Cc);
            MailMessage message = new MailMessage(from, to);

            message.Bcc.Add(bcc);
            message.CC.Add(cc);
            message.Subject = emailContents.Subject;
            message.Body = Utilities.FormatText(emailContents.Body, true);
            message.IsBodyHtml = true;

            try
            {
                client.Send(message);
                IsSent = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool _isSent;

        public bool IsSent
        {
            get { return _isSent; }
            set { _isSent = value; }
        }

        private string SMTPServerName
        {
            get { return ConfigurationManager.AppSettings["SMTPServer"]; }
        }

        private string ToAddress
        {
            get { return ConfigurationManager.AppSettings["ToAddress"]; }
        }
    }

    public struct EmailContents
    {
        public string To;
        public string Bcc;
        public string Cc;
        public string FromName;
        public string FromEmailAddress;
        public string Subject;
        public string Body;
    }

    public class NewsletterManager
    {
        private DataSet _userData;

        public DataSet UserData
        {
            get { return _userData; }
            set { _userData = value; }
        }
        private string _messageBody;

        public string MessageBody
        {
            get { return _messageBody; }
            set { _messageBody = value; }
        }

        public NewsletterManager()
        { 
        
        }

        public void SendNewsletter()
        {
            string msgBody = string.Empty;
            string unsubscribe = string.Empty;
            EmailManager mailManager = new EmailManager();
            EmailContents mailContents = new EmailContents();

            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/Admin/EmailTemplates/CustomerNewsletter.htm")))
            {
                string stringBody = sr.ReadToEnd();

                foreach (DataRow dr in UserData.Tables[0].Rows)
                {
                    msgBody = stringBody;

                    unsubscribe = "<a href =\"http://www.livefreerange.co.uk/Admin/Unsubscribe.aspx?EndUserId=" + dr["EndUserId"].ToString() + "?FullName=" + dr["FirstName"].ToString() + " " + dr["LastName"].ToString() + "\"Target=\"_blank\"\">Click here</a>";

                    msgBody = msgBody.Replace("'+Name+", dr["FirstName"].ToString() + " " + dr["LastName"].ToString());
                    msgBody = msgBody.Replace("'+MessageBody+", MessageBody);
                    msgBody = msgBody.Replace("'+Clickhere+", unsubscribe);

                    mailContents.To = dr["Email"].ToString();
                    mailContents.FromName = "Live Free Range";
                    mailContents.FromEmailAddress = "info@livefreerange.co.uk";
                    mailContents.Subject = "Newsletter";
                    mailContents.Body = msgBody;

                    mailManager.Send(mailContents);
                }
            }
        }
    }
}
