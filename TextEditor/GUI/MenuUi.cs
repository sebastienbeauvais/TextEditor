using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Business.Interfaces;
using TextEditor.Business;

namespace TextEditor.GUI
{
    public class MenuUi
    {
        public void StartApp()
        {
            ITextEditor textEditor = new Business.TextEditor();
            var invoker = new CommandInvoker();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nText Editor");
                Console.WriteLine("1. Type");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Undo");
                Console.WriteLine("4. Redo");
                Console.WriteLine("5. View Text");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter text to write: ");
                        string text = Console.ReadLine();
                        var typeCommand = new TypeTextCommand(textEditor, text);
                        invoker.ExecuteCommand(typeCommand);
                        break;
                    case "2":
                        Console.WriteLine("Enter number of characters to delete: ");
                        if(int.TryParse(Console.ReadLine(), out int deleteLength))
                        {
                            var deleteCommand = new DeleteTextCommand(textEditor, deleteLength);
                            invoker.ExecuteCommand(deleteCommand);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case "3":
                        invoker.Undo();
                        break;
                    case "4":
                        invoker.Redo();
                        break;
                    case "5":
                        Console.WriteLine("Current text: \n" + textEditor.getText());
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
