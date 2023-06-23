namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double[] solve1 = {};
        double[] solve2 = new double[1];
        double[] solve3 = new double[2];
        if (a == 0) throw new System.ArgumentException();
        if ( c == double.NegativeInfinity || c == Double.NaN || c == double.PositiveInfinity || a == double.PositiveInfinity || b == double.PositiveInfinity || a == double.NegativeInfinity || b == double.NegativeInfinity || a == Double.NaN || b == Double.NaN) throw new System.ArgumentException();
        double d = b*b-4*c*a;
        double[] solve = new double[2];
        if (d<=-Single.Epsilon) return solve1;
        else if (-Single.Epsilon < d && d < Single.Epsilon){
            solve2[0] = -(b)/2*a;
            return solve2;
        } 
        else {
            solve3[0] = -( b + Math.Sign(b)* Math.Sqrt(d) )/2*a ;
            solve3[1] = c/solve[0];
            return solve3;
        }
        
    }
}
