using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    public class Cargo
    {
        public Cargo()
        {
            this.CargoWeight = 0;
            this.CargoType = "";
        }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
