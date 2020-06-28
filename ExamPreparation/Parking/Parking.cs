using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public Parking(string type, int capacity)
        {

            this.data = new List<Car>();
            this.Type = type;
            this.Capacity = capacity;
        }

        public void Add(Car car)
        {
            if (data.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var car = this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (car != null)
            {
              data.Remove(car);
                return true;
            }
            return false; // TOCheck
        }

        public Car GetLatestCar()
        {
            if (this.data.Count == 0)
            {
                return null;
            }
            Car car = this.data.OrderByDescending(x => x.Year).First(); // check for NULL
            return car;

        }

        public Car GetCar(string manufacturer, string model)
        {
           return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in data)
            {
                sb.AppendLine($"{car}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
