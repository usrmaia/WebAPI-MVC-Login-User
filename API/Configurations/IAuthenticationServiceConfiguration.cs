using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Configurations
{
    public interface IAuthenticationServiceConfiguration
    {
        public string GetToken(User userOutput);
    }
}