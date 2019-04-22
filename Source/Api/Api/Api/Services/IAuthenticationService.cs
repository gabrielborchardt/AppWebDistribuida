﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IAuthenticationService
    {
        string Login(string user, string pass);
        bool IsAuth(string userCode, string route);
    }
}
