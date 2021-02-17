using HW_008_Serialization_1.DBLayer;
using System;
using System.IO;

namespace HW_008_Serialization_1.PresentationLayer
{
    class Interface
    {
        private static string dir = @"C:\Users\natal\Documents\C#CourseProfessional\008_Serialization_02012021\HW-008-Serialization\HW-008-Serialization-1\Notebook\";

        public static string Directory
        {
            get { return dir; }
        }

        private static void EnterLoginInfo(out string login, out string pass)
        {
            Console.WriteLine("Please enter your login:");
            login = Console.ReadLine();

            Console.WriteLine("\nPlease enter your password:");
            pass = Console.ReadLine();
        }

        public static void InteractionWithUser()
        {
            string login, pass, filename, s, notebooktext = " ";

            Registration listofusers = new Registration();
            foreach (var user in (new RegisterUsers()).ExistedUsers)
            {
                listofusers.Add(user);
            }

            Authorization auth = new Authorization(listofusers);

            while (true)
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine("\nLog in or Registration:" +
                                  "\n\nPress '1' if you are already registered" +
                                  "\nPress '2' if you want to register" +
                                  "\nPrint 'data' and press Enter to get the list of existing users\n");

                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        EnterLoginInfo(out login, out pass);

                        if (auth.ValidateAuthorization(login, pass, out DateTime date))
                        {
                            Console.WriteLine("\nYour authorization is successful !!!");
                            Console.WriteLine("Please enter your today's notes to your 'Electronic Notebook' row by row (Press 'quit' when you finish your writting)\n");
                            
                            Console.WriteLine("\n\nThe current date is {0}", date);
                            notebooktext += "\nThe current date is " + date;
                            while (true)
                            {
                                notebooktext += "\n" + Console.ReadLine();
                                if (notebooktext.Contains("quit"))
                                {
                                    filename = login + " " + pass + ".txt";
                                    File.AppendAllText(Directory + filename, notebooktext.Substring(0, notebooktext.Length - 5));
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nYour authorization isn't successful !!! Please try to Log in again or create a new account.");
                        }

                        break;

                    case "2":
                        EnterLoginInfo(out login, out pass);
                        listofusers.Add(new Users(login, pass));

                        filename = login + " " + pass + ".txt";
                        File.CreateText(Directory + filename);
                        break;

                    case "data":
                        Console.WriteLine("\n\nList of Users:");
                        foreach (Users user in listofusers)
                        {
                            Console.WriteLine("Login: " + user.Login + " Password: " + user.Password);
                        }
                        Console.WriteLine("\n");
                        break;

                    case " ":
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
