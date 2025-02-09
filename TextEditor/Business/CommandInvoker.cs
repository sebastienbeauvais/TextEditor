using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TextEditor.Business.Interfaces;

namespace TextEditor.Business
{
    public class CommandInvoker
    {
        private readonly Stack<ICommander> _undoStack = new();
        private readonly Stack<ICommander> _redoStack = new();

        public void ExecuteCommand(ICommander command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear(); // Clear redo stack after new command
        }
        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.Unexecute();
                _redoStack.Push(command);
            }
            else
            {
                Console.WriteLine("Nothing to undo.");
            }

        }
        public void Redo()
        {
            if(_redoStack.Count > 0)
            {
                var command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
            }
            else
            {
                Console.WriteLine("Nothing to redo.");
            }
        }
    }
}
