﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDUnitTests
{
    [TestFixture]
    public class DominoTests
    {
        Domino def;
        Domino d12;
        Domino d21;
        Domino d33;

        [SetUp]
        public void SetUpAllTests()
        {
            def = new Domino();
            d12 = new Domino(1, 2);
            d21 = new Domino(2, 1);
            d33 = new Domino(3, 3);
        }

        [Test]
        public void Test1()
        {
            int answer = 1 + 2;
            Assert.AreEqual(3, answer);
        }

        [Test]
        public void TestOverloadedConstructor()
        {
            //Domino d = new Domino(1, 2);
            Assert.AreEqual(1, d12.Side1);
            Assert.AreEqual(2, d12.Side2);
        }

        [Test]
        public void TestGetters()
        {
            Domino d = new Domino(1, 2);
            Assert.AreEqual(1, d.Side1);
            Assert.AreEqual(2, d.Side2);
        }

        [Test]
        public void TestSettersValid()
        {
            Domino d = new Domino(3, 2);
            Assert.AreEqual(3, d.Side1);
            Assert.AreEqual(2, d.Side2);
            d.Side1 = 1;
            d.Side2 = 12;
            Assert.AreEqual(1, d.Side1);
            Assert.AreEqual(12, d.Side2);
        }

        [Test]
        public void TestSettersInValidTry()
        {
            Domino d = new Domino();
            try
            {
                d.Side1 = -1;
                Assert.Fail("The setter should throw an exception for negative values.");
            }
            catch (ArgumentException)
            {
                Assert.Pass("The setter threw an exception for a negative value as expected");
            }
            try
            {
                d.Side1 = 15;
                Assert.Fail("The setter should throw an exception for a value > 13.");
            }
            catch (ArgumentException)
            {
                Assert.Pass("The setter threw an exception for a value of 15 as expected");
            }
            Assert.AreEqual(0, d.Side1);
            Assert.AreEqual(0, d.Side2);
        }

        [Test]
        public void TestSettersInValidAssertThrows()
        {
            Domino d = new Domino();
            Assert.Throws<ArgumentException>(() => d.Side1 = -1);
            Assert.Throws<ArgumentException>(() => d.Side1 = 15);
            Assert.AreEqual(0, d.Side1);
            Assert.AreEqual(0, d.Side2);
        }

        [Test]
        public void TestFlip()
        {
            d12.Flip();
            Assert.AreEqual(2, d12.Side1);
            Assert.AreEqual(1, d12.Side2);
        }

        [Test]
        public void TestScore()
        {
            Assert.AreEqual(3, d12.Score);
            Assert.AreEqual(6, d33.Score);
        }

        [Test]
        public void TestIsDouble()
        {
            Assert.True(d33.IsDouble());
            Assert.False(d12.IsDouble());
        }

        [Test]
        public void TestEquals()
        {
            Domino duplicate12 = new Domino(1, 2);
            Assert.True(d12.Equals(duplicate12));
            Assert.False(d12.Equals(d21));
        }
    }
}
