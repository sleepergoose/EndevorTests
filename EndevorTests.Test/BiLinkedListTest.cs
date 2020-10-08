using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EndevorTests.Test
{
    [TestClass]
    public class BiLinkedListTest
    {
        [TestMethod]
        public void Add_5_5()
        {
            // arrange
            BiLinkedList<int> llist = new BiLinkedList<int>();

            // act
            for (int i = 0; i < 5; i++)
            {
                llist.Add(i);
            }
            llist.Add(5);
            var node = llist.Get(5);
            int actual = node.Data;
            int expected = 5;

            // assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Add_5_PreviousIs4()
        {
            // arrange
            BiLinkedList<int> llist = new BiLinkedList<int>();

            // act
            for (int i = 0; i < 5; i++)
            {
                llist.Add(i);
            }
            llist.Add(5);
            var node = llist.Get(5);
            int actual = node.Previous.Data;
            int expected = 4;

            // assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Add_5_NextIsNull()
        {
            // arrange
            BiLinkedList<int> llist = new BiLinkedList<int>();

            // act
            for (int i = 0; i < 5; i++)
            {
                llist.Add(i);
            }
            llist.Add(5);
            var node = llist.Get(5);
            int? actual = node.Next?.Data;
            int? expected = null;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_5_NextFor4Is5()
        {
            // arrange
            BiLinkedList<int> llist = new BiLinkedList<int>();

            // act
            for (int i = 0; i < 5; i++)
            {
                llist.Add(i);
            }
            llist.Add(5);
            var node = llist.Get(4);
            int actual = node.Next.Data;
            int expected = 5;

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

/* 
 
Имя теста должно состоять из трех частей:
    имя тестируемого метода;
    сценарий, в котором выполняется тестирование;
    ожидаемое поведение при вызове сценария.
 
 */