using System.Text;
using Microsoft.Azure.ServiceBus;
// using Newtonsoft.Json;
using System.Text.Json;

namespace SenderAPI.Services;



public class QueueService : IQueueService
{
    private readonly IConfiguration _config;

    public QueueService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendMessageAsync<T>(T serviceBusMessage, string queueName)
    {
        QueueClient queueClient = new QueueClient(_config.GetConnectionString("EmailNotificationServiceBus"), queueName);
        string jsonMessage = JsonSerializer.Serialize(serviceBusMessage);
        Message message = new Message(Encoding.UTF8.GetBytes(jsonMessage));
        await queueClient.SendAsync(message);
    }
    
}