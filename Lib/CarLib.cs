using System;
using System.IO;

namespace CarLib
{
    class Car
    {
        private string plate;
        public string Plate
        {
            get { return plate; }
            set { plate = value; }
        }
        
        public Car(string pl)
        {
            plate = pl;
        }

        public Car()
            : this(string.Empty){}
    }
}
