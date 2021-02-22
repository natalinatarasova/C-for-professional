using NotebookDB;
using NotebookLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookConsoleUI
{
    public sealed class NoteBookConsole : INotebookUI
    {
        AllRegisteredUsersHelper allRegisteredUsersList = new AllRegisteredUsersFileHelper();

        public void StartDialogWithUser()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string('=', 120));
                Console.WriteLine("Sign in or Sign up:" +
                                  "\n\nSign in - Press '1' if you are already registered" +
                                  "\nSign up - Press '2' if you want to register a new account"+
                                  "\nData - Press '3' if you want to load the full list of already registered users");
                Console.ForegroundColor = ConsoleColor.White;

                var s = Console.ReadKey().Key;
                switch (s)
                {
                    case ConsoleKey.D1:
                        SignIn();
                        break;

                    case ConsoleKey.D2:
                        SignUp();
                        break;

                    case ConsoleKey.D3:
                        GetAllRegisteredUsers();
                        break;

                    default:
                        break;

                }
            } 
        }

        public void GetAllRegisteredUsers()
        {
            Console.WriteLine("\n\nThe Notebook already contains the following list of registered users:\n");
            foreach (var user in allRegisteredUsersList.AllRegisteredUsersList)
            {
                Console.WriteLine("User login: {0}, User password: {1}", user.Key, user.Value);
            }
            Console.WriteLine("\n");
        }

        public void SignIn()
        {
            string login, pass;
            EnterLoginInfo(out login, out pass);

            Authorization auth = new Authorization(allRegisteredUsersList);
            if (auth.ValidateRegisteredUser(login, pass))
            {
                Console.WriteLine("\nYour authorization is successful !!!\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter your today's notes to your 'Electronic Notebook' row by row\n"+
                                  "Press 'quit' when you finish your writting\n"+
                                  "Press 'data' to see the content of your notebook\n");
                Console.ForegroundColor = ConsoleColor.White;

                string notebooktext = "\n" + DateTime.UtcNow;
                Console.WriteLine(notebooktext);

                while (true)
                {
                    notebooktext += "\n" + Console.ReadLine();
                    if (notebooktext.Contains("quit"))
                    {
                        allRegisteredUsersList.AddingTextToUserFile(login, pass, notebooktext+"\n");
                        break;
                    }
                    if (notebooktext.Contains("data"))
                    {
                        allRegisteredUsersList.AddingTextToUserFile(login, pass, notebooktext+"\n");
                        Console.WriteLine("\nData from your notebook:");
                        Console.WriteLine(GetTextFromUserNotebook(login, pass) + "\n");
                        break;
                    }
                } 
            }
            else
            {
                Console.WriteLine("\nYour authorization isn't successful !!! Please try to Log in again or create a new account.");
            }
        }

        public void SignUp()
        {
            string login, pass;
            EnterLoginInfo(out login, out pass);
            try
            {
                var newuser = new AddingNewUser(allRegisteredUsersList, login, pass);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EnterLoginInfo(out string login, out string pass)
        {
            Console.WriteLine("\n\nPlease enter your login:");
            login = Console.ReadLine();

            Console.WriteLine("\nPlease enter your password:");
            pass = Console.ReadLine();
        }

        private string GetTextFromUserNotebook(string login, string pass)
        {
            return allRegisteredUsersList.GetAllTextFromUserFile(login, pass);
        }

        
}
}
