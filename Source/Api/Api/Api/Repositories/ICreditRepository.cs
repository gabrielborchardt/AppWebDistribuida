﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface ICreditRepository
    {
        bool HaveExpiredCredit(string cpf);
    }
}
