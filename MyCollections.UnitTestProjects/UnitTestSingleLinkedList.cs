using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections.Lib;

namespace MyCollections.UnitTestProjects
{
    [TestClass]
    public class UnitTestSingleLinkedList
    {
        [TestMethod]
        public void MySLListCtorValueTest()
        {
            MySLList<int> list = new MySLList<int>();
            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(list.IsReadOnly);
        }

        [TestMethod]
        public void MySLListCtorReferenceTest()
        {
            MySLList<string> listA = new MySLList<string>();
            Assert.IsNotNull(listA);
            Assert.AreEqual(0, listA.Count);
            Assert.IsFalse(listA.IsReadOnly);
        }

        [TestMethod]
        public void MySLListAddTest()
        {
            MySLList<int> list = new MySLList<int>();
            Assert.AreEqual(0, list.Count);
            list.Add(100);
            Assert.AreEqual(1, list.Count);
            for (int i = 0; i < 10000; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(10001, list.Count);
        }

        [TestMethod]
        public void MySLListTest()
        {
            MySLList<int> list = new MySLList<int>();
            Assert.AreEqual(0, list.Count);
            list.Add(100);
            Assert.AreEqual(1, list.Count);
            for (int i = 0; i < 10000; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(10001, list.Count);
        }

        [TestMethod]
        public void MySLListItemTest_Get()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);
            for (int i = 0; i < mas.Length; ++i)
                Assert.AreEqual(mas[i], list[i]);
        }

        [TestMethod]
        public void MySLListItemTest_Set()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);
            list[0] = 101;
            list[5] = 106;
            list[9] = 110;
            Assert.AreEqual(101, list[0]);
            Assert.AreEqual(106, list[5]);
            Assert.AreEqual(110, list[9]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MySLListItemTest_GetException1()
        {
            MySLList<int> list = new MySLList<int>();
            Assert.AreEqual(10, list[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MySLListItemTest_GetException2()
        {
            MySLList<int> list = new MySLList<int>();
            Assert.AreEqual(10, list[-1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MySLListItemTest_SetException1()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);
            list[10] = 100;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MySLListItemTest_SetException2()
        {
            MySLList<int> list = new MySLList<int>();
            list[0] = 100;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MySLListItemTest_SetException3()
        {
            MySLList<int> list = new MySLList<int>();
            list[-1] = 100;
        }

        [TestMethod]
        public void MySLListClearTest()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);
            Assert.AreEqual(10, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void MySLListContainsTest()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);

            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(6));
            Assert.IsTrue(list.Contains(10));

            Assert.IsFalse(list.Contains(-1));
            Assert.IsFalse(list.Contains(25));
            Assert.IsFalse(list.Contains(Int32.MaxValue));
            Assert.IsFalse(list.Contains(Int32.MinValue));
        }

        [TestMethod]
        public void MySLListEnumeratorTest()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);
            int index = 0;
            foreach (int x in list)
            {
                Assert.AreEqual(mas[index++], x);
            }
        }

        [TestMethod]
        public void MySLListCopyToTest()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);
            int[] arr = new int[list.Count];
            list.CopyTo(arr, 0);

            for (int i = 0; i < mas.Length; ++i)
            {
                Assert.AreEqual(mas[i], arr[i]);
            }
        }

        [TestMethod]
        public void MySLListIndexOfTest()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);

            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(9, list.IndexOf(10));
            Assert.AreEqual(4, list.IndexOf(5));
            Assert.AreEqual(-1, list.IndexOf(0));
            Assert.AreEqual(-1, list.IndexOf(100));
            Assert.AreEqual(-1, list.IndexOf(Int32.MaxValue));
            Assert.AreEqual(-1, list.IndexOf(Int32.MinValue));
        }

        [TestMethod]
        public void MySLListRemoveAtTest()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);

            list.RemoveAt(0);
            Assert.AreEqual(9, list.Count);
            Assert.AreEqual(2, list[0]);

            list.RemoveAt(8);
            Assert.AreEqual(8, list.Count);
            Assert.AreEqual(9, list[7]);
        }

        [TestMethod]
        public void MySLListRemoveTest()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);

            list.Remove(0);
            Assert.AreEqual(10, list.Count);

            list.Remove(10);
            Assert.AreEqual(9, list.Count);
            Assert.AreEqual(9, list[8]);

            list.Remove(1);
            Assert.AreEqual(8, list.Count);
            Assert.AreEqual(2, list[0]);

            list.Remove(5);
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual(6, list[3]);
        }

        [TestMethod]
        public void MySLListInsertTest()
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySLList<int> list = new MySLList<int>(mas);

            list.Insert(0, 100);
            Assert.AreEqual(11, list.Count);
            Assert.AreEqual(100, list[0]);
            Assert.AreEqual(1, list[1]);

            list.Insert(10, 1000);
            Assert.AreEqual(12, list.Count);
            Assert.AreEqual(1000, list[10]);
            Assert.AreEqual(10, list[11]);
        }
    }
}
