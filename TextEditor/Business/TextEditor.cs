using Editor.Business.Interfaces;

namespace Editor.Business
{
    public class TextEditor : ITextEditor
    {
        private string _text = string.Empty;

        public void AppendText(string text)
        {
            _text += text;
        }
        public void removeText(int length)
        {
            if (length <= _text.Length)
            {
                _text = _text.Substring(0, _text.Length - length);
            }
        }
        public string getText()
        {
            return _text;
        }
    }

}

