abstract class CarFactory
{
    public abstract AbstractCar CreateCar();
    public abstract AbstractEngine CreateEngine();
    public abstract AbstractBody CreateBody();
}


abstract class AbstractCar
{
    public string Name { get; set; }
    public abstract int MaxSpeed(AbstractEngine engine);

    public abstract string BodyType(AbstractBody body);

}

abstract class AbstractEngine
{
    public int max_speed { get; set; }
}

abstract class AbstractBody
{
    public string body_type { get; set; }
}

// singleton, чтобы объект FordFactory создавался только 1 раз
class FordFactory : CarFactory
{
    private FordFactory() { }

    static Lazy<FordFactory> myFactory = new Lazy<FordFactory>(() => new FordFactory());
    public static FordFactory MyFordFactory
    {
        get
        {
            return myFactory.Value;
        }
    }
    public override AbstractCar CreateCar()
    {
        return new FordCar("Форд");
    }
    public override AbstractEngine CreateEngine()
    {
        return new FordEngine();
    }

    public override AbstractBody CreateBody()
    {
        return new FordBody();
    }
}

class FordCar : AbstractCar
{
    public FordCar(string name)
    {
        Name = name;
    }
    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }

    public override string BodyType(AbstractBody body)
    {
        string bt = body.body_type;
        return bt;
    }
    public override string ToString()
    {
        return "Автомобиль " + Name;

    }
}

class FordEngine : AbstractEngine
{
    public FordEngine()
    {
        max_speed = 220;
    }
}

class FordBody : AbstractBody
{
    public FordBody()
    {
        body_type = "Седан";
    }
}


class AudiFactory : CarFactory
{
    public override AbstractCar CreateCar()
    {
        return new AudiCar("Ауди");
    }
    public override AbstractEngine CreateEngine()
    {
        return new AudiEngine();
    }
    public override AbstractBody CreateBody()
    {
        return new AudiBody();
    }
}

class AudiCar : AbstractCar
{
    public AudiCar(string name)
    {
        Name = name;
    }
    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }

    public override string BodyType(AbstractBody body)
    {
        string bt = body.body_type;
        return bt;
    }
    public override string ToString()
    {
        return "Автомобиль " + Name;

    }
}

class AudiEngine : AbstractEngine
{
    public AudiEngine()
    {
        max_speed = 250;
    }
}

class AudiBody : AbstractBody
{
    public AudiBody()
    {
        body_type = "Кроссовер";
    }
}

class Client
{
    private AbstractCar abstractCar;
    private AbstractEngine abstractEngine;
    private AbstractBody abstractBody;
    public Client(CarFactory car_factory)
    {
        abstractCar = car_factory.CreateCar();
        abstractEngine = car_factory.CreateEngine();
        abstractBody = car_factory.CreateBody();
    }
    public int RunMaxSpeed()
    {
        return abstractCar.MaxSpeed(abstractEngine);
    }
    public override string ToString()
    {
        return abstractCar.ToString();
    }

    public string GetBodyType()
    {
        return abstractCar.BodyType(abstractBody);
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        CarFactory ford_car = FordFactory.MyFordFactory;
        Client c1 = new Client(ford_car);
        Console.WriteLine("Максимальная скорость {0} составляет {1} км/час, тип кузова - {2}",
        c1.ToString(), c1.RunMaxSpeed(), c1.GetBodyType());

        CarFactory audi_car = new AudiFactory();
        Client c2 = new Client(audi_car);
        Console.WriteLine("Максимальная скорость {0} составляет {1} км/час, тип кузова - {2}",
        c2.ToString(), c2.RunMaxSpeed(), c2.GetBodyType());

    }
}