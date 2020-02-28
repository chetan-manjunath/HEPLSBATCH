using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Travel_schedule
{
    [Serializable]
    internal class LoginFailureException : Exception
    {
        public LoginFailureException()
        {
        }

        public LoginFailureException(string message) : base(message)
        {
        }



    }
}