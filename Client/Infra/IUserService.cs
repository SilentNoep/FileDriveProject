using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infra
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<User> SignIn(User user);

    }
}
