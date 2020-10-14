using kist_api.ViewModels.Account;
using kist_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using kist_api.Repositories;
using kist_api.Helper;
using System.Web.Http.ValueProviders;
using System.Configuration;

namespace kist_api.Controllers
{
    public class AccountController : BaseApiController
    {
        // GET api/values
        public AccountController()
        {
            _userDataRepository = new UserDataRepository();
            _aspConnectionString = ConfigurationManager.ConnectionStrings["DTCADConnectionString"].ConnectionString;
        }
      

        [HttpPost]
        public LoginResponse Login(Login login)
        {



            try
            {
                var aClient = new aspNetHelper();

                aClient.SetMembership(_aspConnectionString);

                var user = aClient.Login(login.username, login.password );
                
                if (user.response == null )
                {
                    //Get user info

                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
     
    }
}
