using NotebookDB;
using NotebookLibrary;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NotebookWPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AllRegisteredUsersHelper allRegisteredUsersList;
        public MainWindow()
        {
            InitializeComponent();
            allRegisteredUsersList = new AllRegisteredUsersFileHelper();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth = new Authorization(allRegisteredUsersList);

            string login = LoginTextBox.Text, pass = PasswordTextBox.Text;
            if (auth.ValidateRegisteredUser(login, pass))
            {
                NotebookTextBox.Text = DateTime.UtcNow.ToString();
                MessageBox.Show("Your authorization is successful !!!");
            }
            else
            {
                MessageBox.Show("Your authorization isn't successful !!! Please try to Log in again or create a new account.");
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text, pass = PasswordTextBox.Text;
            try
            {
                var newuser = new AddingNewUser(allRegisteredUsersList, login, pass);
                NotebookTextBox.Text = " ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text, pass = PasswordTextBox.Text;
            NotebookTextBox.Text = allRegisteredUsersList.GetAllTextFromUserFile(login, pass);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text, pass = PasswordTextBox.Text, notebooktext = NotebookTextBox.Text;
            allRegisteredUsersList.AddingTextToUserFile(login, pass, notebooktext + "\n");
            MessageBox.Show("Your data is saved successful to your notebook!!!");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
