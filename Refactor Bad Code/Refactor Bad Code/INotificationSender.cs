namespace Refactor_Bad_Code
{
    public interface INotificationSender
    {
        public string Type { get; }
        void SendNotification(User user);
    }
}
