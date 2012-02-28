using System;
using NUnit.Framework;

namespace MathSolver.Tests
{
    [TestFixture]
    public class ParserFixture
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
        public void ComplexExpression()
        {
            Assert.IsNotNull(p.Parse("2x2-2x2"));
            Assert.IsNotNull(p.Parse("(Log(10,2)+3x2-4x5)"));
            Assert.AreEqual(2, p.Parse("1+1").Calc(new ConstantResolver(10)));
            Assert.AreEqual(4, p.Parse("3+1").Calc(new ConstantResolver(10)));
            Assert.AreEqual(5, p.Parse("2x+3x").Calc(new ConstantResolver(1)));
            Assert.AreEqual(20, p.Parse("2x+3x+5x").Calc(new ConstantResolver(2)));
            Assert.AreEqual(10, p.Parse("3x2+2x+5").Calc(new ConstantResolver(1)));
            Assert.AreEqual(21, p.Parse("3x2+2x+5").Calc(new ConstantResolver(2)));
            Assert.AreEqual(-5, p.Parse("-10x+5x").Calc(new ConstantResolver(1)));
            Assert.AreEqual(2, p.Parse("10x/5x").Calc(new ConstantResolver(1)));
            Assert.AreEqual(50, p.Parse("10x*5x").Calc(new ConstantResolver(1)));
            Assert.AreEqual(10, p.Parse("(2x+3x)/0.5x").Calc(new ConstantResolver(2)));
            Assert.AreEqual(10, p.Parse("5+10/2").Calc(new ConstantResolver(1)));
            Assert.AreEqual(7.5, p.Parse("(5+10)/2").Calc(new ConstantResolver(1)));
            Assert.AreEqual(11, p.Parse("1+5*2").Calc(new ConstantResolver(1)));
            Assert.AreEqual(12, p.Parse("(1+5)*2").Calc(new ConstantResolver(1)));
            Assert.AreEqual(4.3333333333333333333333333333333, p.Parse("2x2/-3x4+5x2").Calc(new ConstantResolver(1)));
            Assert.AreEqual(10, p.Parse("Exp(10,Log(10,10))").Calc(new ConstantResolver(1)));
            Assert.AreEqual(100, p.Parse("Exp(10,Log(100,10))").Calc(new ConstantResolver(1)));
            Assert.AreEqual(0.01, p.Parse("Exp(10,-Log(100,10))").Calc(new ConstantResolver(1)));
            Assert.IsNotNull(p.Parse("4x2+(Log(E(),2)/Exp(2,4)*x)"));
            Assert.IsNotNull(p.Parse("(Log(10,2)+3x2-4x5)/Soma(2x,0,3)"));
            Assert.AreNotSame(NullExpression.Instance, p.Parse("(Log(10,2) + 3x2 - 4x5) / Soma(2x,0,3)"));
            Assert.AreNotSame(NullExpression.Instance,
                              p.Parse("(Produto(Soma(x2+3x,0,10),1,2) * x4 + 3x ) / Sen(Raiz(2x)) + 5x"));
            Assert.IsNotNull(p.Parse("(Produto(Soma(x2+3x,0,10),1,2) * x4 + 3x ) / Sen(Raiz(2x)) + 5x"));
        }

        [Test]
        public void Cos()
        {
            Assert.AreEqual(Math.Cos(45), p.Parse("Cos(45)").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void DecimalNumericExpression()
        {
            Assert.AreEqual(1.45, p.Parse("1.45").Calc(new ConstantResolver(1)));
            Assert.AreEqual(41.45, p.Parse("41.45").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void E()
        {
            Assert.AreEqual(Math.E, p.Parse("E()").Calc(new ConstantResolver(1)));
            Assert.AreEqual(Math.E*-1, p.Parse("-E()").Calc(new ConstantResolver(1)));
            Assert.AreEqual(Math.E*-1, p.Parse("-E()").Calc(new ConstantResolver(2)));
        }

        [Test]
        public void EnclosedSimpleExpression()
        {
            Assert.AreEqual(9, p.Parse("(x2)").Calc(new ConstantResolver(3)));
            Assert.AreEqual(-9, p.Parse("(-(x2))").Calc(new ConstantResolver(3)));
            Assert.AreEqual(1, p.Parse("(((1)))").Calc(new ConstantResolver(10)));
        }

        [Test]
        public void IgnoreExpressionWhiteSpace()
        {
            Assert.AreEqual(p.Parse("x2").Calc(new ConstantResolver(1)), p.Parse(" x2").Calc(new ConstantResolver(1)));
            Assert.AreEqual(p.Parse("1 + 2").Calc(new ConstantResolver(1)), p.Parse("1+2").Calc(new ConstantResolver(1)));
            Assert.AreEqual(-1, p.Parse(" - 1").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void Log()
        {
            Assert.AreEqual(1, p.Parse("Log(10,10)").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void Pi()
        {
            Assert.AreEqual(Math.PI, p.Parse("Pi()").Calc(new ConstantResolver(1)));
            Assert.AreEqual(Math.PI*-1, p.Parse("-Pi()").Calc(new ConstantResolver(1)));
            Assert.AreEqual(Math.PI*-1, p.Parse("-Pi()").Calc(new ConstantResolver(2)));
        }

        [Test]
        public void Pow()
        {
            Assert.AreEqual(4, p.Parse("Exp(2,2)").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void Product()
        {
            Assert.AreEqual(36, p.Parse("Produto(x2,1,3)").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void Root()
        {
            Assert.AreEqual(2, p.Parse("Raiz(4)").Calc(new ConstantResolver(1)));
            Assert.AreEqual(-2, p.Parse("-Raiz(4)").Calc(new ConstantResolver(1)));
            Assert.AreEqual(3, p.Parse("Raiz(27,3)").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void Sen()
        {
            Assert.AreEqual(Math.Sin(45), p.Parse("Sen(45)").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void SimpleCoeficientAndVariableExpression()
        {
            Assert.AreEqual((double) 3, p.Parse("3x").Calc(new ConstantResolver(1)));
            Assert.AreEqual((double) 9, p.Parse("3x").Calc(new ConstantResolver(3)));
        }

        [Test]
        public void SimpleCoeficientAndVariableNegativeExpression()
        {
            Assert.AreEqual(-3d, p.Parse("-3x").Calc(new ConstantResolver(1)));
            Assert.AreEqual(-8d, p.Parse("-2x").Calc(new ConstantResolver(4)));
        }

        [Test]
        public void SimpleExpression()
        {
            Assert.AreEqual(9, p.Parse("+1x2").Calc(new ConstantResolver(3)));
            Assert.AreEqual(4, p.Parse("x2").Calc(new ConstantResolver(2)));
            Assert.AreEqual(270, p.Parse("10x3").Calc(new ConstantResolver(3)));
            Assert.AreEqual(-1000, p.Parse("-10x2").Calc(new ConstantResolver(10)));
            Assert.AreEqual(-27, p.Parse("-x3").Calc(new ConstantResolver(3)));
        }

        [Test]
        public void SimpleNegativeNumericExpression()
        {
            Assert.AreEqual((double) -2, p.Parse("-2").Calc(new ConstantResolver(1)));
            Assert.AreEqual((double) -6, p.Parse("-6").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void SimpleNegativeVariableExpression()
        {
            Assert.AreEqual((double) -3, p.Parse("-x").Calc(new ConstantResolver(3)));
            Assert.AreEqual((double) -1, p.Parse("-x").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void SimpleNumericExpression()
        {
            Assert.AreEqual((double) 10, p.Parse("10").Calc(new ConstantResolver(100)));

            Assert.AreEqual((double) 20, p.Parse("20").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void SimpleVariableExpression()
        {
            Assert.AreEqual(2, p.Parse("x").Calc(new ConstantResolver(2)));
            Assert.AreEqual(45.67, p.Parse("y").Calc(new ConstantResolver(45.67)));
        }

        [Test]
        public void Sum()
        {
            Assert.AreEqual(385, p.Parse("Soma(x2,0,10)").Calc(new ConstantResolver(1)));
        }

        [Test]
        public void Tan()
        {
            Assert.AreEqual(Math.Tan(45), p.Parse("Tg(45)").Calc(new ConstantResolver(1)));
        }
    }
}