namespace CarManufacturer
{
    public class Engine
    {
        private int _horsePower;
        private int _engineSpeed;

        public Engine(int engineSpeed, int horsePower)
        {
            this.HorsePower = horsePower;
            this.EngineSpeed = engineSpeed;
        }
        public int EngineSpeed
        {
            get
            {
                return this._engineSpeed;
            }
            set
            {
                this._engineSpeed = value;
            }
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
    }
}