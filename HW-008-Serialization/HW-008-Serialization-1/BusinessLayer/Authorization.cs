using System;
using System.Collections.Generic;
using System.Text;

namespace HW_008_Serialization_1
{
    public class Authorization
    {
        private Registration Registration;
        public Authorization(Registration registration)
        {
            Registration = registration;
        }

        public bool ValidateAuthorization(string login, string pass, out DateTime date)
        {
            if (Registration.HasRegisteredUser(new Users(login, pass)))
            {
                date = DateTime.Now;
                return true;
            }
            else
            {
                date = DateTime.MinValue;
            }

            return false;
        }
    }
}
