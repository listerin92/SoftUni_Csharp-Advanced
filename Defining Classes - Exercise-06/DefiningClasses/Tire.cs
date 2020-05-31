using System;

namespace DefiningClasses
{
    public class Tire
    {
        private int _year;
        private double _pressure;

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
        public int Year { get; set; }

        public double Pressure
        {
            get => _pressure;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("No Pressure in the tire!");
                }
                _pressure = value;
            }

        }
    }
}