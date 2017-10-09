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
    public class PrivateTrainTests
    {
        
        Hand h;
        PrivateTrain pt;
        Domino d00;
        Domino d11;


        [SetUp]
        public void SetUpAllTests()
        {
            h = new Hand();
            pt = new PrivateTrain(0, h);
            d00 = new Domino(0, 0);
            d11 = new Domino(1, 1);
        }

        [Test]
        public void TestOpen()
        {
            pt.Open();
            Assert.True(pt.IsOpen);
        }

        [Test]
        public void TestClose()
        {
            pt.Open();
            pt.Close();
            Assert.False(pt.IsOpen);
        }

        [Test]
        public void TestIsPlayable()
        {
            bool mustFlip;
            Assert.True(pt.IsPlayable(d00, out mustFlip, h));
            
        }

        [Test]
        public void TestIsPlayableFalse()
        {
            bool mustFlip;
            Assert.False(pt.IsPlayable(d11, out mustFlip, h));
        }

        [Test]
        public void TestPlay()
        {
            pt.Play(d00, h);
            Assert.AreEqual(1, pt.Count);
        }

        [Test]
        public void TestPlayError()
        {
            try
            {
                pt.Play(d11, h);
                Assert.Fail("The Play method should throw an exception if domino cannot be played");
            }
            catch (Exception)
            {
                Assert.Pass("The Play method threw an exception for a domino that could not be played");
            }


        }
    }
}
