
using kist_api.Helpers;


using kist_api.Interfaces;
using kist_api.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Web.Security;

namespace kist_api.Repositories
{
    public class UserDataRepository : IUserDataRepository
    {
        //readonly APIData _apiData;
        //readonly DTCAD _dTCAD;
        //readonly AccountHelper _accountHelper;
        //readonly ListHelper _listHelper;

        public UserDataRepository()
        {
            try
            {
                //_apiData = new APIData();
                //_dTCAD = new DTCAD();
                //_accountHelper = new AccountHelper();
                //_listHelper = new ListHelper();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public string Register(UserDetailsViewModel viewModel, string emailTemplate, string changeLink)
        //{
        //    try
        //    {
        //        if (_apiData.GetSupplierInviteModelList().FirstOrDefault(x => x.ID == viewModel.SupplierInviteID).InviteAcceptedDate != null)
        //        {
        //            return "Registration already completed.";
        //        }

        //        var checkUsername = Membership.GetUser(viewModel.Username);
        //        if (checkUsername != null) return "Username already taken.";
                
        //        var checkEmail = Membership.FindUsersByEmail(viewModel.Email);
        //        if (checkEmail.Count > 0) return "Email already registered.";

                
        //        MembershipUser user;
        //        try
        //        {
        //            user = Membership.CreateUser(viewModel.Username, viewModel.Password, viewModel.Email);
        //        }
        //        catch (MembershipCreateUserException e)
        //        {
        //            return _accountHelper.GetMembershipErrorMessage(e.StatusCode);
        //        }

        //        user.IsApproved = true;
        //        Membership.UpdateUser(user);
        //        var membershipUser = Membership.GetUser(viewModel.Username);
        //        if (membershipUser != null)
        //        {
        //            //User Detail.
        //            var model = new UserDetailsModel()
        //            {
        //                MemProviderUserID = Guid.Parse(membershipUser.ProviderUserKey.ToString()),
        //                Title = viewModel.TitleViewModel.TitleName,
        //                Forename = viewModel.Forename.Trim(),
        //                Surname = viewModel.Surname.Trim(),
        //                BuildingNo = viewModel.BuildingNo,
        //                BuildingName = viewModel.BuildingName,
        //                AddressLine1 = viewModel.AddressLine1.Trim(),
        //                AddressLine2 = viewModel.AddressLine2,
        //                AddressLine3 = viewModel.AddressLine3,
        //                AddressLine4 = viewModel.AddressLine4,
        //                TownCity = viewModel.TownCity.Trim(),
        //                District = viewModel.District,
        //                County = viewModel.County,
        //                PostCode = viewModel.PostCode.Trim(),
        //                CountryCode = viewModel.CountryViewModel.CountryCode,
        //                Telephone = viewModel.Telephone,
        //                Mobile = viewModel.Mobile,
        //                Email = viewModel.Email.Trim(),
        //                IsActive = viewModel.IsActive,
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = membershipUser.UserName
        //            };
        //            var userDetailID = _apiData.InsertUserDetail(model, 2);

        //            //Update Invite if exists.
        //            var supplierInviteModel = _apiData.GetSupplierInviteModelList().FirstOrDefault(x => x.ID == viewModel.SupplierInviteID);
        //            supplierInviteModel.InviteAcceptedDate = DateTime.Now;
        //            _apiData.UpdateInviteAcceptedDate(supplierInviteModel);

        //            //Registered Supplier.
        //            var supplierModel = new RegisteredSupplierModel()
        //            {
        //                RegisteredSupplierCompanyID = supplierInviteModel.RegisteredSupplierCompanyID,
        //                UserDetailID = userDetailID,
        //                ProjectID = supplierInviteModel.ProjectID,
        //                IsActive = true,
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = viewModel.Username
        //            };

        //            _apiData.SaveRegisteredSupplier(supplierModel);

        //            var projectName = _apiData.GetProjectModelList().FirstOrDefault(x => x.ID == supplierInviteModel.ProjectID).Name;
        //            var contactRegisteredSupplier = _apiData.GetRegisteredSupplierModelList().FirstOrDefault(x => x.ProjectID == supplierInviteModel.ProjectID);
        //            var contactUser = _apiData.GetUserDetailModelList().FirstOrDefault(x => x.ID == contactRegisteredSupplier.UserDetailID);
        //            var contactJobTitle = _apiData.GetSiteModelList().FirstOrDefault(x => x.ProjectID == supplierInviteModel.ProjectID).ContactJobTitle;

        //            //Email.
        //            _accountHelper.SendRegistrationEmail(viewModel, emailTemplate, changeLink, contactUser.Forename + " " + contactUser.Surname, contactJobTitle, projectName, viewModel.Username);
        //            return null;
        //        }

        //        return "Registration failed - unable to create user.";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public string Login(UserDetailsViewModel viewModel)
        {
            try
            {
                var user = Membership.GetUser(viewModel.Username.Trim());
                if (user != null)
                {
                    if (user.IsLockedOut)
                    {
                        return "Your account has been locked. Please contact Tech Support at <a href='mailto:techsupport@datatag.co.uk'>techsupport@datatag.co.uk</a>";
                    }
                }

                if (!Membership.ValidateUser(viewModel.Username.Trim(), viewModel.Password))
                {
                    return "Invalid credentials.";
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public UserDetailsViewModel GetUserViewModel(string username)
        //{
        //    try
        //    {
        //        var applicationCode = WebConfigurationManager.AppSettings["ApplicationCode"];
        //        var application = _apiData.GetApplicationsModelList().Where(x => x.ApplicationCode == applicationCode).FirstOrDefault();
        //        var user = Membership.GetUser(username);
        //        var userDetails = _apiData.GetUserDetailModelList().Where(x => x.MemProviderUserID.ToString().ToUpper() == user.ProviderUserKey.ToString().ToUpper()).ToList();

        //        if (userDetails.Count > 0)
        //        {
        //            var userDetail = userDetails.FirstOrDefault();
        //            var userInApplicationRole = _apiData.GetUsersInApplicationRolesModelList().Where(x => x.UserDetailID == userDetail.ID).Where(x => x.ApplicationID == application.ID).FirstOrDefault();
        //            var role = _apiData.GetRolesModelList().FirstOrDefault(x => x.ID == userInApplicationRole.RoleID);

        //            if (role != null)
        //            {
        //                return new UserDetailsViewModel()
        //                {
        //                    ID = userDetail.ID,
        //                    Username = username,
        //                    Email = userDetail.Email,
        //                    RolesModel = role
        //                };
        //            }
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public ProjectListViewModel GetProjectListViewModel(long userID)
        //{
        //    try
        //    {
        //        var registeredSuppliers = _apiData.GetRegisteredSupplierModelList().Where(x => x.UserDetailID == userID).Select(x => x.ProjectID).ToList();
        //        return new ProjectListViewModel() { ProjectList = _apiData.GetProjectModelList().Where(x => registeredSuppliers.Contains(x.ID)).ToList() };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public UserDetailsViewModel GetUserViewModelTemplate()
        //{
        //    try
        //    {
        //        return new UserDetailsViewModel()
        //        {
        //            TitleViewModel = _listHelper.GetTitleList("-1"),
        //            CountryViewModel = _listHelper.GetCountryList("UK"),
        //            IsActive = true
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string ValidateLink(string id)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(id))
        //        {
        //            if (id.Trim().Length == 36)
        //            {
        //                Regex SpecialCharacters = new Regex(@"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""_]");
        //                if (!SpecialCharacters.IsMatch(id.Trim()))
        //                {
        //                    var reset = _dTCAD.GetPWResetRequestModelList().FirstOrDefault(x => x.GlobalID.ToString() == id);
        //                    if (reset != null)
        //                    {
        //                        if (reset.Expires_On > DateTime.Now)
        //                        {
        //                            return null;
        //                        }
                                
        //                        return "Link expired. Please resend request.";
        //                    }
        //                }
        //            }
        //        }

        //        return "Invalid reset link. Please resend request.";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public long GetUserID(string id)
        //{
        //    try
        //    {
        //        var username = _dTCAD.GetPWResetRequestModelList().FirstOrDefault(x => x.GlobalID.ToString() == id).User_Name;
        //        var user = Membership.GetUser(username);
        //        return _apiData.GetUserDetailModelList().FirstOrDefault(x => x.MemProviderUserID.ToString() == user.ProviderUserKey.ToString()).ID;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string ResetPassword(UserDetailsViewModel viewModel, string emailTemplate, string changeLink)
        //{
        //    try
        //    {
        //        var existingResetRequest = _dTCAD.GetPWResetRequestModelList().Where(x => x.Email == viewModel.Email && x.Expires_On > DateTime.Now).ToList();
        //        if (existingResetRequest != null)
        //        {
        //            if (existingResetRequest.Count > 10) return "Reset attempt limit reached. Please contact Tech Support at <a href='mailto:techsupport@datatag.co.uk'>techsupport@datatag.co.uk</a>"; 
        //        }

        //        var userDetailsModel = _apiData.GetUserDetailModelList().FirstOrDefault(x => x.Email.ToUpper() == viewModel.Email.Trim().ToUpper());
        //        if (userDetailsModel == null)
        //        {
        //            return "User not found. Please try again.";
        //        }

        //        var username = Membership.GetUserNameByEmail(viewModel.Email);
        //        var user = Membership.GetUser(username);
        //        if (user == null)
        //        {
        //            return "User not found. Please try again.";
        //        }
        //        else if (!user.IsApproved)
        //        {
        //            return "Account has not yet been approved.";
        //        }

        //        var request = new PWResetRequestModel()
        //        {
        //            User_Name = user.UserName,
        //            Email = viewModel.Email,
        //            GlobalID = Guid.NewGuid(),
        //            Expires_On = DateTime.Now.AddMinutes(60),
        //            Created_On = DateTime.Now,
        //            Created_By = "SYS-MODIFICATION"
        //        };

        //        _dTCAD.InsertPWResetRequestModel(request);
        //        _accountHelper.SendPasswordResetEmail(request, userDetailsModel.Forename, userDetailsModel.Surname, emailTemplate, changeLink);
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string ChangePassword(UserDetailsViewModel viewModel, string emailTemplate, string changeLink)
        //{
        //    try
        //    {
        //        var userDetail = _apiData.GetUserDetailModelList().FirstOrDefault(x => x.ID == viewModel.ID);
        //        var username = Membership.GetUserNameByEmail(userDetail.Email);
        //        var user = Membership.GetUser(username);

        //        if (user.IsLockedOut)
        //        {
        //            user.UnlockUser();
        //        }

        //            string autopass = user.ResetPassword();
        //        if (user.ChangePassword(autopass, viewModel.Password))
        //        {
        //            viewModel.Forename = userDetail.Forename;
        //            viewModel.Surname = userDetail.Surname;
        //            viewModel.Email = userDetail.Email;
        //            _accountHelper.SendChangePasswordEmail(viewModel, emailTemplate, changeLink, username);
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<AddressViewModel> GetAddresses(string postcode)
        //{
        //    try
        //    {
        //        var list = new List<AddressViewModel>();
        //        var addresses = _apiData.GetAddresses(postcode);
        //        long id = 1;
        //        if (addresses != null)
        //        {
        //            foreach (var address in addresses)
        //            {
        //                var viewModel = new AddressViewModel
        //                {
        //                    AddressID = id,
        //                    AddressName = address.line_1 + (string.IsNullOrWhiteSpace(address.town_or_city) ? string.Empty : ", " + address.town_or_city) + (string.IsNullOrWhiteSpace(address.county) ? string.Empty : ", " + address.county),
        //                    BuildingNo = address.building_number,
        //                    BuildingName = address.building_name,
        //                    AddressLine1 = address.thoroughfare,
        //                    AddressLine2 = address.line_2,
        //                    AddressLine3 = address.line_3,
        //                    AddressLine4 = address.line_4,
        //                    TownCity = address.town_or_city,
        //                    District = address.district,
        //                    County = address.county
        //                };
        //                list.Add(viewModel);
        //                id++;
        //            }
        //        }

        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}