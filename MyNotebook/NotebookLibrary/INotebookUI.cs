using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookLibrary
{
    public interface INotebookUI
    {
        //Interaction with a user
        void StartDialogWithUser();

        // Creating a new account
        void SignUp();

        // Log in to already existed account
        void SignIn();

        //Receiving the list of all users that already exist in the system
        void GetAllRegisteredUsers();
    }
}
