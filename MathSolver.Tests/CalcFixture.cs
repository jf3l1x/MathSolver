using NUnit.Framework;

namespace MathSolver.Tests
{
    [TestFixture]
    public class CalcFixture
    {
         [SetUp]
        public void Setup()
        {
            p = new Parser();
        }

        

        private Parser p;
        [Test]
        public void CalcMultipleVariables()
        {
            var resolver = new Moq.Mock<IVariableResolver>();
            resolver.Setup(x => x.Resolve("x")).Returns(1);
            resolver.Setup(x => x.Resolve("y")).Returns(2);
            resolver.Setup(x => x.Resolve("z")).Returns(3);
            var p = new Parser();
            var expression = p.Parse("x+y+z");
            Assert.AreEqual(6,expression.Calc(resolver.Object));
        }
        [Test]
        public void Equals()
        {
            var expression = p.Parse("1==1");
            Assert.AreEqual(1,expression.Calc(new ConstantResolver(1)));            
            expression = p.Parse("1==0");
            Assert.AreEqual(0,expression.Calc(new ConstantResolver(1)));            
        }
        [Test]
        public void NotEquals()
        {
            var expression = p.Parse("1!=1");
            Assert.AreEqual(0, expression.Calc(new ConstantResolver(1)));
            expression = p.Parse("1!=3");
            Assert.AreEqual(1, expression.Calc(new ConstantResolver(1)));
        }
        [Test]
        public void And()
        {
            var expression = p.Parse("(1==1) && (2==2) && (3==3)");
            Assert.AreEqual(1, expression.Calc(new ConstantResolver(1)));
            expression = p.Parse("(1!=3) && (2!=2)");
            Assert.AreEqual(0, expression.Calc(new ConstantResolver(1)));
        }
        [Test]
        public void Or()
        {
            var expression = p.Parse("(1!=1) || (2!=2) || (3!=3)");
            Assert.AreEqual(0, expression.Calc(new ConstantResolver(1)));
            expression = p.Parse("(1!=3) || (2!=2)");
            Assert.AreEqual(1, expression.Calc(new ConstantResolver(1)));
        }
        [Test]
        public void Greater()
        {
            var expression = p.Parse("1>3");
            Assert.AreEqual(0, expression.Calc(new ConstantResolver(1)));
            expression = p.Parse("3>1");
            Assert.AreEqual(1, expression.Calc(new ConstantResolver(1)));
        }
        [Test]
        public void GreaterOrEqual()
        {
            var expression = p.Parse("1>=1");
            Assert.AreEqual(1, expression.Calc(new ConstantResolver(1)));
            expression = p.Parse("3>=5");
            Assert.AreEqual(0, expression.Calc(new ConstantResolver(1)));
        }
        [Test]
        public void Lesser()
        {
            var expression = p.Parse("3<1");
            Assert.AreEqual(0, expression.Calc(new ConstantResolver(1)));
            expression = p.Parse("1<4");
            Assert.AreEqual(1, expression.Calc(new ConstantResolver(1)));
        }
        [Test]
        public void LesserOrEqual()
        {
            var expression = p.Parse("1<=1");
            Assert.AreEqual(1, expression.Calc(new ConstantResolver(1)));
            expression = p.Parse("5<=3");
            Assert.AreEqual(0, expression.Calc(new ConstantResolver(1)));
        }
        
    }
    
}