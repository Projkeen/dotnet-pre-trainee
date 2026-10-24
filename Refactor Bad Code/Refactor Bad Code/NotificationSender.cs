namespace Refactor_Bad_Code
{
    public class EmailNotificationSender : INotificationSender
    {
        public string Type { get; } = "email";
        public void SendNotification(User user) => Console.WriteLine($"Sending EMAIL to {user.Email}: Welcome, {user.Name}!");
    }

    public class SmsNotificationSender : INotificationSender
    {
        public string Type { get; } = "sms";
        public void SendNotification(User user) => Console.WriteLine($"Sending SMS to user {user.Name}: Welcome!");
    }

    public class PushNotificationSender : INotificationSender
    {
        public string Type { get; } = "push";
        public void SendNotification(User user) => Console.WriteLine($"Sending PUSH notification to {user.Name}");
    }
}
