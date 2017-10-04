using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDUnitTests
{
    [TestFixture]
    public class BoneYardTests
    {
        
        BoneYard by;
        BoneYard by0;

        [SetUp]
        public void SetUpAllTests()
        {
            by = new BoneYard(12);
            by0 = new BoneYard(0);
        }
        

        [Test]
        public void TestConstructor()
        {
            BoneYard test = new BoneYard(12);
            Assert.AreEqual(0, test[0].Side1);
            Assert.AreEqual(12, test[168].Side2);
        }

        [Test]
        public void TestShuffle()
        {
            int unshuffled = 0;
            int currentIndex = 0;
            by.Shuffle();

            for (int s1 = 0; s1 < 12; s1++)
            {
                for (int s2 = 0; s2 < 12; s2++)
                {
                    if (by[currentIndex].Side1 == s1 && by[currentIndex].Side2 == s2)
                    {
                        unshuffled++;
                    }
                    currentIndex++;

                }
            }

            Assert.Greater(10, unshuffled);
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.IsFalse(by0.IsEmpty());
            by0.Draw();
            Assert.IsTrue(by0.IsEmpty());
        }

        [Test]
        public void TestDominosRemaining()
        {
            Assert.AreEqual(169, by.DominosRemaining);
        }

        [Test]
        public void TestDraw()
        {
            Domino drawn = by0.Draw();
            Assert.AreEqual(0, drawn.Side1);
            Assert.AreEqual(0, drawn.Side2);

        }

        [Test]
        public void TestToString()
        {
            string expected = "Side 1: 0  Side 2: 0\n";
            Assert.AreEqual(expected, by0.ToString());
            Assert.Greater(by.ToString().Length, 22);
        }
    }
}
