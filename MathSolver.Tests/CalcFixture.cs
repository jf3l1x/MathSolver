using NUnit.Framework;

namespace MathSolver.Tests
{
    [TestFixture]
    public class CalcFixture
    {
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
    }
    
}