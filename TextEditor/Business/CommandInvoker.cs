using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Editor.Business.Interfaces;

namespace Editor.Business
{
    public class CommandInvoker
    {
        private readonly Stack<Interfaces.ICommand> _undoStack = new();
        private readonly Stack<Interfaces.ICommand> _redoStack = new();

        public void ExecuteCommand(Interfaces.ICommand command)
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
                command.Execute();
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
