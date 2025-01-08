using System;

public abstract class AutoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double CostBase { get; set; }
    public abstract double GetCost();
    public override string ToString()
    {
        return string.Format("Ваш автомобиль: \n{0} \nОписание: {1} \nСтоимость {2}\n", Name, Description, GetCost());
    }
}

class Renault : AutoBase
{
    public Renault(string name, string info, double costbase)
    {
        Name = name;
        Description = info;
        CostBase = costbase;
    }

    public override double GetCost()
    {
        return CostBase * 1.18;
    }
}

class DecoratorOptions : AutoBase
{
    public AutoBase AutoProperty { protected get; set; }
    public string Title { get; set; }

    public DecoratorOptions(AutoBase au, string tit)
    {
        AutoProperty = au;
        Title = tit;
    }
    
    public override double GetCost()
    {
        return CostBase;
    }
}

class MediaNAV : DecoratorOptions
{
    public MediaNAV(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Современный";
        Description = p.Description + ". " + this.Title + ". Обновленная мультимедийная навигационная система";
    }

    public override double GetCost()
    {
        return AutoProperty.GetCost() + 15.99;
    }
}

class SystemSecurity : DecoratorOptions
{
    public SystemSecurity(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Повышенной безопасности";
        Description = p.Description + ". " + this.Title + ". Передние боковые подушки безопасности, ESP - система динамической стабилизации автомобиля";
    }

    public override double GetCost()
    {
        return AutoProperty.GetCost() + 20.99;
    }
}

class ClimateControl : DecoratorOptions
{
    public ClimateControl(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Климат-контроль";
        Description = p.Description + ". " + this.Title + ". Система автоматического поддержания комфортной температуры";
    }

    public override double GetCost()
    {
        return AutoProperty.GetCost() + 10.99;
    }
}

class SportPackage : DecoratorOptions
{
    public SportPackage(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Спортивный пакет";
        Description = p.Description + ". " + this.Title + ". Улучшенная подвеска и спортивные сидения";
    }

    public override double GetCost()
    {
        return AutoProperty.GetCost() + 25.99;
    }
}

class PremiumSound : DecoratorOptions
{
    public PremiumSound(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Премиум-аудио";
        Description = p.Description + ". " + this.Title + ". Высококачественная акустическая система";
    }

    public override double GetCost()
    {
        return AutoProperty.GetCost() + 12.99;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Renault reno = new Renault("Рено", "Renault LOGAN Active", 499.0);
        Print(reno);

        AutoBase myreno = new MediaNAV(reno, "Навигация");
        Print(myreno);

        AutoBase newmyReno = new SystemSecurity(new MediaNAV(reno, "Навигация"), "Безопасность");
        Print(newmyReno);

        AutoBase fullOptionReno = new ClimateControl(new SystemSecurity(new MediaNAV(reno, "Навигация"), "Безопасность"), "Климат-контроль");
        Print(fullOptionReno);

        AutoBase sportReno = new SportPackage(new ClimateControl(new SystemSecurity(new MediaNAV(reno, "Навигация"), "Безопасность"), "Климат-контроль"), "Спортивный пакет");
        Print(sportReno);

        AutoBase premiumReno = new PremiumSound(new SportPackage(new ClimateControl(new SystemSecurity(new MediaNAV(reno, "Навигация"), "Безопасность"), "Климат-контроль"), "Спортивный пакет"), "Премиум-аудио");
        Print(premiumReno);
    }

    private static void Print(AutoBase av)
    {
        Console.WriteLine(av.ToString());
    }
}
