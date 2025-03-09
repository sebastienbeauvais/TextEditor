using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Business.Interfaces;


namespace Editor.Business
{
    public class TypeTextCommand : ICommand
    {
        private readonly ITextEditor _editor;
        private readonly string _textToType;

        public TypeTextCommand(ITextEditor editor, string text)
        {
            _editor = editor;
            _textToType = text;
        }
        public void Execute()
        {
            _editor.AppendText(_textToType);
        }
        public void Unexecute()
        {
            _editor.RemoveText(_textToType.Length);
        }
    }
}
