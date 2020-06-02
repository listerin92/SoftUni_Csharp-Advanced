
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>(capacity);
        }

 

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {

            if (this.cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return new string("Car with that registration number, already exists!");
            }
            else if (this.cars.Count >= this.capacity)
            {
                return new string("Parking is full!");
            }
            else
            {
                this.cars.Add(car);
                return new string($"Successfully added new car {car.Make} {car.RegistrationNumber}");
            }

        }

        public Car GetCar(string registrationNumber)
        {

            return  this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                this.cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);
            }

        }

        public string RemoveCar(string registrationNumber)
        {
            if (this.cars.Any(c => c.RegistrationNumber != registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                this.cars.Remove(this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber));

                return $"Successfully removed {registrationNumber}";
            }
        }
    }
}
