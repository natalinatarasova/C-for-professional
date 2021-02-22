using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookLibrary
{
    public class AddingNewUser
    {
        public AddingNewUser(AllRegisteredUsersHelper allRegisteredUsersList, string login, string pass)
        {
            try
            {
                allRegisteredUsersList.AllRegisteredUsersList.Add(login, pass);
                allRegisteredUsersList.AddingNewUserToDB(login, pass);
            }
            catch 
            {
                throw new Exception("\n!!! User with the following login info already exists in the system !!!\nTry to sign in using this data or use different info for creation a new account.\n");
            }
        }
    }
}
