using kist_api.Models.Account;
using kist_api.Models;
using kist_api.ViewModels.Account;
using System;
using System.IO;
using System.Web.Security;

namespace kist_api.Helpers
{
    public class AccountHelper
    {
      //  readonly EmailHelper _emailHelper;

        public AccountHelper()
        {
         //   _emailHelper = new EmailHelper();
        }

        public string GetMembershipErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Email already exists. Please enter a different one.";
                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different one.";
                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Mixture of Upper/Lower case and one Number required.";
                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        public void SendRegistrationEmail(UserDetailsViewModel viewModel, string emailTemplate, string changeLink, string primaryContact, string jobTitle, string projectName, string username)
        {
            try
            {
                var body = string.Empty;
                using (StreamReader sreader = new StreamReader(emailTemplate))
                {
                    body = sreader.ReadToEnd();
                    body = body.Replace("[Forename]", viewModel.Forename);
                    body = body.Replace("[Surname]", viewModel.Surname);
                    body = body.Replace("[Link]", changeLink.Replace("/Account/Register", ""));
                    body = body.Replace("[PrimaryContact]", primaryContact);
                    body = body.Replace("[JobTitle]", jobTitle);
                    body = body.Replace("[ProjectName]", projectName);
                    body = body.Replace("[Username]", username);
                }

             //   _emailHelper.SendEventDataEmail("Registration Email Event", "CECP " + projectName + " - Registration Confirmation", body, viewModel.Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void SendPasswordResetEmail(PWResetRequestModel request, string forename, string surname, string emailTemplate, string changeLink)
        //{
        //    try
        //    {
        //        var body = string.Empty;
        //        using (StreamReader sreader = new StreamReader(emailTemplate))
        //        {
        //            body = sreader.ReadToEnd();
        //            body = body.Replace("[Forename]", forename);
        //            body = body.Replace("[Surname]", surname);
        //            body = body.Replace("[Link]", changeLink.Replace("ResetPassword", "ViewChangePassword") + "?id=" + request.GlobalID.ToString());

        //        }

        //        _emailHelper.SendEventDataEmail("Reset Password Email Event", "CECP - Password Reset Request", body, request.Email);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void SendChangePasswordEmail(UserDetailsViewModel viewModel, string emailTemplate, string changeLink, string username)
        {
            try
            {
                var body = string.Empty;
                using (StreamReader sreader = new StreamReader(emailTemplate))
                {
                    body = sreader.ReadToEnd();
                    body = body.Replace("[Forename]", viewModel.Forename);
                    body = body.Replace("[Surname]", viewModel.Surname);
                    body = body.Replace("[Link]", changeLink.Replace("ChangePassword", "ViewLogin"));
                    body = body.Replace("[Username]", username);
                }

               // _emailHelper.SendEventDataEmail("Password Changed Email Event", "CECP - Password Changed", body, viewModel.Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void SendInviteEmail(SupplierInviteModel supplierInviteModel, string supplierName, string emailTemplate, string changeLink, string primaryContact, string jobTitle, string projectName)
        //{
        //    try
        //    {
        //        var body = string.Empty;
        //        using (StreamReader sreader = new StreamReader(emailTemplate))
        //        {
        //            body = sreader.ReadToEnd();
        //            body = body.Replace("[Name]", supplierName);
        //            body = body.Replace("[Link]", changeLink.Replace("CECP/SaveInviteSupplier", "Account/ViewRegister") + "?iG=" + supplierInviteModel.InviteGUID);
        //            body = body.Replace("[PrimaryContact]", primaryContact);
        //            body = body.Replace("[JobTitle]", jobTitle);
        //            body = body.Replace("[ProjectName]", projectName);
        //        }

        //        _emailHelper.SendEventDataEmail("Invite Supplier Email Event", "CECP " + projectName + " - Supplier Invitation", body, supplierInviteModel.SupplierEmailAddress);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}