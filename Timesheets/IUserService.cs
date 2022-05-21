using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets
{
   public interface IUserService
    {
        string Authenticate(string user, string password);
    }
}
