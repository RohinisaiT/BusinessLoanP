﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DataService;

namespace BL.UI.Repositories
{
    public class LoginRepository
    {
        public BusinessLoanEntities dbEntities;
        public LoginRepository()
        {
            dbEntities = new BusinessLoanEntities();
        }
        public void validateUser(Login data)
        {

        }
    }
}