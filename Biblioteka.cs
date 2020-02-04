using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BibliotekaPPO
{
    [Serializable]
    public class Biblioteka : IBiblioteka
    {
        private string nazwa;
        private string adres;
        private List<Ksiazka> listaksiazek;
        private int iloscKsiazek;
        private List<Wypozyczenie> listawypozyczen;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Adres { get => adres; set => adres = value; }
        public List<Ksiazka> Listaksiazek { get => listaksiazek; set => listaksiazek = value; }
        public int IloscKsiazek { get => iloscKsiazek; set => iloscKsiazek = value; }
        public List<Wypozyczenie> Listawypozyczen { get => listawypozyczen; set => listawypozyczen = value; }

        public Biblioteka()
        {
            nazwa = null;
            adres = null;
            Listaksiazek = new List<Ksiazka>();
            iloscKsiazek = 0;
            this.listawypozyczen = new List<Wypozyczenie>();

        }
        public Biblioteka(string n, string a) : this()
        {
            nazwa = n;
            adres = a;

        }
        public void DodajKsiazke(Ksiazka k)
        {
            Listaksiazek.Add(k);
            IloscKsiazek++;
        }
        public Ksiazka UsunKsiazke(int kod)
        {
            Ksiazka k = new Ksiazka();
            foreach (Ksiazka element in Listaksiazek)
            {
                if (element.KodKsiazki == kod)
                {
                    Listaksiazek.Remove(element);
                    return element;
                }

            }
            return k;
        }
        public List<Ksiazka> Filtruj(string r)
        {
            List<Ksiazka> lista = new List<Ksiazka>();
            foreach (Ksiazka element in Listaksiazek)
            {
                if (element.Autor == r)
                {
                    lista.Add(element);
                }
                else if (element.Nazwa == r)
                {
                    lista.Add(element);
                }
            }
            return lista;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"Aktualny stan biblioteki: {nazwa}");
            sb.AppendLine($"Ilość książek: {IloscKsiazek}");

            sb.AppendLine("Lista książek:");
            sb.AppendLine("______________________________________________________________________");
            int i = 0;
            foreach (Ksiazka p in Listaksiazek)
            {

                sb.AppendLine($"Książka NR.: {++i}");
                sb.AppendLine(p.ToString());
                sb.AppendLine("______________________________________________________________________");
            }
            i = 0;
            foreach (Wypozyczenie p in Listawypozyczen)
            {

                sb.AppendLine($"Wypozyczenie NR.: {++i}");
                sb.AppendLine(p.ToString());
                sb.AppendLine("______________________________________________________________________");
            }
            return sb.ToString();
        }

        public static void ZapisXML(Biblioteka m, string nazwaPliku)
        {

            var serializer = new XmlSerializer(typeof(Biblioteka));
            var sw = new StreamWriter(nazwaPliku);
            serializer.Serialize(sw, m);
            sw.Close();


        }
        public static Biblioteka OdczytXML(string nazwa)
        {
            Biblioteka Odczytany;
            var fs = new FileStream(nazwa, FileMode.Open);
            var bf = new XmlSerializer(typeof(Biblioteka));
            Odczytany = (Biblioteka)bf.Deserialize(fs);
            fs.Close();
            return Odczytany;
        }
        public void Wypozycz(Ksiazka k, Osoba o)
        {
            Wypozyczenie w = new Wypozyczenie();
            w.Ksiazka = k;
            w.Osoba = o;
            k.IloscWypozyczen++;
            Listawypozyczen.Add(w);
        }
        public List<Wypozyczenie> ArchiwumWypozyczen()
        {
            return Listawypozyczen;
        }
    }
}
