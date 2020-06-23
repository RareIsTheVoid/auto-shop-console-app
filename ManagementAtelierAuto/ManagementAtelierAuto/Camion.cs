using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAtelierAuto
{
    class Camion : Masina
    {
        private float tonaj;

        public Camion(int i, double n, int an, bool motor, float t) : base(i, n, an, motor)
        {
            tonaj = t;
        }

        public Camion()
        {
        }

        public override float CalcularePolitaAsigurare(bool discount)
        {
            float polita = base.CalcularePolitaAsigurare(discount) * 300;
            if (NrKm > 800000)
            {
                polita += 700;
            }
            if (discount)
                polita = 0.85f * polita;
            return polita;
        }

        public override string ToString()
        {
            return base.ToString() + "tonaj: " + tonaj;
        }

        public Camion citireAutobuzTastatura(Queue<Masina> coadaAsteptare)
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
                                    int tonaj;
                                    Console.Write("Introduceti tonajul: ");
                                    string tonajCitit = Console.ReadLine();
                                    if (int.TryParse(tonajCitit, out tonaj))
                                    {
                                        if (tonaj > 0 && tonaj <= 60)
                                        {
                                            Camion c = new Camion(id, nrKm, an, diesel, tonaj);
                                            return c;
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
