namespace ComplexRoutes.Models
{
    public class Widget
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public Widget(string code)
        {
            Code = code;
        }
    }
}
