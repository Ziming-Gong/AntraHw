using SharedApp.Model;

namespace ReceiverNotificationApp;

public class EmailNotification
{
    public void SendEmail(Customer customer)
    {
        Console.WriteLine($"Email has been sent to {customer.Name} for amount {customer.BillableAmount}");
    }
}