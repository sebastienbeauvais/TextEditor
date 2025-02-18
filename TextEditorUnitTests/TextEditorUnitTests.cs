using Editor.Business.Interfaces;

namespace EditorUnitTests.TextEditor
{
    [TestClass]
    public class EditorUnitTests
    {
        [TestMethod]
        public void AppendText_ShouldAddTextWhenStringIsEmpty()
        {
            ITextEditor textEditor = new Editor.Business.TextEditor();

            string textToAppend = "Hello World";
            textEditor.AppendText(textToAppend);

            var result = textEditor.GetText();

            Assert.AreEqual(result, textToAppend);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void AppendText_ShouldAddTextWhenTextIsPresent()
        {
            ITextEditor editor = new Editor.Business.TextEditor();
            string firstTextToAppend = "Foo";
            string secondTextToAppend = "Bar";

            editor.AppendText(firstTextToAppend);
            editor.AppendText(secondTextToAppend);

            var result = editor.GetText();

            Assert.AreNotEqual(result, firstTextToAppend);
            Assert.AreNotEqual(result, secondTextToAppend);
            Assert.AreEqual(result, $"{firstTextToAppend}{secondTextToAppend}");
        }
        [TestMethod]
        public void RemoveText_ShouldRemoveTextWhenLengthIsValidForCharactersToRemove()
        {
            ITextEditor editor = new Editor.Business.TextEditor();

            string text = "Hello";
            editor.AppendText(text);

            int textToRemove = 2;
            editor.RemoveText(textToRemove);

            var result = editor.GetText();

            Assert.AreEqual(result.Length, text.Length-textToRemove);
            Assert.AreNotEqual(result.Length, text.Length);
        }
        [TestMethod]
        public void RemoveText_ShouldNotRemoveTextWhenLengthIsInvalidForCharactersToRemove()
        {
            ITextEditor editor = new Editor.Business.TextEditor();

            string text = "Hello";
            editor.AppendText(text);

            int textToRemove = 6;
            editor.RemoveText(textToRemove);

            var result = editor.GetText();

            Assert.AreNotEqual(result.Length, textToRemove);
            Assert.AreEqual(result, text);
        }
    }
}
