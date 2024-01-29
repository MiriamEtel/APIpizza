using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Interfaces;
using Models;
using fileService;

namespace Services
{
   public class IdentityService : Iidentity
    {
    private IWorker _worker;
    
        public IdentityService(IWorker worker)
        {
            _worker = worker;

        }
        private static SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));
        private static string issuer = "https://my-pizza.com";
        //without statid-with DI
        public SecurityToken GetToken(List<Claim> claims) =>
         new JwtSecurityToken(
             issuer,
             issuer,
             claims,
             expires: DateTime.Now.AddDays(30.0),
             signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
         );

        public static TokenValidationParameters GetTokenValidationParameters() =>
            new TokenValidationParameters
            {
                ValidIssuer = issuer,
                ValidAudience = issuer,
                IssuerSigningKey = key,
                ClockSkew = TimeSpan.Zero // remove delay of token when expire
            };

        
        public SecurityToken Login(User user){

            var workers= _worker.Get();
            var existWorker = workers.FirstOrDefault(w => ((w.Name.Equals(user.Name))&&(w.Password).Equals(user.Password)));
            if (existWorker == null)
                return null;

            List<Claim> Claims=new List<Claim>
            {
                new Claim("UserType" ,existWorker.Role.ToString()),
                new Claim("userId", existWorker.Id.ToString())
            };

            var token=this.GetToken(Claims);
            return token;    
        }
    }

}
