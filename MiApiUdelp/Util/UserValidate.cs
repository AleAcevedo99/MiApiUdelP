using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiApiUdelp.Util
{
    public class UserValidate
    {
        public static bool Login(string username, string password)
        {
            bool answer = false;

            if (username.Equals("ale") && password.Equals("123"))
            {
                answer = true;
            }

            return answer;
        }
    }
}