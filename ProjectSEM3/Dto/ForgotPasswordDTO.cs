using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSEM3.Dto
{
    public class ForgotPasswordDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordNew { get; set; }
    }
}