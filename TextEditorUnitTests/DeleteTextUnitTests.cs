using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Editor.Business;
using Editor.Business.Interfaces;

using Moq;

namespace EditorUnitTests.DeleteText
{
    [TestClass]
    public class DeleteTextUnitTests
    {
        [TestMethod]
        public void DeleteText_ShouldDeleteLastWord()
        {
            var text = "Hello World";
            var editorMock = new Mock<ITextEditor>();
            var mockTypeTextCommand = new Mock<TypeTextCommand>(editorMock.Object, text);

            ICommand commander = new DeleteTextCommand(editorMock.Object, text.Length);

            editorMock.Setup(x => x.GetText()).Returns(text);
            commander.Execute();

            editorMock.Verify(x => x.RemoveText(text.Length), Times.Once);
        }
        [TestMethod]
        public void DeleteText_ShouldNotDeleteLastWordIfLengthGreaterThanWord()
        {
            var text = "Hello World";
            var editorMock = new Mock<ITextEditor>();
            var mockTypeTextCommand = new Mock<TypeTextCommand>(editorMock.Object, text);

            ICommand commander = new DeleteTextCommand(editorMock.Object, text.Length);

            editorMock.Setup(x => x.GetText()).Returns(text);
            commander.Execute();

            editorMock.Verify(x => x.RemoveText(text.Length+1), Times.Never);
        }
        /*[TestMethod]
        public void DeleteText_ShouldRedoLastWord()
        {
            var text = "Hello World";
            var editorMock = new Mock<ITextEditor>();
            var mockTypeTextCommand = new Mock<TypeTextCommand>(editorMock.Object, text);

            ICommand commander = new DeleteTextCommand(editorMock.Object, text.Length);

            editorMock.Setup(x => x.GetText()).Returns(text);
            commander.Execute();
            commander.Unexecute();

            editorMock.Verify(x => x.AppendText(text), Times.Once);
        }*/
    }
}
