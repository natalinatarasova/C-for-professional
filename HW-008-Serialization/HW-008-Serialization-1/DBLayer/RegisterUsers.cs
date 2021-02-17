using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HW_008_Serialization_1.DBLayer
{
    public class RegisterUsers
    {
        private List<Users> existedusers = new List<Users>();

        public RegisterUsers()
        {
            LoadAllExistedUsers();
        }

        public List<Users> ExistedUsers
        {
            get { return existedusers; }
        }
        private void LoadAllExistedUsers()
        {
            var dir = @"C:\Users\natal\Documents\C#CourseProfessional\008_Serialization_02012021\HW-008-Serialization\HW-008-Serialization-1\Notebook";
            var files = Directory.GetFiles(dir);

            for (int i = 0; i < files.Length; i++)
            {
                var index = files[i].LastIndexOf('\\'); 
                var info = files[i].Substring(index+1).Split(' ');
                existedusers.Add(new Users(info[0], info[1].Substring(0, info[1].Length-4)));
            }
        }
    }
}
