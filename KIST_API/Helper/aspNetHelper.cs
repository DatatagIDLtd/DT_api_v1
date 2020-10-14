using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTCommsLib1.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using kist_api.Models;

namespace kist_api.Helper
{
    public class aspNetHelper
    {



            public void SetMembership(string connectionString)
            {
                var connectionStringField = Membership.Provider.GetType().GetField("_sqlConnectionString", BindingFlags.Instance | BindingFlags.NonPublic);
                if (connectionStringField != null)
                {
                    connectionStringField.SetValue(Membership.Provider, connectionString);
                }

                var passwordLengthField = Membership.Provider.GetType().GetField("_MinRequiredPasswordLength", BindingFlags.Instance | BindingFlags.NonPublic);
                if (passwordLengthField != null)
                {
                    passwordLengthField.SetValue(Membership.Provider, 8);
                }

                var requiredNonAlphanumericField = Membership.Provider.GetType().GetField("_MinRequiredNonalphanumericCharacters", BindingFlags.Instance | BindingFlags.NonPublic);
                if (requiredNonAlphanumericField != null)
                {
                    requiredNonAlphanumericField.SetValue(Membership.Provider, 1);
                }

                var requiresUniqueEmailField = Membership.Provider.GetType().GetField("_RequiresUniqueEmail", BindingFlags.Instance | BindingFlags.NonPublic);
                if (requiresUniqueEmailField != null)
                {
                    requiresUniqueEmailField.SetValue(Membership.Provider, true);
                }

                //Dont remove this even if it looks like its not needed
                var requiresQuestionAndAnswerField = Membership.Provider.GetType().GetField("_RequiresQuestionAndAnswer", BindingFlags.Instance | BindingFlags.NonPublic);
                if (requiresQuestionAndAnswerField != null)
                {
                    requiresQuestionAndAnswerField.SetValue(Membership.Provider, false);
                }

            }
            public LoginResponse Login(string userName, string password)
            {

            var loginResponse = new LoginResponse();


                try
                {
                    var user = Membership.GetUser(userName.Trim());
                    if (user != null)
                    {
                        if (user.IsLockedOut)
                        {
                        loginResponse.response =  "Your account has been locked. Please contact Tech Support at <a href='mailto:techsupport@datatag.co.uk'>techsupport@datatag.co.uk</a>";
                        }
                    }

                    if (!Membership.ValidateUser(userName.Trim(), password))
                    {
                    loginResponse.response =  "Invalid credentials.";
                    }

                loginResponse.userDetails = user;
                }
                catch (Exception ex)
                {
                     loginResponse.response = ex.Message;
                //throw ex;
                     return loginResponse;
                }

            return loginResponse;
        }

        }
    }

