using System;
using System.Collections.Generic;
using MyCollections.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCollections.UnitTestProjects
{
    [TestClass]
    public class ListArrayUnitTest
    {
        [TestMethod]
        public void CtorTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>();
            Assert.IsNotNull(list);
            Assert.IsFalse(list.IsReadOnly);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Ctor_2_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(100);
            Assert.IsNotNull(list);
            Assert.IsFalse(list.IsReadOnly);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void AddAndCountTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            Assert.AreEqual(0, list.Count);
            list.Add(100);
            Assert.AreEqual(1, list.Count);
            list.Add(101);
            Assert.AreEqual(2, list.Count);
            list.Add(102);
            Assert.AreEqual(3, list.Count);
            list.Add(103);
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void IndexTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list.Add(100);
            list.Add(101);
            list.Add(102);
            list.Add(103);
            Assert.AreEqual(100, list[0]);
            Assert.AreEqual(101, list[1]);
            Assert.AreEqual(102, list[2]);
            Assert.AreEqual(103, list[3]);
            list[0] = 0;
            Assert.AreEqual(0, list[0]);
            list[1] = 1;
            Assert.AreEqual(1, list[1]);
            list[2] = 2;
            Assert.AreEqual(2, list[2]);
            list[3] = 3;
            Assert.AreEqual(3, list[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_get0_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            int x = list[1];

        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_get1_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            int x = list[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_set0_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list[1] = 1;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_set1_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list[-1] = 10;
        }

        [TestMethod]
        public void ClearTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(1);
            list.Add(100);
            list.Add(101);
            Assert.AreEqual(list.Count, 2);
            list.Clear();
            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void ContainsTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list.Add(100);
            list.Add(101);
            list.Add(102);
            Assert.AreEqual(list.Contains(101), true);
            Assert.AreEqual(list.Contains(102), true);
            Assert.AreEqual(list.Contains(100), true);
            Assert.AreEqual(list.Contains(1), false);
        }

        [TestMethod]
        public void IEnumerableTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(100);
            var e = list.GetEnumerator();
            Assert.IsFalse(e.MoveNext());
            e.Reset();
            int[] mas = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int val in mas)
            {
                list.Add(val);
            }
            int count = 0;
            using (IEnumerator<int> le = list.GetEnumerator())
            {
                while (le.MoveNext())
                    Assert.AreEqual(le.Current, mas[count++]);
            }
        }

        [TestMethod]
        public void CopyToTestMethod()
        {
            int[] array = new int[5] { 9, 8, 7, 6, 5 };
            MyListArray<int> list = new MyListArray<int>(3);
            list.Add(100);
            list.Add(101);
            list.Add(102);
            list.CopyTo(array, 2);
            Assert.AreEqual(9, array[0]);
            Assert.AreEqual(8, array[1]);
            Assert.AreEqual(list[0], array[2]);
            Assert.AreEqual(list[1], array[3]);
            Assert.AreEqual(list[2], array[4]);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CopyToNullTestMethod()
        {
            int[] array = null;
            MyListArray<int> list = new MyListArray<int>(1);
            list.Add(100);
            list.CopyTo(array, 2);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CopyToOutOfRangeTestMethod()
        {
            int[] array = new int[5];
            MyListArray<int> list = new MyListArray<int>(2);
            list.Add(100);
            list.Add(101);
            list.CopyTo(array, -1);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CopyToArgExeptionTestMethod()
        {
            int[] array = new int[5];
            MyListArray<int> list = new MyListArray<int>(2);
            list.Add(100);
            list.Add(101);
            list.CopyTo(array, 4);
        }

        [TestMethod]
        public void IndexOfTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list.Add(100);
            list.Add(101);
            Assert.AreEqual(list.IndexOf(100), 0);
            Assert.AreEqual(list.IndexOf(101), 1);
            Assert.AreEqual(list.IndexOf(102), -1);
        }

        [TestMethod]
        public void InsertTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list.Add(100);
            list.Add(101);
            list.Insert(2, 7);
            list.Insert(1, 6);
            list.Insert(0, 5);
            Assert.AreEqual(list[0], 5);
            Assert.AreEqual(list[1], 100);
            Assert.AreEqual(list[2], 6);
            Assert.AreEqual(list[3], 101);
            Assert.AreEqual(list[4], 7);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void InsertOutOfRangeTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list.Add(100);
            list.Add(101);
            list.Insert(3, 4);
        }

        [TestMethod]
        public void RemoveTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(3);
            list.Add(100);
            list.Add(101);
            list.Add(103);
            Assert.AreEqual(list.Remove(100), true);
            Assert.AreEqual(list.Remove(103), true);
            Assert.AreEqual(list.Remove(102), false);
        }

        [TestMethod]
        public void RemoveAtTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(3);
            list.Add(100);
            list.Add(101);
            list.Add(103);
            Assert.AreEqual(list.Remove(100), true);
            Assert.AreEqual(list.Remove(103), true);
            Assert.AreEqual(list.Remove(102), false);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void RemoveAtOutOfRangeTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list.Add(100);
            list.Add(101);
            list.RemoveAt(2);
        }
    }
}
