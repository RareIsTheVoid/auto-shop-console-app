using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAtelierAuto
{
    class Masina
    {
        private int id;
        private double nrKm;
        private int anFabricatie;
        private bool motorDiesel;

        public Masina()
        {
            id = -1;
            nrKm = 0;
            anFabricatie = 0;
            motorDiesel = false;
        }

        public Masina(int i, double n, int an, bool motor)
        {
            id = i;
            nrKm = n;
            anFabricatie = an;
            motorDiesel = motor;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value >= 1)
                {
                    id = value;
                }
            }
        }

        public virtual float CalcularePolitaAsigurare(bool discount)
        {
            int anCurent = DateTime.Today.Year;
            return anCurent-anFabricatie;
        }

        public bool MotorDiesel
        {
            get
            {
                return motorDiesel;
            }
            set
            {
                if (value != motorDiesel)
                    motorDiesel = value;
            }
        }

        public double NrKm
        {
            get
            {
                return nrKm;
            }
            set
            {
                if (value >= 0)
                    nrKm = value;
                else
                    Console.WriteLine("Numar invalid!");
            }
        }

        public override string ToString()
        {
            return "Id: " + id + ", numar Km: " + nrKm + ", an fabricatie: " +anFabricatie+ ", motor Diesel:" + (motorDiesel ? " da, " : " nu, ");
        }

        public void afisareMasina()
        {
            Console.WriteLine(this.ToString());
        }


    }
}
