using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAtelierAuto
{
    abstract class Angajat
    {
        const int lungimeMaxString = 30;
        
        private static int index=0;
        private int id=0;
        private string nume;
        private string prenume;
        private DateTime dataNasterii;
        private DateTime dataAngajarii;
        public float coeficient;

        public Angajat()
        {
            nume = null;
            prenume = null;
            dataNasterii = DateTime.MinValue;
            dataAngajarii = DateTime.MinValue;
            coeficient = 0;
        }

        public Angajat(string n, string p, DateTime dataN, DateTime dataA)
        {
            ++index;
            id = index;
            if (n.Length > lungimeMaxString)
                nume = n.Substring(0, lungimeMaxString);
            else
                nume = n;
            if (n.Length > lungimeMaxString)
                prenume = p.Substring(0, lungimeMaxString);
            else
                prenume = p;
            dataNasterii = dataN;
            dataAngajarii = dataA;
        }

        public override string ToString()
        {
            return "-> ID: " + id + ", nume: " + nume + ", prenume: " + prenume + ", data nasterii: " + dataNasterii.ToShortDateString() + ", data angajarii: " + dataAngajarii.ToShortDateString() + ", ";
        }

        public int calculareVarsta(DateTime data)
        {
            int varsta = data.Year - dataNasterii.Year;
            if (data.Month < dataNasterii.Month || (data.Month == dataNasterii.Month && data.Day < dataNasterii.Day))
                varsta--;

            return varsta;
        }

        public int calculareVarsta(DateTime dataN, DateTime dataA)
        {
            int varsta = dataA.Year - dataN.Year;
            if (dataA.Month < dataN.Month || (dataA.Month == dataN.Month && dataA.Day < dataN.Day))
                varsta--;

            return varsta;
        }

        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                if (value != null && !value.Any(Char.IsDigit))
                    if (value.Length <= lungimeMaxString)
                        nume = value;
                    else
                        nume = value.Substring(0, lungimeMaxString);
                else
                    Console.WriteLine("Nume invalid! Prenumele nu a fost modificat!\n\n");
            }
        }

        public string Prenume
        {
            get
            {
                return prenume;
            }
            set
            {
                if (value != null && !value.Any(Char.IsDigit))
                    if (value.Length <= lungimeMaxString)
                        prenume = value;
                    else
                        prenume = value.Substring(0, lungimeMaxString);
                else
                    Console.WriteLine("Prenume invalid! Prenumele nu a fost modificat!\n\n");
            }
        }

        public DateTime DataNasterii
        {
            get
            {
                return dataNasterii;
            }
            set
            {
                if(this.calculareVarsta(value)>=18&&DateTime.Compare(value, DataAngajarii)<0)
                    dataNasterii = value;
                else
                    Console.WriteLine("Angajatul nu a implinit 18 ani la varsta angajarii. Data nu a fost modificata!\n\n");
            }
        }

        public DateTime DataAngajarii
        {
            get
            {
                return dataAngajarii;
            }
            set
            {
                if (this.calculareVarsta(value) >= 18&&DateTime.Compare(DataNasterii, value)< 0)
                    dataAngajarii = value;
                else
                    Console.WriteLine("Angajatul nu a implinit 18 ani la varsta angajarii. Data nu a fost modificata!\n\n");
            }
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

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                if (value >= 1)
                {
                    index = value;
                }
            }
        }

        public void editareAngajat()
        {
            string raspuns = "0";
            Console.Write("Ce doriti sa editati? Alegeti un numar:\n1. Numele\n2. Prenumele\n3. Data nasterii\n4. Data angajarii\n5. Anulare\n\nRaspunsul dvs.: ");
            while (raspuns != "1" && raspuns != "2" && raspuns != "3" && raspuns != "4" && raspuns != "5")
            {
                raspuns = Console.ReadLine();
                Console.Clear();
                if (raspuns != "1" && raspuns != "2" && raspuns != "3" && raspuns != "4" && raspuns != "5")
                {
                    Console.Write("Raspuns invalid. Reincercati!\n\nAlegeti un numar:\n1. Numele\n2. Prenumele\n3. Data nasterii\n4. Data angajarii\n5. Anulare\n\nRaspunsul dvs.: ");
                }
                else if (raspuns == "1")
                {
                    string numeNou;
                    Console.Write("Nume curent: " + Nume + ". Introduceti noul nume: ");
                    numeNou = Console.ReadLine();
                    Nume = numeNou;
                    break;
                }
                else if (raspuns == "2")
                {
                    string prenumeNou;
                    Console.Write("Prenume curent: " + Prenume + ". Introduceti noul prenume: ");
                    prenumeNou = Console.ReadLine();
                    Prenume = prenumeNou;
                    break;
                }
                else if (raspuns == "3")
                {
                    string dataCitita;
                    DateTime dataNoua=DateTime.MinValue;
                    Console.Write("Data nasterii curenta: " + DataNasterii.ToShortDateString() + ". Introduceti noua data (format: DD-MM-YYYY):");
                    dataCitita = Console.ReadLine();
                    if (DateTime.TryParseExact(dataCitita, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dataNoua))
                        if(DateTime.Compare(dataNoua, DateTime.Today) < 0)
                        {
                            this.DataNasterii = dataNoua;
                        }
                        else
                        {
                            Console.WriteLine("Data invalida!");
                        }
                    else
                    {
                        Console.WriteLine("Data invalida!");
                    }
                    break;
                }
                else if (raspuns == "4")
                {
                    string dataCitita;
                    DateTime dataNoua = DateTime.MinValue;
                    Console.Write("Data angajarii curenta: " + DataAngajarii.ToShortDateString() + ". Introduceti noua data (format: DD-MM-YYYY):");
                    dataCitita = Console.ReadLine();
                    if (DateTime.TryParseExact(dataCitita, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dataNoua))
                        if (DateTime.Compare(dataNoua, DateTime.Today) < 0)
                        {
                            this.DataAngajarii = dataNoua;
                        }
                        else
                        {
                            Console.WriteLine("Data invalida!");
                        }
                    else
                    {
                        Console.WriteLine("Data invalida!");
                    }
                    break;
                }
                else if (raspuns == "5")
                {
                    break;
                }
                Console.Write("Raspunsul dvs.: ");
            }
            Console.WriteLine("Editare finalizata!");

        }

        public float calculareSalariu()
        {
            return (float)(DateTime.Today.Year-dataAngajarii.Year>0?DateTime.Today.Year-dataAngajarii.Year:1) * coeficient * 1000;
        }

        public void afisareAngajat()
        {
            Console.WriteLine(this.ToString());
        }

        public Angajat citireAngajatTastatura(bool director, bool mecanic, bool asistent)
        {
            Console.Write("Introduceti numele: ");
            string numeA = Console.ReadLine();
            if (numeA != null && !numeA.Any(Char.IsDigit))
            {
                if (numeA.Length > lungimeMaxString)
                    numeA = numeA.Substring(0, lungimeMaxString);
                Console.Write("Introduceti prenumele: ");
                string prenumeA = Console.ReadLine();
                if (prenumeA != null && !prenumeA.Any(Char.IsDigit))
                {
                    if (numeA.Length > lungimeMaxString)
                        numeA = numeA.Substring(0, lungimeMaxString);
                    Console.Write("Introduceti data nasterii (format: DD-MM-YYYY): ");
                    DateTime dataNA;
                    string dataCitita = Console.ReadLine();
                    if (DateTime.TryParseExact(dataCitita, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dataNA))
                    {
                        if (DateTime.Compare(dataNA, DateTime.Today) < 0)
                        {
                            Console.Write("Introduceti data angajarii (format: DD-MM-YYYY): ");
                            DateTime dataAA;
                            dataCitita = Console.ReadLine();
                            if (DateTime.TryParseExact(dataCitita, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dataAA))
                            {
                                if (DateTime.Compare(dataAA, DateTime.Today) < 0&&calculareVarsta(dataNA,dataAA)>=18)
                                {
                                    if (director)
                                    {
                                        Director d=new Director(numeA, prenumeA, dataNA, dataAA);
                                        return (Director)d;
                                    }
                                    else if (mecanic)
                                    {
                                        Mecanic m = new Mecanic(numeA, prenumeA, dataNA, dataAA);
                                        return (Mecanic)m;
                                    }
                                    else if(asistent)
                                    {
                                        Asistent a = new Asistent(numeA, prenumeA, dataNA, dataAA);
                                        return (Asistent)a;
                                    }
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
