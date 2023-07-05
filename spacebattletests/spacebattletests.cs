using SpaceBattle;
using TechTalk.SpecFlow;

namespace SpaceBattleTests{
[Binding]
public class ИгровойОбъектМожетПеремещатьсяПоПрямой
{
    private readonly ScenarioContext _scenarioContext;
    private double[] _start = new double[2];
    private double[] _finish = new double[2];
    private bool _isAllowToMove = true;
    private bool _IsSpeed = true;
    private bool _IsPosition = true; 
    private Lazy<double[]> _result = default!;
    public ИгровойОбъектМожетПеремещатьсяПоПрямой(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void ДопустимКосмическийКорабльНаходитсяВТочкеПространстваСКоординатами(double p0, double p1)
    {
        _start[0] = p0;
        _start[1] = p1;
    }

    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void ИИмеетМгновеннуюСкорость(double p0, double p1)
    {
        _finish[0] = p0;
        _finish[1] = p1;
    }

    [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
    public void КосмическийКорабльПоложениеВПространствеКоторогоНевозможноОпределить()
    {
        _IsPosition = false;
    }
    
    [Given(@"скорость корабля определить невозможно")]
    public void CкоростьКорабляОпределитьНевозможно()
    {
        _IsSpeed = false;
    }

    [Given(@"изменить положение в пространстве космического корабля невозможно")]
    public void ИзменитьПоложениеВПространствеКосмическогоКорабляНевозможно()
    {
        _isAllowToMove = false;
    }

    [When(@"происходит прямолинейное равномерное движение без деформации")]
    public void ПроисходитПрямолинейноеРавномерноеДвижениеБезДеформации()
    {
        _result = new Lazy<double[]>(() => ShipMove.ShipMoving(_start, _finish, _isAllowToMove, _IsPosition, _IsSpeed));
    }

    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void КосмическийКорабльПеремещаетсяВТочкуПространстваСКоординатами(double p0, double p1)
    {
        double[] expected = {p0, p1};
        Assert.Equal(expected, _result.Value);
    }

    [Then(@"возникает ошибка Exception")]
    public void ВозникаетОшибкаException ()
    {
        Assert.Throws<Exception>(() => _result.Value);
    }
}}