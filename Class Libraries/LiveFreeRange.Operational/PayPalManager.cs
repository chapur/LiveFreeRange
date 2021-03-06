﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Security.Cryptography.X509Certificates;

using LiveFreeRange.Common;
using LiveFreeRange.Operational.PayPalAPI.Sandbox;
using System.Configuration;

namespace LiveFreeRange.Operational
{
    public struct PayPalInformation
    {
        public Orders Order;
    }

    public class PayPalManager
    {
        private PayPalAPIAASoapBinding PPInterface = new PayPalAPIAASoapBinding();
        private PayPalAPISoapBinding service = new PayPalAPISoapBinding();

        #region public properties
        private bool _isSubmissionSuccess;

        public bool IsSubmissionSuccess
        {
            get { return _isSubmissionSuccess; }
            set { _isSubmissionSuccess = value; }
        }

        private string _submissionError;

        public string SubmissionError
        {
            get { return _submissionError; }
            set { _submissionError = value; }
        }
        #endregion

        public PayPalManager()
        {
            UserIdPasswordType user = new UserIdPasswordType();

            //set api credentials
            user.Username = PaypalConstants.PayPalSandboxApiUserName;
            user.Password = PaypalConstants.PayPalSandboxApiPassword;

            PPInterface.Url = PaypalConstants.PayPalSandboxApiUrl;

            PPInterface.RequesterCredentials = new CustomSecurityHeaderType();
            PPInterface.RequesterCredentials.Credentials = new UserIdPasswordType();
            PPInterface.RequesterCredentials.Credentials = user;

            service.Url = PaypalConstants.PayPalSandboxApiUrl;
            service.RequesterCredentials = new CustomSecurityHeaderType();
            service.RequesterCredentials.Credentials = new UserIdPasswordType();
            service.RequesterCredentials.Credentials = user;

            //this is .net 2.0 specific portion of the code
            //that allows us to have the .p12 on the filesystem and
            //not have to register it with WinHttpCertCfg uses
            //X509Certificate2 class.
            FileStream fStream = File.Open(CertPath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fStream.Length];

            int count = fStream.Read(buffer, 0, buffer.Length);

            fStream.Close();

            //use .net 2.0 X509Certificate2 class to read .p12 from filesystem
            //where "12345678" is the private key password
            X509Certificate2 cert = new X509Certificate2(buffer, CertPassword);
            PPInterface.ClientCertificates.Add(cert);
            service.ClientCertificates.Add(cert);
        }

        private string CertPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CertificatePath"]);
            }
        }

        private string CertPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["CertificatePassword"];
            }
        }

        private string APIUsername
        {
            get { return PaypalConstants.PayPalSandboxApiUserName; }
        }

        private string APIPassword
        {
            get { return PaypalConstants.PayPalSandboxApiPassword; }
        }

        private string APIPath
        {
            get { return PaypalConstants.PayPalSandboxApiUrl; }
        }

        public PayPalInformation GetExpressCheckoutDetails(PayPalInformation payPalInformation, string token)
        {
            GetExpressCheckoutDetailsResponseType GetECDetailsRes = new GetExpressCheckoutDetailsResponseType();
            GetExpressCheckoutDetailsRequestType GetECDetailsReqType = new GetExpressCheckoutDetailsRequestType();
            GetExpressCheckoutDetailsReq GetECDetailsReq = new GetExpressCheckoutDetailsReq();

            GetECDetailsReqType.Version = "53.0";
            GetECDetailsReqType.Token = token;

            GetECDetailsReq.GetExpressCheckoutDetailsRequest = GetECDetailsReqType;

            PayPalAPIAASoapBinding PPInterface = new PayPalAPIAASoapBinding();
            UserIdPasswordType user = new UserIdPasswordType();
            user.Username = this.APIUsername;
            user.Password = this.APIPassword;
            user.AuthCert = CertPath;

            PPInterface.Url = this.APIPath;
            PPInterface.RequesterCredentials = new CustomSecurityHeaderType();
            PPInterface.RequesterCredentials.Credentials = new UserIdPasswordType();
            PPInterface.RequesterCredentials.Credentials = user;

            FileStream fStream = File.Open(CertPath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fStream.Length];

            int count = fStream.Read(buffer, 0, buffer.Length);

            fStream.Close();

            X509Certificate2 x509 = new X509Certificate2(buffer, CertPassword);
            PPInterface.ClientCertificates.Add(x509);
            //PayPalInformation PPInformation = new PayPalInformation();
            GetECDetailsRes = PPInterface.GetExpressCheckoutDetails(GetECDetailsReq);
            if (GetECDetailsRes.Ack == AckCodeType.Success)
            {

                payPalInformation.Order.Enduser.FirstName = GetECDetailsRes.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerName.FirstName;
                payPalInformation.Order.Enduser.LastName = GetECDetailsRes.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerName.LastName;
                payPalInformation.Order.ShippingAddress.AddressLine = GetECDetailsRes.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.Street1;
                payPalInformation.Order.ShippingAddress.AddressLine2 = GetECDetailsRes.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.Street2;
                payPalInformation.Order.ShippingAddress.City = GetECDetailsRes.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.CityName;
                payPalInformation.Order.ShippingAddress.PostalCode = GetECDetailsRes.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.PostalCode;
                payPalInformation.Order.PayerId = GetECDetailsRes.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID;
            }
            return payPalInformation;
        }

        public OrderInfo DoExpressCheckout(string token, PayPalInformation payPalInformation)
        {
            #region old do express checkout
            DoExpressCheckoutPaymentRequestDetailsType DoECPmtReqDetails = new DoExpressCheckoutPaymentRequestDetailsType();
            DoExpressCheckoutPaymentRequestType DoECReqType = new DoExpressCheckoutPaymentRequestType();
            DoECReqType.DoExpressCheckoutPaymentRequestDetails = new DoExpressCheckoutPaymentRequestDetailsType();

            DoExpressCheckoutPaymentReq DoECPmtReq = new DoExpressCheckoutPaymentReq();
            DoECPmtReq.DoExpressCheckoutPaymentRequest = new DoExpressCheckoutPaymentRequestType();

            DoExpressCheckoutPaymentResponseType DoECPmtRes = new DoExpressCheckoutPaymentResponseType();

            DoECReqType.Version = "2.20";

            DoECPmtReqDetails.Token = token;

            DoECPmtReqDetails.PayerID = payPalInformation.Order.EndUserId.ToString();

            DoECPmtReqDetails.PaymentAction = PaymentActionCodeType.Sale;

            DoECPmtReqDetails.PaymentDetails = new PaymentDetailsType();

            DoECPmtReqDetails.PaymentDetails.OrderDescription = "Talamh Order";

            DoECPmtReqDetails.PayerID = payPalInformation.Order.PayerId;

            DoECPmtReqDetails.PaymentDetails.OrderTotal = new BasicAmountType();

            DoECPmtReqDetails.PaymentDetails.OrderTotal.currencyID = CurrencyCodeType.GBP;

            DoECPmtReqDetails.PaymentDetails.OrderTotal.Value = payPalInformation.Order.SubTotal.ToString();

            DoECReqType.DoExpressCheckoutPaymentRequestDetails = DoECPmtReqDetails;

            DoECPmtReq.DoExpressCheckoutPaymentRequest = DoECReqType;

            try
            {
                DoECPmtRes = PPInterface.DoExpressCheckoutPayment(DoECPmtReq);
                string errors = this.CheckForErrors(DoECPmtRes);
                OrderInfo order = new OrderInfo();

                if (errors == String.Empty)
                {
                    order.Ack = DoECPmtRes.Ack.ToString();
                    order.TransactionID = DoECPmtRes.DoExpressCheckoutPaymentResponseDetails.PaymentInfo.TransactionID;
                    order.ReceiptID = DoECPmtRes.DoExpressCheckoutPaymentResponseDetails.PaymentInfo.ReceiptID;
                }
                else
                    order.Ack = errors;

                return order;
            }
            catch(Exception ex)
            {
                OrderInfo error = new OrderInfo();
                error.Ack = "ERROR" + ex.ToString();
                return error;
            }
            #endregion

        }

        public string SetExpressCheckout(PayPalInformation payPalInformation, string payPalSubmitUrl, string payPalCancelUrl)
        {
            string result = string.Empty;

            SetExpressCheckoutRequestType SetECReqType = new SetExpressCheckoutRequestType();
            SetExpressCheckoutRequestDetailsType SetECReqTypeDetails = new SetExpressCheckoutRequestDetailsType();
            SetExpressCheckoutResponseType SetECRes = new SetExpressCheckoutResponseType();
            SetExpressCheckoutReq SetECReq = new SetExpressCheckoutReq();

            SetECReqType.Version = "53.0";
            SetECReqTypeDetails.OrderTotal = new BasicAmountType();
            SetECReqTypeDetails.OrderTotal.currencyID = CurrencyCodeType.GBP;
            
            SetECReqTypeDetails.OrderTotal.Value = payPalInformation.Order.SubTotal.ToString();

            //order.OrderTotal = GetAmountValue(payment.GrossAmount);
            //order.Tax = GetAmountValue(payment.TaxAmount);

            SetECReqTypeDetails.ReturnURL = ConfigurationManager.AppSettings["PayPalReturnURL"];
            SetECReqTypeDetails.CancelURL = ConfigurationManager.AppSettings["PayPalCancelURL"];

            SetECReqType.SetExpressCheckoutRequestDetails = SetECReqTypeDetails;
            SetECReq.SetExpressCheckoutRequest = SetECReqType;

            UserIdPasswordType user = new UserIdPasswordType();
            user.Username = this.APIUsername;
            user.Password = this.APIPassword;
            user.AuthCert = CertPath;
            PayPalAPIAASoapBinding ppInterface = new PayPalAPIAASoapBinding();
            ppInterface.Url = this.APIPath;
            ppInterface.RequesterCredentials = new CustomSecurityHeaderType();
            ppInterface.RequesterCredentials.Credentials = user;


            //this is .net 2.0 specific portion of the code
            //that allows us to have the .p12 on the filesystem and
            //not have to register it with WinHttpCertCfg uses
            //X509Certificate2 class.
            FileStream fStream = File.Open(CertPath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fStream.Length];

            int count = fStream.Read(buffer, 0, buffer.Length);

            fStream.Close();

            //use .net 2.0 X509Certificate2 class to read .p12 from filesystem
            //where "12345678" is the private key password
            X509Certificate2 x509 = new X509Certificate2(buffer, CertPassword);
            ppInterface.ClientCertificates.Add(x509);
            //service.ClientCertificates.Add(x509);

            try
            {
                SetECRes = ppInterface.SetExpressCheckout(SetECReq);
                switch (SetECRes.Ack)
                {
                    case AckCodeType.Success:
                        result = SetECRes.Token;
                        break;

                    default:  // show errors if Ack is NOT Success
                        result = "API response: <b>" + SetECRes.Ack.ToString() +
                            "</b><br> Timestamp: <b>" + SetECRes.Timestamp.ToLongTimeString() +
                            "</b><br> Version: <b>" + SetECRes.Version.ToString() +
                            "</b><br> Error code: <b>" + SetECRes.Errors[0].ErrorCode +
                            "</b><br> Short error: <b>" + SetECRes.Errors[0].ShortMessage +
                            "</b><br> Long error: <b>" + SetECRes.Errors[0].LongMessage;
                        break;
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }

        public static string GetPaypalFormSubmissionUrl()
        {
            if (IsPaypalSandboxOn())
                return "https://www.sandbox.paypal.com/cgi-bin/webscr";
            else
                return "https://www.paypal.com/cgi-bin/webscr";
        }

        public static bool IsPaypalSandboxOn()
        {
            bool isPaypalSandboxOn = false;
            isPaypalSandboxOn = Convert.ToBoolean(ConfigurationSettings.AppSettings.Get("isPaypalSandboxOn"));
            return isPaypalSandboxOn;
        }

        BasicAmountType GetBasicAmount(double amount)
        {
            BasicAmountType bAmount = new BasicAmountType();
            bAmount.Value = amount.ToString();
            bAmount.currencyID = CurrencyCodeType.GBP;
            
            return bAmount;
        }

        public class OrderInfo
        {
            public string TransactionID;
            public string Ack;
            public string ReceiptID;
            public string CVV2Code;
        }

        public void ProcessDirectPayment(PayPalInformation payPalInformation)
        {
            DoDirectPaymentRequestType DoDirectPmtReqType = new DoDirectPaymentRequestType();
            DoDirectPmtReqType.DoDirectPaymentRequestDetails = new DoDirectPaymentRequestDetailsType();

            //set payment action
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentAction = PaymentActionCodeType.Sale;
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.IPAddress = HttpContext.Current.Request.UserHostAddress;

            #region set credit card info
            //set credit card info
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard = new CreditCardDetailsType();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CreditCardNumber = payPalInformation.Order.CreditCard.Number;
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = (CreditCardTypeType)StringToEnum(typeof(CreditCardTypeType), payPalInformation.Order.CreditCard.CardType);
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CreditCardTypeSpecified = true;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CVV2 = payPalInformation.Order.CreditCard.SecurityCode;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.ExpMonth = payPalInformation.Order.CreditCard.ExpMonth;
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.ExpYear = payPalInformation.Order.CreditCard.ExpYear;
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.ExpMonthSpecified = true;
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.ExpYearSpecified = true;
            #endregion

            #region set billing address
            //set the billing address
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner = new PayerInfoType();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName = new PersonNameType();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName.FirstName = payPalInformation.Order.Enduser.FirstName;
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName.LastName = payPalInformation.Order.Enduser.LastName;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address = new AddressType();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Street1 = payPalInformation.Order.Enduser.Address.AddressLine;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Street2 = payPalInformation.Order.Enduser.Address.AddressLine2;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CityName = payPalInformation.Order.Enduser.Address.City;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.PostalCode = payPalInformation.Order.Enduser.Address.PostalCode;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CountrySpecified = true;
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Country = CountryCodeType.GB;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Phone = payPalInformation.Order.Enduser.ContactInformation.Phone;
            #endregion

            PaymentDetailsItemType[] itemArray = new PaymentDetailsItemType[payPalInformation.Order.OrderDetails.Products.Length];
            PaymentDetailsItemType items = null;

            //loop through all the items that were added to the shopping cart.
            for (int i = 0; i < payPalInformation.Order.OrderDetails.Products.Length; i++)
            { 
                items = new PaymentDetailsItemType();
                items.Amount = new BasicAmountType();
                items.Amount.Value = payPalInformation.Order.OrderDetails.Products[i].Price.ToString();
                items.Amount.currencyID = CurrencyCodeType.GBP;
                items.Quantity = payPalInformation.Order.OrderDetails.Products[i].Quantity.ToString();

                items.Name = payPalInformation.Order.OrderDetails.Products[i].Name;
                items.Number = payPalInformation.Order.OrderDetails.Products[i].ProductId.ToString();

                itemArray.SetValue(items, i);
            }

            #region set payment details
            //set payment details
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails = new PaymentDetailsType();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.Custom = System.DateTime.Now.ToLongTimeString();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.OrderDescription = "";

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.PaymentDetailsItem = new PaymentDetailsItemType[itemArray.Length];

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.PaymentDetailsItem = itemArray;

            for (int ii = 0; ii < itemArray.Length; ii++)
            {
                DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.PaymentDetailsItem.SetValue(itemArray[ii], ii);
            }
            #endregion

            #region order summary
            //order summary
            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal = new BasicAmountType();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.currencyID = CurrencyCodeType.GBP;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.Value = payPalInformation.Order.OrderTotal.ToString();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShippingTotal = new BasicAmountType();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShippingTotal.currencyID = CurrencyCodeType.GBP;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShippingTotal.Value = payPalInformation.Order.ShippingTotal.ToString();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.TaxTotal = new BasicAmountType();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.TaxTotal.currencyID = CurrencyCodeType.GBP;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.TaxTotal.Value = payPalInformation.Order.Tax.ToString();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ItemTotal = new BasicAmountType();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ItemTotal.currencyID = CurrencyCodeType.GBP;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ItemTotal.Value = payPalInformation.Order.SubTotal.ToString();
            #endregion

            #region set ship to address
            //set ship to address

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress = new AddressType();

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.Name = payPalInformation.Order.Enduser.FirstName + " " + payPalInformation.Order.Enduser.LastName;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.Street1 = payPalInformation.Order.ShippingAddress.AddressLine;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.CityName = payPalInformation.Order.ShippingAddress.City;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.PostalCode = payPalInformation.Order.ShippingAddress.PostalCode;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.CountrySpecified = true;

            DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.Country = CountryCodeType.GB;
            #endregion

            //credentials
            DoDirectPaymentReq DoDPReq = new DoDirectPaymentReq();
            DoDPReq.DoDirectPaymentRequest = DoDirectPmtReqType;
            DoDPReq.DoDirectPaymentRequest.Version = "2.20";

            try
            { 
                //make call return response
                DoDirectPaymentResponseType DPRes = new DoDirectPaymentResponseType();
                DPRes = PPInterface.DoDirectPayment(DoDPReq);
                string errors = CheckForErrors(DPRes);

                if (errors == string.Empty)
                {
                    IsSubmissionSuccess = true;
                    payPalInformation.Order.TransactionId = DPRes.TransactionID;
                }
                else
                {
                    IsSubmissionSuccess = false;
                    SubmissionError = errors;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private string CheckForErrors(AbstractResponseType abstractResponse)
        {
            bool errorsExist = false;
            string errorList = String.Empty;

            //first, check if Ack is not Success
            if (!abstractResponse.Ack.Equals(AckCodeType.Success))
            {
                errorsExist = true;
            }

            //check for nothing in the errors collection
            if (abstractResponse.Errors != null)
            {
                if (abstractResponse.Errors.Length > 0)
                {
                    errorsExist = true;
                    errorList = "ERROR: ";
                    for (int i = 0; i < abstractResponse.Errors.Length; i++)
                    {
                        errorList += abstractResponse.Errors[i].LongMessage + "(" + abstractResponse.Errors[i].ErrorCode + ")" + Environment.NewLine;
                    }
                }
            }

            return errorList;
        }

        private static object StringToEnum(Type typ, string val)
        {
            object objectOut = null;

            foreach (System.Reflection.FieldInfo fieldInfo in typ.GetFields())
            {
                if (fieldInfo.Name == val)
                {
                    objectOut = fieldInfo.GetValue(null);
                }
            }

            return objectOut;
        }

        public void GetTransactionDetails(Orders order)
        {
            GetTransactionDetailsRequestType detailRequest = new GetTransactionDetailsRequestType();
            detailRequest.TransactionID = order.TransactionId;
            //PayPal API version
            detailRequest.Version = "2.0";
            GetTransactionDetailsReq request = new GetTransactionDetailsReq();
            request.GetTransactionDetailsRequest = detailRequest;

            GetTransactionDetailsResponseType response = service.GetTransactionDetails(request);

            string sErrors = this.CheckForErrors(response);

            if (sErrors == string.Empty)
            {
                PaymentInfoType payment = response.PaymentTransactionDetails.PaymentInfo;

                order.OrderTotal = GetAmountValue(payment.GrossAmount);
                order.Tax = GetAmountValue(payment.TaxAmount);
                IsSubmissionSuccess = true;
            }
            else
            {
                IsSubmissionSuccess = false;
            }
        }

        private decimal GetAmountValue(BasicAmountType amount)
        {
            decimal sOut;

            try
            {
                sOut = Convert.ToDecimal(amount.Value);
                amount.currencyID = CurrencyCodeType.GBP;
            }
            catch
            {
                sOut = 0;
            }

            return sOut;
        }

        public void RefundTransaction(string transactionId)
        {
            RefundTransactionRequestType refundRequest = new RefundTransactionRequestType();
            BasicAmountType amount = new BasicAmountType();
            amount.currencyID = CurrencyCodeType.GBP;
            refundRequest.Memo = "Transaction ID: " + transactionId;
            refundRequest.RefundType = RefundType.Full;
            refundRequest.TransactionID = transactionId;
            refundRequest.Version = "2.0";

            RefundTransactionReq request = new RefundTransactionReq();
            request.RefundTransactionRequest = refundRequest;

            try
            {
                RefundTransactionResponseType response = service.RefundTransaction(request);
                string errors = CheckForErrors(response);

                if (errors == string.Empty)
                {
                    IsSubmissionSuccess = true;
                }
                else
                {
                    IsSubmissionSuccess = false;
                    SubmissionError = errors;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
