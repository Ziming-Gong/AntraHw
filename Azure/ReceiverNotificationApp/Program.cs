using System.Collections;
using System.Text;
using Microsoft.Azure.ServiceBus;
// using Newtonsoft.Json;
using SharedApp.Model;
using System.Text.Json;
using ReceiverNotificationApp;


static async Task GetData()
{
    string connectionString =
        "Endpoint=sb://notification-zim.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=S1f7Lp1LIdUGrp0OKyAaG7vgJdDXp5Lpm+ASbL+AGHk="; 
    string queueName = "emailnotificationqueue";
    var queueClient = new QueueClient(connectionString, queueName);
    var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
    {
        MaxConcurrentCalls = 1,
        AutoComplete = true
    };
    queueClient.RegisterMessageHandler( ProcessMessageAsync ,messageHandlerOptions);
    Console.WriteLine("Press Enter to Stop");
    Console.ReadLine();
    // queueClient.CompleteAsync()
    await queueClient.CloseAsync();
}

static Task ProcessMessageAsync(Message arg1, CancellationToken arg2)
{
    var jsonMessage = Encoding.UTF8.GetString(arg1.Body);
    Customer customer = JsonSerializer.Deserialize<Customer>(jsonMessage);
    EmailNotification emailNotification = new EmailNotification();
    emailNotification.SendEmail(customer);
    return Task.CompletedTask;
}

static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs args)
{
    Console.WriteLine("Exception = " + args);
    return Task.CompletedTask;
}

GetData();