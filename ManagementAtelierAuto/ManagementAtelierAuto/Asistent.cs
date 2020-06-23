using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAtelierAuto
{
    class Asistent:Angajat
    {
        public Asistent() : base()
        {
            coeficient = 1;
        }

        public Asistent(string n, string p, DateTime dataN, DateTime dataA) : base(n, p, dataN, dataA)
        {
            coeficient = 1;
        }

        public override string ToString()
        {
            return base.ToString() + "functie: asistent, salariu: " + this.calculareSalariu();
        }
    }
}
