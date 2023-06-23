namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        if (a == 0) throw new System.ArgumentException();

        if ( c == double.NegativeInfinity || c == Double.NaN || c == double.PositiveInfinity || a == double.PositiveInfinity || b == double.PositiveInfinity || a == double.NegativeInfinity || b == double.NegativeInfinity || a == Double.NaN || b == Double.NaN) throw new ArgumentException();
        double d = b*b-4*c*a;
        double[] solve = new double[2];
        if (d<-Single.Epsilon) return solve;
        else if (Single.Epsilon <= d && d <= Single.Epsilon){
            solve[0] = -(b + Math.Sign(b)* Math.Sqrt(d) )/2*a;
        } 
        else {
            solve[0] = -( b + Math.Sign(b)* Math.Sqrt(d) )/2*a ;
            solve[1] = c/solve[0]  ;
        }
        return solve;
    }
}
