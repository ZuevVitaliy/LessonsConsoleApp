using System;
using Infrastructure;
using LessonsConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FillArrayDiagonal_Test()
        {
            //assign
            int[,] testArray1 = new int[5, 5];
            int[,] testArray2 = new int[5, 10];
            int[,] testArray3 = new int[10, 5];

            //act
            Program.FillRectangleArray(testArray1);
            Program.FillRectangleArray(testArray2);
            Program.FillRectangleArray(testArray3);

            //assert
            Assert.IsTrue(TestArrayForFill(testArray1));
            Assert.IsTrue(TestArrayForFill(testArray2));
            Assert.IsTrue(TestArrayForFill(testArray3));
        }

        [TestMethod]
        public void FillArrayDiagonalObsolette_Test()
        {
            //assign
            int[,] testArray1 = new int[5, 5];
            int[,] testArray2 = new int[5, 10];
            int[,] testArray3 = new int[10, 5];

            //act
            Program.FillRectangleArray_Obsolette(testArray1);
            Program.FillRectangleArray_Obsolette(testArray2);
            Program.FillRectangleArray_Obsolette(testArray3);

            //assert
            Assert.IsTrue(TestArrayForFill(testArray1));
            Assert.IsTrue(TestArrayForFill(testArray2));
            Assert.IsTrue(TestArrayForFill(testArray3));
        }

        bool TestArrayForFill(int[,] array)
        {
            foreach (var el in array)
            {
                if (el == 0)
                    return false;
            }

            return true;
        }

        [TestMethod]
        public void TestFindingString()
        {
            string testSubS = "abra";

            string s1 = "abraabra";
            string s2 = "abra_abra";
            string s3 = "abrabra";
            string s4 = "abrabra_bra_abrara";
            string s5 = "ab";

            int orig = testSubS.FindSubstringsCount(testSubS);
            int r1 = s1.FindSubstringsCount(testSubS);
            int r2 = s2.FindSubstringsCount(testSubS);
            int r3 = s3.FindSubstringsCount(testSubS);
            int r4 = s4.FindSubstringsCount(testSubS);
            int r5 = s5.FindSubstringsCount(testSubS);

            Assert.IsTrue(orig == 1);
            Assert.IsTrue(r1 == 2);
            Assert.IsTrue(r2 == 2);
            Assert.IsTrue(r3 == 1);
            Assert.IsTrue(r4 == 2);
            Assert.IsTrue(r5 == 0);
        }
    }
}
