using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAtelierAuto
{
    class Autobuz : Masina
    {
        private int nrLocuri;

        public Autobuz(int i, double n, int an, bool motor, int nr) : base(i, n, an, motor)
        {
            nrLocuri = nr;
        }

        public Autobuz()
        {
        }

        public override float CalcularePolitaAsigurare(bool discount)
        {
            float polita = base.CalcularePolitaAsigurare(discount) * 200;
            if (MotorDiesel)
            {
                polita += 1000;
            }
            if (NrKm > 200000)
            {
                polita += 1000;
            }
            else if (NrKm>100000)
            {
                polita += 500;
            }
            if (discount)
                polita = 0.9f * polita;
            return polita;
        }

        public override string ToString()
        {
            return base.ToString() + " numar locuri: " + nrLocuri;
        }

        public Autobuz citireAutobuzTastatura(Queue<Masina> coadaAsteptare)
        {
            int id = 0;
            Console.Write("Introduceti id-ul masinii: ");
            string idCitit = Console.ReadLine();
            if (int.TryParse(idCitit, out id))
            {
                int ok = 1;
                if (coadaAsteptare.Count > 0)
                {
                    foreach (Masina m in coadaAsteptare)
                    {
                        if (id == m.Id)
                        {
                            ok = 0;
                            break;
                        }
                    }
                }
                if (id > 0 && ok == 1)
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
                                    int nrLoc;
                                    Console.Write("Introduceti numarul de locuri: ");
                                    string nrLocCitit = Console.ReadLine();
                                    if (int.TryParse(nrLocCitit, out nrLoc))
                                    {
                                        if(nrLoc>0&&nrLoc<=60)
                                        {
                                            Autobuz a = new Autobuz(id, nrKm, an, diesel, nrLoc);
                                            return a;
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
