
using ApplicationCore.Entities;
using Infrastructure.Services;
using Week3Day1HW.Menu;

namespace Week3Day1HW;

public class Program
{
    public static void Main()
    {
        MenuSelection ms = new MenuSelection();
        ms.Run();
    }
}
