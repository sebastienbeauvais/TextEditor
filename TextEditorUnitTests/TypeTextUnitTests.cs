using Editor.Business;
using Editor.Business.Interfaces;
using Moq;

namespace EditorUnitTests.TypeText
{
    [TestClass]
    public class TypeTextUnitTests
    {
        
        [TestMethod]
        public void Execute_ShouldAppendTextToEditor()
        {
            var text = "Hello World";
            var editorMock = new Mock<ITextEditor>();
            var command = new TypeTextCommand(editorMock.Object, text);

            command.Execute();

            editorMock.Verify(x => x.AppendText("Hello World"), Times.Once);
        }
    }
}
