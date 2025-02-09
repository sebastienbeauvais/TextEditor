using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.GUI
{
    public class TextEditor
    {
        private string _text = string.Empty;
        private readonly Stack<string> _undoStack = new Stack<string>();
        private readonly Stack<string> _redoStack = new Stack<string>();

        public void StartApp()
        {
            var textEditor = new TextEditor();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nText Editor");
                Console.WriteLine("1. Write Text");
                Console.WriteLine("2. Undo");
                Console.WriteLine("3. Redo");
                Console.WriteLine("4. View Text");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter text to write: ");
                        string newText = Console.ReadLine();
                        textEditor.WriteText(newText);
                        break;
                    case "2":
                        textEditor.Undo();
                        break;
                    case "3":
                        textEditor.Redo();
                        break;
                    case "4":
                        Console.WriteLine("Current Text: " + textEditor.GetText());
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        public void WriteText(string text)
        {
            _undoStack.Push(_text);
            _redoStack.Clear(); // Clear redo stack since we've made a new change
            _text += text;
            Console.WriteLine("Text added.");
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                _redoStack.Push(_text);
                _text = _undoStack.Pop();
                Console.WriteLine("Undo successful.");
            }
            else
            {
                Console.WriteLine("Nothing to undo.");
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push(_text);
                _text = _redoStack.Pop();
                Console.WriteLine("Redo successful.");
            }
            else
            {
                Console.WriteLine("Nothing to redo.");
            }
        }

        public string GetText()
        {
            return _text;
        }
    }

}

