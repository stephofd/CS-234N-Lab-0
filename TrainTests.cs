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
    public class TrainTests
    {
        Train t;
        Train t1;
        Domino d55;
        Domino d1212;

        [SetUp]
        public void SetUpAllTests()
        {
            t = new Train();
            t1 = new Train();
            d1212 = new Domino(12, 12);
            t1.Add(d1212);
            d55 = new Domino(5, 5);
        }

        [Test]
        public void TestConstructor()
        {
            Train test = new Train();
            Assert.AreEqual(12, test.EngineValue);
        }

        [Test]
        public void TestOverloadedConstructor()
        {
            Train test = new Train(10);
            Assert.AreEqual(10, test.EngineValue);
        }

        [Test]
        public void TestCount()
        {
            Assert.AreEqual(0, t.Count);
            Assert.AreEqual(1, t1.Count);
        }

        [Test]
        public void TestEngineValue()
        {
            t.EngineValue = 10;
            Assert.AreEqual(10, t.EngineValue);
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.True(t.IsEmpty);
            Assert.False(t1.IsEmpty);
        }

        [Test]
        public void TestLastDomino()
        {
            Assert.AreEqual(12, t1.LastDomino.Side1);
        }

        [Test]
        public void TestLastDominoEmpty()
        {
            if (t.LastDomino == null)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void TestPlayableValue()
        {
            Assert.AreEqual(12, t.PlayableValue);
            Assert.AreEqual(12, t1.PlayableValue);
        }

        [Test]
        public void TestAdd()
        {
            t.Add(d55);
            Assert.AreEqual(5, t[0].Side1);
        }

        [Test]
        public void TestIsPlayable()
        {
            bool mustFlip;
            Assert.True(t1.IsPlayable(d1212, out mustFlip));
            Assert.False(t1.IsPlayable(d55, out mustFlip));
        }

        [Test]
        public void TestIsPlayableEmpty()
        {
            bool mustFlip;
            Assert.True(t.IsPlayable(d1212, out mustFlip));
            Assert.False(t1.IsPlayable(d55, out mustFlip));
        }

        [Test]
        public void TestPlay()
        {
            t1.Play(d1212);
            Assert.AreEqual(2, t1.Count);
        }

        [Test]
        public void TestPlayError()
        {
            try
            {
                t1.Play(d55);
                Assert.Fail("The Play method should throw an exception if domino cannot be played");
            }
            catch(Exception)
            {
                Assert.Pass("The Play method threw an exception for a domino that could not be played");
            }

            
        }

        [Test]
        public void TestToString()
        {
            string expected = "Side 1: 12  Side 2: 12\n";
            Assert.AreEqual(expected, t1.ToString());
        }
    }
}
