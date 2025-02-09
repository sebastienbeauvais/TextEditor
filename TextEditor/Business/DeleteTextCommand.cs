using TextEditor.Business.Interfaces;


namespace TextEditor.Business
{
    public class DeleteTextCommand : ICommander
    {
        private readonly ITextEditor _editor;
        private string _deleteText = string.Empty;

        public DeleteTextCommand(ITextEditor editor, int length)
        {
            _editor = editor;
            LengthToDelete = length;
        }
        public int LengthToDelete { get; }
        public void Execute()
        {
            var currentText = _editor.getText();
            if (LengthToDelete <= currentText.Length)
            {
                _deleteText = currentText.Substring(currentText.Length - LengthToDelete);
                _editor.removeText(LengthToDelete);
            }
        }
        public void Unexecute()
        {
            _editor.AppendText(_deleteText);
        }
    }
}
