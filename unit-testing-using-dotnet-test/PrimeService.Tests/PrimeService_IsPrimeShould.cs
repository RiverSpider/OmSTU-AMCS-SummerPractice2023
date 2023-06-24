using Xunit;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        [Fact]
        public void IsPrime_aIs0()
        {
            bool result;
            try{
                double[] a = PrimeService.Solve(0, 1, 1);
                result = true;
            }
            catch(System.ArgumentException){
                result = false;
            }
            Assert.False(result, "a = 0");
        }
        [Fact]
        public void IsPrime_aIsNaN()
        {
            bool result;
            try{
                double[] a = PrimeService.Solve(double.NaN, 1, 1);
                result = true;
            }
            catch(System.ArgumentException){
                result = false;
            }
            Assert.False(result, "a = nan");
        }
        [Fact]
        public void IsPrime_aIsPInf()
        {
            bool result;
            try{
                double[] a = PrimeService.Solve(double.PositiveInfinity, 1, 1);
                result = true;
            }
            catch(System.ArgumentException){
                result = false;
            }
            Assert.False(result, "a = PositiveInfinity");
        }
        [Fact]
        public void IsPrime_aIsNInf()
        {
            bool result;
            try{
                double[] a = PrimeService.Solve(double.NegativeInfinity, 1, 1);
                result = true;
            }
            catch(System.ArgumentException){
                result = false;
            }
            Assert.False(result, "a = NegativeInfinity");
        }
        [Fact]
        public void IsPrime_bIsNaN()
        {
            bool result;
            try{
                double[] a = PrimeService.Solve(1, double.NaN, 1);
                result = true;
            }
            catch(System.ArgumentException){
                result = false;
            }
            Assert.False(result, "b = nan");
        }
        [Fact]
        public void IsPrime_bIsPInf()
        {
            bool result;
            try{
                double[] a = PrimeService.Solve(1, double.PositiveInfinity, 1);
                result = true;
            }
            catch(System.ArgumentException){
                result = false;
            }
            Assert.False(result, "b = PositiveInfinity");
        }
        [Fact]
        public void IsPrime_bIsNInf()
        {
            bool result;
            try{
                double[] a = PrimeService.Solve(1, double.NegativeInfinity, 1);
                result = true;
            }
            catch(System.ArgumentException){
                result = false;
            }
            Assert.False(result, "b = NegativeInfinity");
        }
        [Fact]
        public void IsPrime_cIsNaN()
        {
            bool result;
            try{
                double[] a = PrimeService.Solve(1, double.NaN, 1);
                result = true;
            }
            catch(System.ArgumentException){
                result = false;
            }
            Assert.False(result, "c = nan");
        }
        [Fact]
        public void IsPrime_cIsPInf()
        {
            bool result;
            try{
                double[] a = PrimeService.Solve(1, double.PositiveInfinity, 1);
                result = true;
            }
            catch(System.ArgumentException){
                result = false;
            }
            Assert.False(result, "c = PositiveInfinity");
        }
        [Fact]
        public void IsPrime_cIsNInf()
        {
            bool result;
            try{
                double[] a = PrimeService.Solve(1, double.NegativeInfinity, 1);
                result = true;
            }
            catch(System.ArgumentException){
                result = false;
            }
            Assert.False(result, "c = NegativeInfinity");
        }


        [Fact]
        public void IsPrime_DisP()
        {
            bool result = true;
            try{
                double a = 1;
                double b = 1000000;
                double c = 1;
                double eps = 1e-3;
                double[] q = PrimeService.Solve(a, b, c);
                if(b-eps <= -(q[0]+q[1]) && -(q[0]+q[1]) <= b+eps &&  c-eps <= (q[0]*q[1]) && (q[0]*q[1]) <= c+eps){
                    result = false;
                }
            }
            catch{
            }
            Assert.False(result, "D > 0");
        }
        [Fact]
        public void IsPrime_DisZero()
        {
            bool result = true;
            try{
                double a = 1;
                double b = 2;
                double c = 1;
                double eps = 1e-3;
                double[] q = PrimeService.Solve(a, b, c);
                if(b-eps <= -(q[0]+q[0]) && -(q[0]+q[0]) <= b+eps &&  c-eps <= (q[0]*q[0]) && (q[0]*q[0]) <= c+eps){
                    result = false;
                }
            }
            catch{
            }
            Assert.False(result, "D = 0");
        }
        [Fact]
        public void IsPrime_DisN()
        {
            bool result = false;
            try{
                double a = 1000000;
                double b = 1;
                double c = 1;
                double eps = 1e-3;
                double[] q = PrimeService.Solve(a, b, c);
                double p = q[0];
                result = true;
            }
            catch{
            }
            Assert.False(result, "D < 0");
        }
    }
}