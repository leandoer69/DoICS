using System;

abstract class NavigationStrategy
{
    public string Title { get; set; }
    public abstract void CalculateRoute(string start, string destination);
}

class DrivingRouteStrategy : NavigationStrategy
{
    public DrivingRouteStrategy()
    {
        Title = "Маршрут по автодорогам";
    }

    public override void CalculateRoute(string start, string destination)
    {
        Console.WriteLine($"Прокладываем маршрут по автодорогам от {start} до {destination}.");
    }
}

class WalkingRouteStrategy : NavigationStrategy
{
    public WalkingRouteStrategy()
    {
        Title = "Пеший маршрут";
    }

    public override void CalculateRoute(string start, string destination)
    {
        Console.WriteLine($"Прокладываем пеший маршрут от {start} до {destination}.");
    }
}

class CyclingRouteStrategy : NavigationStrategy
{
    public CyclingRouteStrategy()
    {
        Title = "Маршрут по велодорожкам";
    }

    public override void CalculateRoute(string start, string destination)
    {
        Console.WriteLine($"Прокладываем маршрут по велодорожкам от {start} до {destination}.");
    }
}

class PublicTransportRouteStrategy : NavigationStrategy
{
    public PublicTransportRouteStrategy()
    {
        Title = "Маршрут на общественном транспорте";
    }

    public override void CalculateRoute(string start, string destination)
    {
        Console.WriteLine($"Прокладываем маршрут на общественном транспорте от {start} до {destination}.");
    }
}

class SightseeingRouteStrategy : NavigationStrategy
{
    public SightseeingRouteStrategy()
    {
        Title = "Маршрут посещения достопримечательностей";
    }

    public override void CalculateRoute(string start, string destination)
    {
        Console.WriteLine($"Прокладываем маршрут посещения достопримечательностей от {start} до {destination}.");
    }
}

class NavigationContext
{
    private NavigationStrategy strategy;

    public void SetStrategy(NavigationStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void ExecuteStrategy(string start, string destination)
    {
        if (strategy != null)
        {
            Console.WriteLine($"Используем стратегию: {strategy.Title}");
            strategy.CalculateRoute(start, destination);
        }
        else
        {
            Console.WriteLine("Стратегия не выбрана.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        NavigationContext navigator = new NavigationContext();

        navigator.SetStrategy(new DrivingRouteStrategy());
        navigator.ExecuteStrategy("Москва", "Санкт-Петербург");

        navigator.SetStrategy(new WalkingRouteStrategy());
        navigator.ExecuteStrategy("Точка А", "Точка Б");

        navigator.SetStrategy(new CyclingRouteStrategy());
        navigator.ExecuteStrategy("Парк", "Набережная");

        navigator.SetStrategy(new PublicTransportRouteStrategy());
        navigator.ExecuteStrategy("Остановка 1", "Остановка 2");

        navigator.SetStrategy(new SightseeingRouteStrategy());
        navigator.ExecuteStrategy("Музей", "Театр");
    }
}