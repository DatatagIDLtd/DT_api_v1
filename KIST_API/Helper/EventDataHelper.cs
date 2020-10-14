//using DTCommsLib1;
//using DTCommsLib1.Models;
using System;
using System.Web.Configuration;
//using static CECP.Helpers.Enums;

namespace kist_api.Helpers
{
    public class EventDataHelper
    {
       // readonly ExceptionClient _exceptionClient;
       // readonly ClientConfig _clientConfig;
        readonly string _APIUserName;
        readonly string _APIPassword;
        readonly string _APIToken;
        readonly string _EmailRecipient;
        readonly string _EmailRegex;
        readonly int _EventSourceID;
       // readonly ClientEmailConfig _clientEmailConfig;
        readonly string _From;
        readonly string _Subject;
        readonly string _SmtpPort;
        readonly string _SmtpHost;
        readonly string _EnableSSL;
        readonly string _UseDefaultCredentials;
        readonly string _Username;
        readonly string _Password;
        readonly string _EndPoint;

        public EventDataHelper()
        {
     //       _exceptionClient = new ExceptionClient();
            _APIUserName = WebConfigurationManager.AppSettings["APIUserName"];
            _APIPassword = WebConfigurationManager.AppSettings["APIPassword"];
            _APIToken = WebConfigurationManager.AppSettings["APIToken"];
            _EmailRecipient = WebConfigurationManager.AppSettings["EmailRecipient"];
            _EmailRegex = WebConfigurationManager.AppSettings["EmailRegex"];
            _EventSourceID = Convert.ToInt32(WebConfigurationManager.AppSettings["EventSourceID"]);
            _From = WebConfigurationManager.AppSettings["EmailFrom"];
            _Subject = WebConfigurationManager.AppSettings["EmailSubject"];
            _SmtpPort = WebConfigurationManager.AppSettings["EmailSmtpPort"];
            _SmtpHost = WebConfigurationManager.AppSettings["EmailSmtpHost"];
            _EnableSSL = WebConfigurationManager.AppSettings["EmailEnableSSL"];
            _UseDefaultCredentials = WebConfigurationManager.AppSettings["EmailUseDefaultCredentials"];
            _Username = WebConfigurationManager.AppSettings["EmailUsername"];
            _Password = WebConfigurationManager.AppSettings["EmailPassword"];
            _EndPoint = WebConfigurationManager.AppSettings["Endpoint"];

            //_clientConfig = new ClientConfig()
            //{
            //    ContentType = "application/json",
            //    APIUserName = _APIUserName,
            //    APIPassword = _APIPassword,
            //    APIToken = _APIToken,
            //    EmailRecipient = _EmailRecipient,
            //    EmailRegex = _EmailRegex,
            //    Endpoint = _EndPoint
            //};

            //_clientEmailConfig = new ClientEmailConfig()
            //{
            //    From = _From,
            //    Subject = _Subject,
            //    SmtpPort = Convert.ToInt32(_SmtpPort),
            //    SmtpHost = _SmtpHost,
            //    EnableSSL = Convert.ToBoolean(_EnableSSL),
            //    UseDefaultCredentials = Convert.ToBoolean(_UseDefaultCredentials),
            //    Username = _Username,
            //    Password = _Password,
            //    EmailRegEx = _EmailRegex,
            //    EmailRecipient = _EmailRecipient
            //};
        }

        //public void SendEventData(string methodName, Exception ex, EventAdvice eventAdvice, EventType eventType)
        //{
        //    try
        //    {
        //        var error = methodName + ": " + ex.Message;
        //        string innerException = ex.InnerException == null ? string.Empty : ex.InnerException.ToString();
        //        if (!string.IsNullOrWhiteSpace(innerException)) error += ": " + ex.InnerException;
        //        _clientConfig.HttpMethod = "POST";
        //        _clientConfig.Destination = "";
        //        _clientConfig.DatabaseName = "DTCECP";
        //        _clientConfig.EventAdviceID = (int)eventAdvice;
        //        _clientConfig.EventSourceID = _EventSourceID;
        //        _clientConfig.EventTypeID = (int)eventType;
        //        _clientConfig.FieldData = "";
        //        _clientConfig.KeyName = "CECP Application Error";
        //        _clientConfig.KeyValue = "Application Error";
        //        _clientConfig.MembershipType = "";
        //        _clientConfig.Mute = (int)eventType > 902;
        //        _clientConfig.OperatorID = "";
        //        _clientConfig.RecordID = "";
        //        _clientConfig.SnoozeUntil = "";
        //        _clientConfig.TableField = "";
        //        _clientConfig.TableName = "";
        //        _clientConfig.UserName = "";
        //        _clientConfig.CreatedBy = "DTAppUser";
        //        _clientConfig.ObjectName = "EventData";
        //        _clientConfig.Report = error;
        //        var response = _exceptionClient.AddException(_clientConfig);

        //        if (response.ToUpper().Contains("ERROR"))
        //        {
        //            _exceptionClient.SendEmail(_clientEmailConfig, response);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        var error = e.Message;
        //        string innerException = e.InnerException == null ? string.Empty : e.InnerException.ToString();
        //        if (!string.IsNullOrWhiteSpace(innerException)) error += ": " + e.InnerException;
        //        _exceptionClient.SendEmail(_clientEmailConfig, "An API Error has occurred: " + error);
        //    }
        //}
    }
}