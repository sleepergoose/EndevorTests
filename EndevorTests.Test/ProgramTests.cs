using Microsoft.VisualStudio.TestTools.UnitTesting;
using EndevorTests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata.Ecma335;

namespace EndevorTests.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Add_Contains(int x)
        {
            
            UniLinkedList<int> llist = new EndevorTests.UniLinkedList<int>();

            llist.Add(x);
            bool result = llist.Contains(x);


            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remove()
        {
            // arrange
            UniLinkedList<int> llist = new UniLinkedList<int>();
            llist.Add(1);
            llist.Add(2);
            llist.Add(3);

            // act
            bool remove_result = llist.Remove(2);
            bool contains_result = llist.Contains(2);

            //assert
            Assert.IsTrue(remove_result);
            Assert.IsFalse(contains_result);
        }

        [TestMethod]
        public void AppendFirst()
        {
            // arrange 
            UniLinkedList<int> llist = new UniLinkedList<int>();
            llist.Add(1);
            llist.Add(2);
            llist.Add(3);

            // act
            bool init_head_res = llist.First.Data == 1;
            bool init_count_res = llist.Count == 3;

            llist.AppendFirst(5);
            bool count_res = llist.Count == 4;
            bool head_res = llist.First.Data == 5;

            // asserts
            Assert.IsTrue(init_head_res);
            Assert.IsTrue(init_count_res);
            Assert.IsTrue(count_res);
            Assert.IsTrue(head_res);
        }


        [TestMethod]
        public void AppendAfter()
        {
            // arrange 
            UniLinkedList<int> llist = new UniLinkedList<int>();
            llist.Add(1);
            llist.Add(2);
            llist.Add(3);

            bool app_result = llist.AppendAfter(8, 3);
            bool app_tail_res = llist.Last.Data == 8;

            llist.AppendAfter(12, 1);
            bool app_middle_res = llist.First.Next.Data == 12;

            // assert
            Assert.IsTrue(app_result);
            Assert.IsTrue(app_tail_res);
            Assert.IsTrue(app_middle_res);
        }

        [TestMethod]
        public void GetAllDataTest()
        {
            // arrange
            UniLinkedList<int> llist = new UniLinkedList<int>();
            llist.Add(1);
            llist.Add(2);
            llist.Add(3);
            int[] check = new int[] { 1, 2, 3 };
            bool result = true;

            // act
            var list = llist.GetAllData().ToArray();
            for (int i = 0, n = llist.Count - 1; i < n; i++)
            {
                if(list[i] != check[i])
                {
                    result = false;
                    break;
                }
            }

            //asserts
            Assert.IsTrue(result);
        }
    }
}