using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebShopProjectServiceLayer;
using WebShopProjectViewModels;

namespace WebShopProject.ApiControllers
{

    
    public class AccountController : ApiController
    {

        private readonly IUserService us;


        public AccountController(IUserService us)
        {
            this.us = us;

        }

        public string Get(string Email)
        {
            if (this.us.GetUsersByEmail(Email) !=null)
                {
                    return "Found";
                }
            else
            {
                return "Not Found";
            }
        }

    }
}
