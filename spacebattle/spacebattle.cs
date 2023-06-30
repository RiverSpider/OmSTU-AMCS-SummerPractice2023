namespace SpaceBattle;
public class ShipMove
{
    private bool _AllowToMove;
    private bool _IsSpeed;
    private bool _IsPosition;

    public double[] _Speed = new double[2];
    public double[] _Position = new double[2];

    public static double[] ShipMoving(double[] position, double[] speed, bool IsAllow, bool IsPosition, bool IsSpeed){
        var SM = new ShipMove();
        SM._AllowToMove = IsAllow;
        SM._IsPosition = IsPosition;
        SM._IsSpeed = IsSpeed;
        SM._Position = position;
        SM._Speed = speed; // мне кажется, в дальнейшем(если бы эта лаба продолжалась) эти значения можно было использовать в других методах 
        if (!(SM._AllowToMove) || !(SM._IsPosition) || !(SM._IsSpeed)) throw new Exception();
        double x = SM._Position[0] + SM._Speed[0];
        double y = SM._Position[1] + SM._Speed[1];
        double[] finish = {x, y};
        return finish; 
    }
}
public class ShipFuel
{
    public double _FuelTaken;
    public double _FuelHas;

    public static double ShipMoving(double Fuelhas, double Fueltaken){
        var SM = new ShipFuel();
        SM._FuelTaken = Fueltaken;
        SM._FuelHas = Fuelhas; 
        if (SM._FuelHas - SM._FuelTaken < 0) throw new Exception();
        return SM._FuelHas - SM._FuelTaken; 
    }
}
public class ShipTurn
{
    private bool _AllowToTurn;
    private bool _IsDegree;
    private bool _IsPosition;

    public double _Degree;
    public double _Position;
    public static double ShipMoving(double position, double Degree, bool IsAllow, bool IsPosition, bool IsDegree){
        var SM = new ShipTurn();
        SM._Position = position;
        SM._Degree = Degree;
        SM._AllowToTurn = IsAllow;
        SM._IsPosition = IsPosition;
        SM._IsDegree = IsDegree;
        if (!(SM._AllowToTurn) || !(SM._IsPosition) || !(SM._IsDegree)) throw new Exception();
        return SM._Position + SM._Degree; 
    }
}
