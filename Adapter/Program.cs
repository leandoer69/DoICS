using System;

public class FahrenheitTemperatureSensor
{
    private Random _random = new Random();

    public double GetTemperature()
    {
        // Случайная температура от 0°F до 451°F
        return _random.Next(0, 452);
    }
}

public class CelsiusTemperatureAdapter
{
    private FahrenheitTemperatureSensor _fahrenheitSensor;

    public CelsiusTemperatureAdapter(FahrenheitTemperatureSensor fahrenheitSensor)
    {
        _fahrenheitSensor = fahrenheitSensor;
    }

    public double GetTemperature()
    {
        double fahrenheitTemp = _fahrenheitSensor.GetTemperature();
        double celsiusTemp = (fahrenheitTemp - 32) * 5.0 / 9.0;
        return celsiusTemp;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Экземпляр температурного датчика
        FahrenheitTemperatureSensor fahrenheitSensor = new FahrenheitTemperatureSensor();
        
        // Адаптер для преобразования Фаренгейта в Цельсий
        CelsiusTemperatureAdapter celsiusAdapter = new CelsiusTemperatureAdapter(fahrenheitSensor);
        
        // Получаем и выводим температуру в Цельсии
        double celsiusTemperature = celsiusAdapter.GetTemperature();
        Console.WriteLine($"Температура в Цельсиях: {celsiusTemperature:F2} °C");
    }
}