namespace ControllerFactories.Models
{
    public class StructureMapMessageProvider : IMessageProvider
    {
        public string GetMessage()
        {
            return "This message was provided by StructureMap";
        }
    }
}