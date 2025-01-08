using System;

class Drive
{
    public event EventHandler driveevent;
    private string twist;

    public string Twist
    {
        get { return twist; }
        set
        {
            twist = value;
            driveevent?.Invoke(this, EventArgs.Empty);
        }
    }

    public Drive()
    {
        Twist = "исходная позиция";
    }

    public void TurlLeft()
    {
        Twist = "Поворот налево";
    }

    public void TurlRight()
    {
        Twist = "Поворот направо";
    }

    public void Stop()
    {
        Twist = "Стоп";
    }

    public override string ToString()
    {
        return $"Привод: {Twist}";
    }
}

class Power
{
    public event EventHandler powerevent;
    private int _power;

    public int MicrowavePower
    {
        get { return _power; }
        set
        {
            _power = value;
            powerevent?.Invoke(this, EventArgs.Empty);
        }
    }

    public override string ToString()
    {
        return $"Задана мощность {_power}w";
    }
}

class Notification
{
    public event EventHandler notificationevent;
    private string mess;

    public string MessageFin
    {
        get { return mess; }
        set
        {
            mess = value;
            notificationevent?.Invoke(this, EventArgs.Empty);
        }
    }

    public void StartNotification()
    {
        MessageFin = "Операция началась";
    }

    public void StopNotification()
    {
        MessageFin = "Операция завершена";
    }

    public override string ToString()
    {
        return $"Информация: {MessageFin}";
    }
}

class Microwave
{
    private Drive _drive;
    private Power _power;
    private Notification _notification;

    public Microwave(Drive drive, Power power, Notification notification)
    {
        _drive = drive;
        _power = power;
        _notification = notification;
    }

    public void Defrost()
    {
        _notification.StartNotification();
        _power.MicrowavePower = 1000;
        _drive.TurlRight();
        _drive.TurlRight();
        _power.MicrowavePower = 500;
        _drive.Stop();
        _drive.TurlLeft();
        _drive.TurlLeft();
        _power.MicrowavePower = 200;
        _drive.Stop();
        _drive.TurlRight();
        _drive.TurlRight();
        _drive.Stop();
        _power.MicrowavePower = 0;
        _notification.StopNotification();
    }

    public void Cook()
    {
        _notification.StartNotification();
        _power.MicrowavePower = 800;
        _drive.TurlRight();
        _drive.TurlRight();
        _drive.Stop();
        _power.MicrowavePower = 600;
        _drive.TurlLeft();
        _drive.Stop();
        _drive.TurlRight();
        _drive.TurlLeft();
        _drive.Stop();
        _power.MicrowavePower = 0;
        _notification.StopNotification();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var drive = new Drive();
        var power = new Power();
        var notification = new Notification();
        var microwave = new Microwave(drive, power, notification);

        power.powerevent += PowerEventHandler;
        drive.driveevent += DriveEventHandler;
        notification.notificationevent += NotificationEventHandler;

        Console.WriteLine("Разморозка");
        microwave.Defrost();

        Console.WriteLine("\nПриготовление");
        microwave.Cook();
    }

    static void NotificationEventHandler(object sender, EventArgs e)
    {
        var n = (Notification)sender;
        Console.WriteLine(n.ToString());
    }

    static void DriveEventHandler(object sender, EventArgs e)
    {
        var d = (Drive)sender;
        Console.WriteLine(d.ToString());
    }

    static void PowerEventHandler(object sender, EventArgs e)
    {
        var p = (Power)sender;
        Console.WriteLine(p.ToString());
    }
}
