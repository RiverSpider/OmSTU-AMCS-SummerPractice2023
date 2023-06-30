using SpaceBattle;
using TechTalk.SpecFlow;

namespace SpaceBattleTests{
[Binding]
public class ИгровойОбъектМожетПеремещатьсяПоПрямой
{
    private readonly ScenarioContext _scenarioContext;
    private double _start;
    private double _degree;
    private bool _isAllowToTurn = true;
    private bool _IsDegree = true;
    private bool _IsPosition = true; 
    private double _result;
    public ИгровойОбъектМожетПеремещатьсяПоПрямой(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
    public void КосмическийКорабльИмеетУголНаклона(double p0)
    {
        _start = p0;
    }

    [Given(@"имеет мгновенную угловую скорость (.*) град")]
    public void ИИмеетМгновеннуюУгловуюСкорость(double p0)
    {
        _degree = p0;
    }

    [Given(@"космический корабль, угол наклона которого невозможно определить")]
    public void КосмическийКорабльУголНаклонаКоторогоНевозможноОпределить()
    {
        _IsPosition = false;
    }
    
    [Given(@"мгновенную угловую скорость невозможно определить")]
    public void МгновеннуюУгловуюСкоростьНевозможноОпределить()
    {
        _IsDegree = false;
    }

    [Given(@"невозможно изменить угол наклона к оси OX космического корабля")]
    public void НевозможноИзменитьУголНаклонаКОсиOXКосмическогоКорабля()
    {
        _isAllowToTurn = false;
    }

    [When(@"происходит вращение вокруг собственной оси")]
    public void ПроисходитВращениеВокругСобственнойОси()
    {
        try{
        _result = ShipTurn.ShipMoving(_start, _degree, _isAllowToTurn, _IsPosition, _IsDegree);
        }
        catch{}
    }

    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void УголНаклонаКосмическогоКорабляКОсиOXСоставляет(double p0)
    {
        Assert.Equal(p0, _result);
    }

    [Then(@"возникает ошибка Exception")]
    public void ВозникаетОшибкаException ()
    {
        Assert.Throws<Exception>(() => ShipTurn.ShipMoving(_start, _degree, _isAllowToTurn, _IsPosition, _IsDegree));
    }
}}