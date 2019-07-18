using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalNotificationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = OneSignalNotificationService.GetInstance();

            var heading = "Header";
            var contents = "Your message contents";

            //For specific devices 
            var devicesList = new List<string> { "User1 Device Id", "User2 Device Id" };

            //For All devices
            //var devicesList = new List<string> { "All" };

            var result = service.CreateNotification(heading, contents, devicesList);

            //Delivery Id
            Console.WriteLine(result.Id);

            //Recipients count
            Console.WriteLine(result.Recipients);

            Console.ReadKey();
        }
    }
}
