using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookLibrary
{
    public class Authorization
    {
        Dictionary<string, string> users;
        public Authorization(AllRegisteredUsersHelper allRegisteredUsersList)
        {
            users = allRegisteredUsersList.AllRegisteredUsersList;
        }

        //Validate whether this user exists in the system
        public bool ValidateRegisteredUser(string login, string pass)
        {
            foreach (var user in users)
            {
                if (user.Key.Equals(login) && user.Value.Equals(pass))
                    return true;
            }
            return false;
        }
    }
}
