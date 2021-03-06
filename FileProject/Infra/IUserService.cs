﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileProject.Infra
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<User> Login(User user);
    }
}
