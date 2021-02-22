using NotebookLibrary;
using System;

namespace NotebookConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            INotebookUI notebook = new NoteBookConsole();
            notebook.StartDialogWithUser();
        }
    }
}
