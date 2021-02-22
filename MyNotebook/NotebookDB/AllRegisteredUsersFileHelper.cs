using NotebookLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NotebookDB
{
    public class AllRegisteredUsersFileHelper : AllRegisteredUsersHelper
    {
        public AllRegisteredUsersFileHelper()
        {
            base.AllRegisteredUsersList = LoadAllExistedUsers(base.AllRegisteredUsersList);
        }
        public override Dictionary<string, string> LoadAllExistedUsers(Dictionary<string, string> allRegisteredUsersList)
        {
            var userslist = new Dictionary<string, string>();
            var files = Directory.GetFiles(FileInfo.FolderDir);

            for (int i = 0; i < files.Length; i++)
            {
                var index = files[i].LastIndexOf('\\');
                var info = files[i].Substring(index + 1).Split(' ');
                userslist.Add( info[0], info[1].Substring(0, info[1].Length - 4));
            }
            return userslist;
        }

        public override void AddingNewUserToDB(string login, string pass)
        {
            var filename = login + " " + pass + ".txt";
            File.CreateText(FileInfo.FolderDir + filename);
        }

        public override void AddingTextToUserFile(string login, string pass, string text)
        {
            var filename = login + " " + pass + ".txt";
            File.AppendAllText(FileInfo.FolderDir + filename, text.Substring(0, text.Length - 5));
        }

        public override string GetAllTextFromUserFile(string login, string pass)
        {
            var filename = login + " " + pass + ".txt";
            return File.ReadAllText(FileInfo.FolderDir + filename);
        }
    }
}
