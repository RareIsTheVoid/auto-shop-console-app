using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAtelierAuto
{
    class Director : Angajat
    {
        public Director() : base()
        {
            coeficient = 2;
        }

        public Director(string n, string p, DateTime dataN, DateTime dataA) : base(n, p, dataN, dataA)
        {
            coeficient = 2;
        }

        public override string ToString()
        {
            return base.ToString() + "functie: director, salariu: "+ this.calculareSalariu();
        }
    }
}
