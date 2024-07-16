﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace StaffControlServer.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "https://localhost:5001";
        public const string AUDIENCE = "http://localhost:4200";
        public const string KEY = "athzdK2DOiOAY8WHRKcW49mXNBR5T1CtjdUJL06zbWY=";
        public const int LIFETIME = 200;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
