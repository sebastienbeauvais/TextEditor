﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Business.Interfaces;
using Editor.Business;

namespace Editor.GUI
{
    public class MenuUi
    {
        public void StartApp()
        {
            ITextEditor textEditor = new TextEditor();
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
                Console.WriteLine("6. Flip Text");
                Console.WriteLine("99. Exit");

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
                        Console.WriteLine("Current text: \n" + textEditor.GetText());
                        break;
                    case "6":
                        Console.WriteLine("Text before flipping: " + textEditor.GetText());
                        var flipCommand = new FlipTextCommand(textEditor, textEditor.GetText());
                        invoker.ExecuteCommand(flipCommand);
                        Console.WriteLine("Flipped text: " + textEditor.GetText());
                        break;
                    case "99":
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
