using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Security;
using kist_api.Interfaces;

namespace kist_api.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IUserDataRepository _userDataRepository;
        protected string _aspConnectionString;
        private static void SetProviderConnectionString(string connectionString)
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
    }


  
}
