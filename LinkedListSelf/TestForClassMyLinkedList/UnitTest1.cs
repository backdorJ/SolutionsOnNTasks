using LinkedListSelf;
using System.Xml.Linq;

namespace TestForClassMyLinkedList
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase(1,5)]
        public void TestAddElementAfter(int k, int element)
        {
            var list = new MyLinkedlist<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddElementAfter(element,k);
            var actually = list;


            var list2 = new MyLinkedlist<int>();
            list2.AddLast(1);
            list2.AddLast(2);
            list2.AddLast(element);
            list2.AddLast(3);
            var except = list2;
            Assert.AreEqual(except.ToString(), actually.ToString());
        }

        [TestCase(2, 1000)]
        public void TestAddElementAfter2(int k, int element)
        {
            var list = new MyLinkedlist<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddElementAfter(element, k);
            var actually = list;


            var list2 = new MyLinkedlist<int>();
            list2.AddLast(1);
            list2.AddLast(2);
            list2.AddLast(3);
            list2.AddLast(element);
            var except = list2;

            Assert.AreEqual(except.ToString(), actually.ToString());
        }

        [TestCase(0)]
        public void TestDeleteKElement(int k)
        {
            var list = new MyLinkedlist<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.DeleteK(k);
            var actually = list;


            var list2 = new MyLinkedlist<int>();
            list2.AddLast(2);
            list2.AddLast(3);
            var except = list2;

            Assert.AreEqual(except.ToString(), actually.ToString());
        }
    }
}