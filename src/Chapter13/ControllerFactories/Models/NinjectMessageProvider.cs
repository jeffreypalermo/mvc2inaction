namespace ControllerFactories.Models
{
    public class NinjectMessageProvider : IMessageProvider
    {
        public string GetMessage()
        {
            return "This message was provided by Ninject";
        }
    }
}