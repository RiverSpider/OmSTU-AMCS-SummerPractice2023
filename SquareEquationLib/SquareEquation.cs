namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double[] solve1 = {};
        double[] solve2 = new double[1];
        double[] solve3 = new double[2];
        double eps = 1e-6;
        if (-eps < a && a < eps) throw new System.ArgumentException();
        if ( double.IsNaN(a) || double.IsInfinity(a) || double.IsNaN(b) || double.IsInfinity(b) || double.IsNaN(c) || double.IsInfinity(c)) throw new System.ArgumentException();
        b = b/a;
        c = c/a;
        double d = b*b-4*c;
        if (d<=-eps) return solve1;
        else if (d < eps){
            solve2[0] = -(b)/2;
            return solve2;
        } 
        else {
            double sign = b==0?1:Math.Sign(b);
            solve3[0] = -( b + sign * Math.Sqrt(d) )/2;
            solve3[1] = c/solve3[0];
            return solve3;
        }
        
    }
}
