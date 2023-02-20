using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace LR_1
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void OperationPlusMinus()
        {
            var main = new Form1();
            var result = main.Translation("2+3-5+213");
            Assert.AreEqual("AB+C-D+", result);
        }
        
        [TestMethod]
        public void OperationMultiplication()
        {
            var main = new Form1();
            var result = main.Translation("2+(3-10)*212");
            Assert.AreEqual("ABC-D*+", result);
        }
        
        [TestMethod]
        public void OperationSinCosArcSinArcCos()
        {
            var main = new Form1();
            var result = main.Translation("sin(cos(2+45/431))-90+11*(2*3-7)");
            Assert.AreEqual("ABC/+баD-EFG*H-*+", result);
        }
        
        [TestMethod]
        public void OperationDegree1()
        {
            var main = new Form1();
            var result = main.Translation("2+4^5+1");
            Assert.AreEqual("ABCдD++", result);
        }
        
        [TestMethod]
        public void OperationDegree2()
        {
            var main = new Form1();
            var result = main.Translation("2+4^5*1");
            Assert.AreEqual("ABCD*д+", result);
        }
        
        [TestMethod]
        public void OperationHard()
        {
            var main = new Form1();
            var result = main.Translation("sin(cos(2+45/431))-90+11*(2*3-7)^45");
            Assert.AreEqual("ABC/+баD-EFG*H-дI*+", result);
        }
    }
}