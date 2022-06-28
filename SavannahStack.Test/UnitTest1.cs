using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SavannahStack.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StackIsEmptyOnInitialization()
        {
            var testStack = new Stack_S();
            Assert.IsTrue(testStack.IsEmpty());
        }

        [TestMethod]
        public void StackIsNotEmptyAfterAddingElement()
        {
            var testStack = new Stack_S();
            testStack.Push("Item 1");
            Assert.IsFalse(testStack.IsEmpty());
        }

        [TestMethod]
        public void StackReturnsNumberofElementsInStack()
        {
            var testStack = new Stack_S();
            testStack.Push("Item 1");
            testStack.Push("Item 2");
            Assert.AreEqual(testStack.GetTotalCount(), 2);
        }

        [TestMethod]
        public void StackFindsElement()
        {
            var testStack = new Stack_S();
            testStack.Push("Hello");
            Assert.IsTrue(testStack.Contains("Hello"));
        }

        [TestMethod]
        public void StackDoesntFindNoneExistentElement()
        {
            var testStack = new Stack_S();
            Assert.IsFalse(testStack.Contains("Hello"));
        }

        [TestMethod]
        public void StackIsEmptyAfterClearing()
        {
            var testStack = new Stack_S();
            testStack.Push("One");
            testStack.Push("Two");
            testStack.Clear();

            Assert.IsTrue(testStack.IsEmpty());
        }

        [TestMethod]
        public void StackCanAddMultipleItems()
        {
            var testStack = new Stack_S();
            testStack.Push(new string[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" });

            Assert.AreEqual(testStack.GetTotalCount(), 5);
        }

        [TestMethod]
        public void StackReturnsRecentItemAfterPop()
        {
            var testStack = new Stack_S();
            testStack.Push("One");
            testStack.Push("Two");
            var item = testStack.Pop();
            Assert.AreEqual(item, "Two");
        }

        [TestMethod]
        public void StackReturnsRecentItemAfterMultipleAddAndPop()
        {
            var testStack = new Stack_S();
            testStack.Push(new string[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" });
            var item = testStack.Pop();
            Assert.AreEqual(item, "Item 5");
        }

        [TestMethod]
        public void StackContainsFewerItemsAfterPop()
        {
            var testStack = new Stack_S();
            testStack.Push(new string[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" });
            var item = testStack.Pop();
            Assert.AreEqual(testStack.GetTotalCount(), 4);
        }

        [TestMethod]
        public void StackReturnsRecentItemAfterPeek()
        {
            var testStack = new Stack_S();
            testStack.Push("A");
            testStack.Push("B");
            var item = testStack.Peek();
            Assert.AreEqual(item, "B");
        }

        [TestMethod]
        public void StackSizeDoesntChangeAfterPeek()
        {
            var testStack = new Stack_S();
            testStack.Push("A");
            testStack.Push("B");
            var item = testStack.Peek();
            Assert.AreEqual(testStack.GetTotalCount(), 2);
        }
    }
}