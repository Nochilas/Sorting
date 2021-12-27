using System;
using System.IO;
using System.Collections;

namespace CarLib
{
    class Car : IComparer
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

        int IComparer.Compare(Object x, Object y)
        {
            return string.Compare(((x as Car).Plate), ((y as Car).Plate));
        }
    }
}
