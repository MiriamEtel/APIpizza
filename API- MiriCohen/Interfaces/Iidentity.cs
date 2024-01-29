using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface Iidentity
    {
        SecurityToken GetToken(List<Claim> claims);
        SecurityToken Login(User user);
    }
}