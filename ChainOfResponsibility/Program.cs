
class Receiver
{
    // банковские переводы
    public bool BankTransfer { get; set; }
    // денежные переводы - WesternUnion, Unistream
    public bool MoneyTransfer { get; set; }
    // перевод через PayPal
    public bool PayPalTransfer { get; set; }
    public Receiver(bool bt, bool mt, bool ppt)
    {
        BankTransfer = bt;
        MoneyTransfer = mt;
        PayPalTransfer = ppt;
    }
}

abstract class PaymentHandler
{
    public PaymentHandler Successor { get; set; }
    public abstract void Handle(Receiver receiver);
}

public class Program
{
    public static void Main(string[] args)
    {
        Receiver receiver = new Receiver(false, true, true);
        PaymentHandler bankPaymentHandler = new BankPaymentHandler();
        PaymentHandler moneyPaymentHandler = new MoneyPaymentHandler();
        PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();

        // старая цепочка переводов
        bankPaymentHandler.Successor = paypalPaymentHandler;
        paypalPaymentHandler.Successor = moneyPaymentHandler;
        bankPaymentHandler.Handle(receiver);


        Receiver receiver1 = new Receiver(true, true, true);
        PaymentHandler bankPaymentHandler1 = new BankPaymentHandler();
        PaymentHandler moneyPaymentHandler1 = new MoneyPaymentHandler();
        PaymentHandler paypalPaymentHandler1 = new PayPalPaymentHandler();

        // новая цепочка переводов
        moneyPaymentHandler1.Successor = bankPaymentHandler1;
        bankPaymentHandler1.Successor = paypalPaymentHandler1;

        bankPaymentHandler1.Handle(receiver1);
    }
}