namespace CarManufacturer
{
    public class Engine
    {
        private int _horsePower;
        private double _cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
        public int HorsePower
        {
            get
            {
                return this._horsePower;
            }
            set
            {
                this._horsePower = value;
            }
        }

        public double CubicCapacity
        {
            get
            {
                return this._cubicCapacity;
            }
            set
            {
                this._cubicCapacity = value;
            }
        }
    }
}