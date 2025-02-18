using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Business.Interfaces
{
    public interface ITextEditor
    {
        public void AppendText(string text);
        public void removeText(int length);
        public string getText();
    }
}
