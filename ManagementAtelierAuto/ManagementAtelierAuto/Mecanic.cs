using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAtelierAuto
{
    class Mecanic: Angajat
    {
        public Mecanic() : base()
        {
            coeficient = 1.5f;
        }

        public Mecanic(string n, string p, DateTime dataN, DateTime dataA) : base(n, p, dataN, dataA)
        {
            coeficient = 1.5f;
        }

        public override string ToString()
        {
            return base.ToString() + "functie: mecanic, salariu: " + this.calculareSalariu();
        }
    }
}
