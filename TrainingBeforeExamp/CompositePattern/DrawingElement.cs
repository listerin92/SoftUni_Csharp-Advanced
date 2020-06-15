namespace CompositePattern
{
    /// <summary>
    /// The 'Component' Treenode
    /// </summary>

    abstract class DrawingElement

    {
        protected string Name;

        // Constructor

        protected DrawingElement(string name)
        {
            this.Name = name;
        }

        public abstract void Add(DrawingElement d);
        public abstract void Remove(DrawingElement d);
        public abstract void Display(int indent);
    }
}
