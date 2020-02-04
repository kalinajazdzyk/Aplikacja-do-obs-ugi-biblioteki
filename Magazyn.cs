using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BibliotekaPPO
{
    [Serializable]
    public class Magazyn : IBiblioteka, ICloneable, IEquatable<Magazyn>
    {
        private string nazwa;
        private string adres;
        private List<Ksiazka> listaksiazek;
        private int iloscKsiazek;


        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Adres { get => adres; set => adres = value; }
        public List<Ksiazka> Listaksiazek { get => listaksiazek; set => listaksiazek = value; }
        public int IloscKsiazek { get => iloscKsiazek; set => iloscKsiazek = value; }
        public Magazyn()
        {
            Listaksiazek = new List<Ksiazka>();
        }
        public Magazyn(string n) : this()
        {
            Nazwa = n;
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

            return sb.ToString();
        }

        public static void ZapisXML(Magazyn m, string nazwaPliku)
        {

            var serializer = new XmlSerializer(typeof(Magazyn));
            var sw = new StreamWriter(nazwaPliku);
            serializer.Serialize(sw, m);
            sw.Close();


        }
        public static Magazyn OdczytXML(string nazwa)
        {
            Magazyn zespolOdczytany;
            var fs = new FileStream(nazwa, FileMode.Open);
            var bf = new XmlSerializer(typeof(Magazyn));
            zespolOdczytany = (Magazyn)bf.Deserialize(fs);
            fs.Close();
            return zespolOdczytany;
        }
        public object Clone()
        {
            return this.MemberwiseClone();

        }

        public Magazyn DeepCopy()
        {

            Magazyn z = new Magazyn("Nowy");
            foreach (Ksiazka c in this.Listaksiazek)
            {
                z.DodajKsiazke((Ksiazka)c.Clone());
            }

            return z;
        }

        public bool Equals(Magazyn obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else if (obj.Listaksiazek.Count() == this.Listaksiazek.Count())
            {

                return true;
            }
            return false;

        }
    }
}
