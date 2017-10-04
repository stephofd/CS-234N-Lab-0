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

        [SetUp]
        public void SetUpAllTests()
        {
            t = new Train();
            t1 = new Train();
            t1.Add(new Domino(12, 12));
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


    }
}
