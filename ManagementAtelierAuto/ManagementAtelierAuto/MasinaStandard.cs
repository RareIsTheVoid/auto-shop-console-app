using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAtelierAuto
{
    class MasinaStandard: Masina
    {
        private bool modTransmisie; // true = manual, false = automat

        public MasinaStandard(int i, double n, int an, bool motor, bool t) :base(i,n,an,motor)
        {
            modTransmisie = t;
        }

        public MasinaStandard()
        {
        }

        public override float CalcularePolitaAsigurare(bool discount)
        {
            float polita= base.CalcularePolitaAsigurare(discount)*100;
            if (MotorDiesel)
            {
                polita += 500;
            }
            if (NrKm>200000)
            {
                polita += 500;
            }
            if (discount)
                polita = 0.95f * polita;
            return polita;
        }

        public override string ToString()
        {
            return base.ToString() + "mod transmisie: " + (modTransmisie ? "manual" : "automat");
        }

        public MasinaStandard citireMasinaStandardTastatura(Queue<Masina> coadaAsteptare)
        {
            int id = 0;
            Console.Write("Introduceti id-ul masinii: ");
            string idCitit = Console.ReadLine();
            if (int.TryParse(idCitit, out id))
            {
                int ok = 1;
                if(coadaAsteptare.Count>0)
                {
                    foreach(Masina m in coadaAsteptare)
                    {
                        if(id==m.Id)
                        {
                            ok = 0;
                            break;
                        }
                    }
                }
                if (id > 0&& ok==1)
                {
                    double nrKm;
                    Console.Write("Introduceti numarul de km parcursi de masina: ");
                    string nrKmCitit = Console.ReadLine();
                    if (double.TryParse(nrKmCitit, out nrKm))
                    {
                        if (nrKm >= 0)
                        {
                            int an;
                            Console.Write("Introduceti anul fabricatiei: ");
                            string anCitit = Console.ReadLine(); 
                            if (int.TryParse(anCitit, out an))
                            {
                                if (an >= 1900 && an <= DateTime.Today.Year)
                                {
                                    bool diesel;
                                    Console.Write("Motorul masinii este Diesel? Alegeti un numar:\n1. Da\n2. Nu\nRaspunsul dvs: ");
                                    string dieselCitit = Console.ReadLine();
                                    if (dieselCitit == "1")
                                    {
                                        diesel = true;
                                    }
                                    else if (dieselCitit == "2")
                                    {
                                        diesel = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Raspuns invalid");
                                        return null;
                                    }
                                    bool transmisie;
                                    Console.Write("Ce mod de transmisie are masina? Alegeti un numar:\n1. Manual\n2. Automat\nRaspunsul dvs: ");
                                    string transCitit = Console.ReadLine();
                                    if (transCitit == "1")
                                    {
                                        transmisie = true;
                                    }
                                    else if (transCitit == "2")
                                    {
                                        transmisie = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Raspuns invalid");
                                        return null;
                                    }
                                    MasinaStandard m = new MasinaStandard(id, nrKm, an, diesel, transmisie);
                                    return m;
                                }
                                else
                                    Console.WriteLine("Raspuns invalid!");
                                return null;
                            }
                            else
                                Console.WriteLine("Raspuns invalid!");
                            return null;
                        }
                        else
                            Console.WriteLine("Raspuns invalid!");
                        return null;
                    }
                    else
                        Console.WriteLine("Raspuns invalid!");
                    return null;
                }
                else
                    Console.WriteLine("Raspuns invalid!");
                return null;
            }
            else
                Console.WriteLine("Raspuns invalid!");
            return null;
        }
    }
}
