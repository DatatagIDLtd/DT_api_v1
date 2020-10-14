using kist_api.ViewModels.Account;
//using kist_api.ViewModels.Lists;
using System.Collections.Generic;

namespace kist_api.Interfaces
{
    public interface IUserDataRepository
    {
       // string Register(UserDetailsViewModel userViewModel, string emailTemplate, string changeLink);
        string Login(UserDetailsViewModel userViewModel);
      //  UserDetailsViewModel GetUserViewModel(string username);
      ////  ProjectListViewModel GetProjectListViewModel(long userID);
      //  UserDetailsViewModel GetUserViewModelTemplate();
      //  string ValidateLink(string globalID);
      //  long GetUserID(string id);
      //  string ResetPassword(UserDetailsViewModel userViewModel, string emailTemplate, string changeLink);
      //  string ChangePassword(UserDetailsViewModel userViewModel, string emailTemplate, string changeLink);
      //  List<AddressViewModel> GetAddresses(string postcode);
    }
}