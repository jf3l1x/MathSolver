using System;
using MathSolver.Functions;
using NUnit.Framework;

namespace MathSolver.Tests
{
    [TestFixture]
    public class FunctionsFixture
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            p = new Parser();
        }

        #endregion

        private Parser p;

        [Test]
        public void Cos()
        {
            Cos c = new Cos();
            c.AddParameter(p.Parse("45"));
            Assert.AreEqual(Math.Cos(45), c.Calc(new ConstantResolver(1)));
        }

        [Test]
        public void E()
        {
            E e = new E();
            Assert.AreEqual(Math.E, e.Calc(new ConstantResolver(1)));
            Assert.AreEqual(Math.E, e.Calc(new ConstantResolver(10)));
        }

        [Test]
        public void Log()
        {
            Log l = new Log();

            l.AddParameter(p.Parse("10"), p.Parse("10"));
            Assert.AreEqual(1, l.Calc(new ConstantResolver(1)));
            l = new Log();
            l.AddParameter(p.Parse("1"), p.Parse("10"));
            Assert.AreEqual(0, l.Calc(new ConstantResolver(1)));
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void ParametersAlowed()
        {
            Root r = new Root();
            r.AddParameter(p.Parse("1"));
            r.AddParameter(p.Parse("1"));
            r.AddParameter(p.Parse("1"));
        }

        [Test]
        public void Pi()
        {
            Pi e = new Pi();
            Assert.AreEqual(Math.PI, e.Calc(new ConstantResolver(1)));
            Assert.AreEqual(Math.PI, e.Calc(new ConstantResolver(10)));
        }

        [Test]
        public void Pow()
        {
            Pow f = new Pow();
            f.AddParameter(p.Parse("10"), p.Parse("2"));
            Assert.AreEqual(100, f.Calc(new ConstantResolver(1)));
            f = new Pow();
            f.AddParameter(p.Parse("10"), p.Parse("3"));
            Assert.AreEqual(1000, f.Calc(new ConstantResolver(1)));
            f = new Pow();
            f.AddParameter(p.Parse("x2"), p.Parse("3"));
            Assert.AreEqual(Math.Pow(2, 6), f.Calc(new ConstantResolver(2)));
            f = new Pow();
            f.AddParameter(p.Parse("2x+3x2"), p.Parse("2"));
            //f(x)=2x+3x2 -> f(2)=16 
            //f(x)=(2x+3x2)2 f(2)=(16)2
            Assert.AreEqual(Math.Pow(16, 2), f.Calc(new ConstantResolver(2)));
        }

        [Test]
        public void Product()
        {
            Product product = new Product();
            product.AddParameter(p.Parse("x2"), p.Parse("1"), p.Parse("3"));
            Assert.AreEqual(36, product.Calc(new ConstantResolver(1)));
        }

        [Test]
        public void Root()
        {
            Root r = new Root();
            r.AddParameter(p.Parse("4"));
            Assert.AreEqual(2, r.Calc(new ConstantResolver(1)));
            r = new Root();
            r.AddParameter(p.Parse("27"), p.Parse("3"));
            Assert.AreEqual(3, r.Calc(new ConstantResolver(1)));
        }

        [Test]
        public void Sen()
        {
            Sen s = new Sen();
            s.AddParameter(p.Parse("45"));
            Assert.AreEqual(Math.Sin(45), s.Calc(new ConstantResolver(1)));
        }

        [Test]
        public void Sum()
        {
            Sum s = new Sum();
            s.AddParameter(p.Parse("x2"), p.Parse("0"), p.Parse("10"));
            Assert.AreEqual(385, s.Calc(new ConstantResolver(1)));
        }

        [Test]
        public void Tan()
        {
            Tan t = new Tan();
            t.AddParameter(p.Parse("45"));
            Assert.AreEqual(Math.Tan(45), t.Calc(new ConstantResolver(1)));
        }
    }
}