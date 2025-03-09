using Editor.Business.Interfaces;


namespace Editor.Business
{
    public class DeleteTextCommand : ICommand
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
            var currentText = _editor.GetText();
            if (LengthToDelete <= currentText.Length)
            {
                _deleteText = currentText.Substring(currentText.Length - LengthToDelete);
                _editor.RemoveText(LengthToDelete);
            }
        }
        public void Unexecute()
        {
            _editor.AppendText(_deleteText);
        }
    }
}
