using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_schedule
{
    public class loginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public loginModel(string Username,string  Password)
        {
            this.UserName = Username;
            this.Password = Password;
        }
    }
}
