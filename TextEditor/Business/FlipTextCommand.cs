using Editor.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Business
{
    public class FlipTextCommand : ICommand
    {
        private readonly ITextEditor _editor;
        private readonly string _text;

        public FlipTextCommand(ITextEditor editor, string text)
        {
            _editor = editor;
            _text = text;
        }
        public void Execute() 
        {
            _editor.FlipText();
        }
        public void Unexecute()
        {
            //TODO
            _editor.FlipText();
        }
    }
}
