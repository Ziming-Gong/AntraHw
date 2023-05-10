using Microsoft.AspNetCore.Mvc;
using SenderAPI.Services;
using SenderAPI.Utility;
using SharedApp.Model;

namespace SenderAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly IQueueService _queueService;

    public NotificationController(IQueueService queueService)
    {
        _queueService = queueService;
    }
    [HttpPost]
    public async Task<IActionResult> CheckOut(Customer customer)
    {
        await _queueService.SendMessageAsync(customer, SharedResource.EmailNotificationQueue);
        return Ok("message has been sent");

    }
}