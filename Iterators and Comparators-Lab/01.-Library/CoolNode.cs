namespace _01._Library
{
    public class CoolNode
    {
        public CoolNode(object value)
        {
            this.Value = value;
        }

        public object Value { get; }
        public CoolNode Next { get; set; }
        public CoolNode Previous { get; set; }
    }
}
