using Xunit;
using SquareEquationLib;

namespace Prime.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        [Fact]
        public void IsPrime_aIs0()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(0, 1, 1));
        }
        [Fact]
        public void IsPrime_aIsNaN()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(double.NaN, 1, 1));
        }
        [Fact]
        public void IsPrime_aIsPInf()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(double.PositiveInfinity, 1, 1));
        }
        [Fact]
        public void IsPrime_aIsNInf()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(double.NegativeInfinity, 1, 1));
        }
        [Fact]
        public void IsPrime_bIsNaN()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, double.NaN, 1));
        }
        [Fact]
        public void IsPrime_bIsPInf()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, double.PositiveInfinity, 1));
        }
        [Fact]
        public void IsPrime_bIsNInf()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, double.NegativeInfinity, 1));
        }
        [Fact]
        public void IsPrime_cIsNaN()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, double.NaN, 1));
        }
        [Fact]
        public void IsPrime_cIsPInf()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, double.PositiveInfinity, 1));
        }
        [Fact]
        public void IsPrime_cIsNInf()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, double.NegativeInfinity, 1));
        }


        [Fact]
        public void IsPrime_DisP()
        {
            double a = 1;
            double b = 1000000;
            double c = 1;
            double eps = 1e-9;
            double[] q = SquareEquation.Solve(a, b, c);
            Assert.True((b-eps <= -(q[0]+q[1]) && -(q[0]+q[1]) <= b+eps &&  c-eps <= (q[0]*q[1]) && (q[0]*q[1]) <= c+eps));
        }
        [Fact]
        public void IsPrime_DisZero()
        {
            double a = 1;
            double b = 2;
            double c = 1;
            double eps = 1e-9;
            double[] q = SquareEquation.Solve(a, b, c);
            Assert.True((b-eps <= -(q[0]+q[0]) && -(q[0]+q[0]) <= b+eps &&  c-eps <= (q[0]*q[0]) && (q[0]*q[0]) <= c+eps));
        }
        [Fact]
        public void IsPrime_DisN()
        {
                double a = 1000000;
                double b = 1;
                double c = 1;
                double[] p = {};
            Assert.Equal(SquareEquation.Solve(a, b, c), p);
        }
    }
}