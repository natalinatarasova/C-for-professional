using System;
using System.Collections.Generic;
using System.Text;


namespace NotebookLibrary
{
    public abstract class AllRegisteredUsersHelper
    {
        private Dictionary<string, string> allRegisteredUsersList = new Dictionary<string, string>();

        public AllRegisteredUsersHelper()
        {
            AllRegisteredUsersList = allRegisteredUsersList;
        }

        public Dictionary<string, string> AllRegisteredUsersList
        {
            get { return allRegisteredUsersList; }
            set { allRegisteredUsersList = value; }
        }

        public abstract Dictionary<string, string> LoadAllExistedUsers(Dictionary<string, string> allRegisteredUsersList);

        public abstract void AddingNewUserToDB(string login, string pass);

        public abstract void AddingTextToUserFile(string login, string pass, string text);

        public abstract string GetAllTextFromUserFile(string login, string pass);
    }
}
