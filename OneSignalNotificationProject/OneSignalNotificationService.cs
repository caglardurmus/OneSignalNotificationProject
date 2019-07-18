using OneSignal.CSharp.SDK;
using OneSignal.CSharp.SDK.Resources;
using OneSignal.CSharp.SDK.Resources.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalNotificationProject
{
    public class OneSignalNotificationService
    {
        //You can find this ids from your OneSignal account detail.
        private string OneSignalId = "Your OneSignal Id";
        private string ApiId = "Your Api Id";

        private NotificationCreateOptions _notificationCreateOptions;
        private OneSignalClient _oneSignalClient;

        private OneSignalNotificationService()
        {
            _oneSignalClient = new OneSignalClient(OneSignalId);

            _notificationCreateOptions = new NotificationCreateOptions();
            _notificationCreateOptions.AppId = Guid.Parse(this.ApiId);
        }

        /// <summary>
        /// Method for send notification to devices
        /// </summary>
        /// <param name="heading">Notification Title Text</param>
        /// <param name="contents">Notification Content Text</param>
        /// <param name="devices">List of devices</param>
        /// <returns>Delivery Id and Recipients count</returns>
        public NotificationCreateResult CreateNotification(string heading, string contents, List<string> devices)
        {
            if (devices.Contains("All"))
            {
                _notificationCreateOptions.IncludedSegments = new List<string> { "All" };
            }
            else
            {
                _notificationCreateOptions.IncludePlayerIds = devices;
            }

            _notificationCreateOptions.Headings.Add(LanguageCodes.English, heading);
            _notificationCreateOptions.Contents.Add(LanguageCodes.English, contents);

            return _oneSignalClient.Notifications.Create(_notificationCreateOptions);
        }

        /// <summary>
        /// Method for the get instance of service with singleton pattern
        /// </summary>
        public static OneSignalNotificationService GetInstance()
        {
            if (_oneSignalService == null)
            {
                _oneSignalService = new OneSignalNotificationService();
            }
            return _oneSignalService;
        }

        private static OneSignalNotificationService _oneSignalService;
    }
}
