namespace ControllerFactories.Models
{
    public class WindsorMessageProvider : IMessageProvider
    {
        public string GetMessage()
        {
            return "This message was provided by Windsor";
        }
    }
}