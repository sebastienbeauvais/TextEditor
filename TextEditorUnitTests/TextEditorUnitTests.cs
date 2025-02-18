using Editor.Business.Interfaces;

namespace EditorUnitTests.TextEditor
{
    [TestClass]
    public sealed class EditorUnitTests
    {
        [TestMethod]
        public void AppendText_WhenStringIsEmpty()
        {
            string text = string.Empty;
            ITextEditor textEditor = new Editor.Business.TextEditor();

        }
    }
}
