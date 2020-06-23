using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAtelierAuto
{
    class Atelier
    {
        public const string nume = "Auto Shop";
        public List<Angajat> listaAngajati=new List<Angajat>();
        public int[,] matriceAtelier; // o matrice cu 5 coloane: primele 3 coloane indica locurile disponibile pentru masini standard ale unui angajat; coloana a patra indica locul disponibil pentru autobuz; ultima coloana indica locul disponibil pentru camion; m[i][j] = id-ul masinii de care se ocupa angajatul cu id-ul i+1 sau 0 daca locul este disponibil
        public bool deschis;
        public Queue<Masina> masiniAsteptare;
        
        public Atelier()
        {
            listaAngajati = null;
            matriceAtelier = null;
            deschis = false;
            masiniAsteptare = null;
        }

        public Atelier(List<Angajat> lista)
        {
            List<Angajat> listaAngajati = new List<Angajat>();
            listaAngajati = lista;
            matriceAtelier = new int[listaAngajati.Count, 5];
            if(listaAngajati.Count>=1)
            {
                deschis = true;
            }
            else
            {
                deschis = false;
            }
            masiniAsteptare = new Queue<Masina>();
        }

        public int atribuireMasina(Masina m, int idAngajat, bool masina, bool autobuz, bool camion)
        {
            if (m != null)
            {
                int ok = 0;
                if (masina)
                {
                    for (int i = 0; i < listaAngajati.Count; i++)
                        for (int j = 0; j < 3; j++)
                            if (matriceAtelier[i, j] == 0)
                            {
                                ok = 1;
                                break;
                            }
                }
                else if (autobuz)
                {
                    for (int i = 0; i < listaAngajati.Count; i++)
                        if (matriceAtelier[i, 3] == 0)
                        {
                            ok = 1;
                            break;
                        }
                }
                else if (camion)
                {
                    for (int i = 0; i < listaAngajati.Count; i++)
                        if (matriceAtelier[i, 4] == 0)
                        {
                            ok = 1;
                            break;
                        }
                }
                if (ok == 0)
                {
                    string raspuns = "0";
                    Console.WriteLine("Niciun angajat disponibil! Alegeti un numar:\n1.Asteapta\n2.Pleaca");
                    while (raspuns != "1" && raspuns != "2")
                    {
                        raspuns = Console.ReadLine();
                        if (raspuns != "1" && raspuns != "2")
                        {
                            Console.WriteLine("Raspuns invalid. Reincercati!");
                        }
                        else if (raspuns == "1")
                        {
                            masiniAsteptare.Enqueue(m);
                            return 1;
                        }
                        else if (raspuns == "2")
                        {
                            return -1;
                        }
                    }
                    return -1;
                }
                else
                {
                    if (m.Id <= 0 || idAngajat <= 0 || idAngajat > listaAngajati.Count)
                    {
                        Console.WriteLine("Atribuire imposibila. Revizuiti datele!");
                        return -1;
                    }
                    if (masina)
                    {
                        if (matriceAtelier[idAngajat - 1, 0] == 0)
                        {
                            matriceAtelier[idAngajat - 1, 0] = m.Id;
                            return 1;
                        }
                        else if (matriceAtelier[idAngajat - 1, 1] == 0)
                        {
                            matriceAtelier[idAngajat - 1, 1] = m.Id;
                            return 1;
                        }
                        else if (matriceAtelier[idAngajat - 1, 2] == 0)
                        {
                            matriceAtelier[idAngajat - 1, 2] = m.Id;
                            return 1;
                        }
                        else
                        {
                            string raspuns = "0";
                            Console.WriteLine("Angajat ocupat! Alegeti un numar:/n1.Asteapta/n2.Treci la un angajat liber/n3.Pleaca");
                            while (raspuns != "1" && raspuns != "2" && raspuns != "3")
                            {
                                raspuns = Console.ReadLine();
                                if (raspuns != "1" && raspuns != "2" && raspuns != "3")
                                {
                                    Console.WriteLine("Raspuns invalid. Reincercati!");
                                }
                                else if (raspuns == "1")
                                {
                                    masiniAsteptare.Enqueue(m);
                                    return -1;
                                }
                                else if (raspuns == "2")
                                {
                                    foreach (Angajat a in listaAngajati)
                                    {
                                        if (matriceAtelier[a.Id - 1, 0] == 0)
                                        {
                                            matriceAtelier[a.Id - 1, 0] = m.Id;
                                            return 1;
                                        }
                                        else if (matriceAtelier[a.Id - 1, 1] == 0)
                                        {
                                            matriceAtelier[a.Id - 1, 1] = m.Id;
                                            return 1;
                                        }
                                        else if (matriceAtelier[a.Id - 1, 2] == 0)
                                        {
                                            matriceAtelier[a.Id - 1, 2] = m.Id;
                                            return 1;
                                        }
                                        else
                                            ;
                                    }
                                }
                                else if (raspuns == "3")
                                {
                                    return -1; ;
                                }
                            }
                            return -1;

                        }
                    }
                    else if (autobuz)
                    {
                        if (matriceAtelier[idAngajat - 1, 3] == 0)
                        {

                            matriceAtelier[idAngajat - 1, 3] = m.Id;
                            return 1;
                        }
                        else
                        {
                            string raspuns = "0";
                            Console.WriteLine("Angajat ocupat! Alegeti un numar:/n1.Asteapta/n2.Treci la un angajat liber/n3.Pleaca");
                            while (raspuns != "1" && raspuns != "2" && raspuns != "3")
                            {
                                raspuns = Console.ReadLine();
                                if (raspuns != "1" && raspuns != "2" && raspuns != "3")
                                {
                                    Console.WriteLine("Raspuns invalid. Reincercati!");
                                }
                                else if (raspuns == "1")
                                {
                                    masiniAsteptare.Enqueue(m);
                                    return -1;
                                }
                                else if (raspuns == "2")
                                {
                                    foreach (Angajat a in listaAngajati)
                                    {
                                        if (matriceAtelier[a.Id - 1, 3] == 0)
                                        {
                                            matriceAtelier[a.Id - 1, 0] = m.Id;
                                            return 1;
                                        }
                                        else
                                            ;
                                    }
                                }
                                else if (raspuns == "3")
                                {
                                    return -1; ;
                                }
                            }
                            return -1;

                        }
                    }
                    else if (camion)
                    {
                        if (matriceAtelier[idAngajat - 1, 4] == 0)
                        {
                            matriceAtelier[idAngajat - 1, 4] = m.Id;
                            return 1;
                        }
                        else
                        {
                            string raspuns = "0";
                            Console.WriteLine("Angajat ocupat! Alegeti un numar:/n1.Asteapta/n2.Treci la un angajat liber/n3.Pleaca");
                            while (raspuns != "1" && raspuns != "2" && raspuns != "3")
                            {
                                raspuns = Console.ReadLine();
                                if (raspuns != "1" && raspuns != "2" && raspuns != "3")
                                {
                                    Console.WriteLine("Raspuns invalid. Reincercati!");
                                }
                                else if (raspuns == "1")
                                {
                                    masiniAsteptare.Enqueue(m);
                                    return -1;
                                }
                                else if (raspuns == "2")
                                {
                                    foreach (Angajat a in listaAngajati)
                                    {
                                        if (matriceAtelier[a.Id - 1, 4] == 0)
                                        {
                                            matriceAtelier[a.Id - 1, 4] = m.Id;
                                            return 1;
                                        }
                                        else
                                            ;
                                    }
                                }
                                else if (raspuns == "3")
                                {
                                    return -1; ;
                                }
                            }
                            return -1;
                        }
                    }
                    else
                        return -1;
                }
            }
            else return -1;
        }

        public void atribuireMasinaCoada(int idAngajat)
        {
            if (masiniAsteptare.Count != 0)
            {
                Masina m = masiniAsteptare.Dequeue();
                if (m is MasinaStandard)
                {
                    atribuireMasina(m, idAngajat, true, false, false);
                }
                else if (m is Autobuz)
                {
                    atribuireMasina(m, idAngajat, false, true, false);
                }
                else if (m is Camion)
                {
                    atribuireMasina(m, idAngajat, false, false, true);
                }
            }
            else
                Console.WriteLine("Nicio masina in lista de asteptare!\n\n");
        }

        public void eliberareLoc(int id)
        {
            for(int i=0;i<listaAngajati.Count;i++)
            {
                for(int j=0;j<5;j++)
                {
                    if(matriceAtelier[i,j]==id)
                    {
                        matriceAtelier[i, j] = 0;
                        break;
                    }
                }
            }
        }

        public int numarMasiniInReparatie()
        {
            int nr = 0;
            for (int i = 0; i < listaAngajati.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matriceAtelier[i, j] != 0)
                    {
                        nr++;
                    }
                }
            }
            return nr;
        }

        public void afisareCoada()
        {
            foreach(Masina m in masiniAsteptare)
            {
                m.afisareMasina();
            }
        }

        public void afisareMatrice()
        {
            for(int i=0;i<listaAngajati.Count;i++)
            {
                for(int j=0;j<5;j++)
                {
                    Console.Write(matriceAtelier[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void adaugareAngajat(Angajat a)
        {
            if (a != null)
            {
                listaAngajati.Add(a);
                int[,] rezultat = new int[matriceAtelier.GetLength(0) + 1, matriceAtelier.GetLength(1)];
                for (int i = 0; i < matriceAtelier.GetLength(0); i++)
                {
                    for (int j = 0; j < matriceAtelier.GetLength(1); j++)
                        rezultat[i, j] = matriceAtelier[i, j];
                }
                matriceAtelier = rezultat;
            }
        }

        public void stergereLinieMatrice(int linie)
        {
                int[,] rezultat = new int[matriceAtelier.GetLength(0) - 1, matriceAtelier.GetLength(1)];
                int k = 0;
                for (int i = 0; i < matriceAtelier.GetLength(0); i++)
                {
                    if (i == linie)
                        continue;
                    else
                        for (int j = 0; j < matriceAtelier.GetLength(1); j++)
                        {
                            rezultat[k, j] = matriceAtelier[i, j];
                        }
                    k++;
                }
                matriceAtelier = rezultat;         
        }

        public int stergereAngajat(int idAngajat)
        {
            if (idAngajat < 1 || idAngajat > listaAngajati.Count)
            {
                Console.WriteLine("Stergere imposibila. Revizuiti datele!");
                return -1;
            }
            int count= 0;
            for(int i=0;i<5;i++)
            {
                if (matriceAtelier[idAngajat-1, i] != 0)
                    count++;
            }
            if(count !=0)
            {
                Console.WriteLine("Stergere imposibila. Angajatul are activitati in desfasurare!");
                return -1;
            }
            else
            {
                if (idAngajat == 1 && listaAngajati.Count == 1)
                {
                    listaAngajati = new List<Angajat>();
                    matriceAtelier = new int[0,5];
                }
                else
                {
                    for (int i = 0; i < listaAngajati.Count; i++)
                    {
                        if (listaAngajati[i].Id == idAngajat)
                        {
                            for (int j = i; j < listaAngajati.Count; j++)
                                listaAngajati[j].Id -= 1;
                            stergereLinieMatrice(listaAngajati[i].Id);
                            listaAngajati[i].Index--;
                            listaAngajati.Remove(listaAngajati[i]);
                            break;
                        }
                    }
                }
                return 1;
            }
        }

        public void afisareAngajati()
        {
            for (int i = 0; i < listaAngajati.Count; i++)
                listaAngajati[i].afisareAngajat();
            Console.WriteLine("\n\n");
        }

        public int numarAngajati()
        {
            return listaAngajati.Count();
        }

        public bool statusAtelier()
        {
            if (numarAngajati() == 0)
                return false;
            else
                return true;
        }

        public void afisareAngajatiMasini()
        {

            for (int i = 0; i < matriceAtelier.GetLength(0); i++)
            {
                Console.WriteLine("Id angajat: " + listaAngajati[i].Id);
                for (int j = 0; j < matriceAtelier.GetLength(1); j++)
                {
                    if (matriceAtelier[i, j] != 0)
                    {
                        Console.WriteLine("-->Id masina: " + matriceAtelier[i, j]);
                    }
                }
            }
            Console.WriteLine("\n\n");
            
        }
    }
}
