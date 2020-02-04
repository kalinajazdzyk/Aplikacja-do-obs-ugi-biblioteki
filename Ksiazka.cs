using System;
using System.Data.SqlClient;
using System.Globalization;

namespace BibliotekaPPO
{/// <summary>
/// Opisywanie struktury klasy ksiazki 
/// </summary>
    [Serializable]
    public class Ksiazka
    {
        private string nazwa;
        private string autor;
        private int iloscWypozyczen;
        private DateTime dataWydania;
        private jezykKsiazki jezyk;
        private int kodKsiazki = 1000;
        private string opis;
        private StanBierzacy Stan;
        private Stan Jakistan;
        private gatunekKsiazki gatunek;

        /// <summary>
        /// Tworzenie podstawowych pól klasy Ksiazka
        /// <param nazwa = "Nazwa ksiązki"></param>
        /// <param autor = "Autor ksiązki"></param>
        /// <param dataWydania = "Data wydania ksiązki"></param>
        /// <param jezyk = "Język ksiązki"></param>
        /// <param kodKsiazki = "Kod ksiązki"></param>
        /// <param opis = "Opis ksiązki"></param>
        /// <param Stan = "Stan wypożycenia"></param>
        /// <param Jakistan = "Stan ksiązki"></param>
        /// <param gatunek = "Gatunek ksiązki"></param>
        /// </summary>

        //element bazy danych
        private SqlConnection polaczenie;


        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Autor { get => autor; set => autor = value; }
        public int IloscWypozyczen { get => iloscWypozyczen; set => iloscWypozyczen = value; }
        public DateTime DataWydania { get => dataWydania; set => dataWydania = value; }
        public int KodKsiazki { get => kodKsiazki; set => kodKsiazki = value; }
        public jezykKsiazki Jezyk { get => jezyk; set => jezyk = value; }
        public string Opis { get => opis; set => opis = value; }
        public StanBierzacy stan { get => Stan; set => Stan = value; }
        public Stan jakistan { get => Jakistan; set => Jakistan = value; }
        public gatunekKsiazki Gatunek { get => gatunek; set => gatunek = value; }


        /// <summary>
        /// konstruktor nieparametryczny klasy ksiazka
        /// </summary>
        public Ksiazka()
        {
            this.nazwa = "";
            this.autor = null;
            this.IloscWypozyczen = 0;
            this.dataWydania = DateTime.Now;
            KodKsiazki ++;
            opis = null;


        }

        public Ksiazka(string n, string a, StanBierzacy s) : this()
        {
            nazwa = n;
            autor = a;
            stan = s;
        }
        public Ksiazka(string n, string a, StanBierzacy s, Stan k, jezykKsiazki j) : this()
        {
            nazwa = n;
            autor = a;
            stan = s;
            jakistan = k;
            Jezyk = j;


        }
        public Ksiazka(string opis) : this()
        {
            this.opis = opis;


        }
        public Ksiazka(string a, string n, string d) : this()
        {

            nazwa = n;
            autor = a;
            DateTime data;
            DateTime.TryParseExact(d, new[] { "yyyy-mm-dd", "yyyy/mm/dd", "mm/dd/yyyy", "dd-mmm-yy" }, null, DateTimeStyles.None, out data);
            dataWydania = data;
        }
        //"Kod: " + KodKsiazki + 
        public override string ToString()
        {
            return "\nAutor: " + Autor + "\nTytuł: " + Nazwa + "\nStan: " + jakistan.ToString() + "\nGdzie: " + stan + "\nOpis:" + Opis + "\nJęzyk: " + Jezyk;
        }

        public object Clone()
        {
            return this.MemberwiseClone();

        }





        //próby bazy danych
        public Ksiazka(string user, string pass, string instance, string dbdir)
        {
            polaczenie = new SqlConnection();
            //polaczenie.ConnectionString = "";
            polaczenie.ConnectionString = "user id=" + user + ";" +
            "password=" + pass + ";Data Source=" + instance + ";" +
            "Trusted_Connection=no;" +
            "database=" + dbdir + "; " +
            "connection timeout=3";
            polaczenie.Open();
        }


        public Ksiazka(string instance, string dbdir)
        {
            polaczenie = new SqlConnection();
            //polaczenie.ConnectionString = "";
            polaczenie.ConnectionString = "Data Source=" + instance + ";" +
            "Trusted_Connection=yes;" +
            "database=" + dbdir + "; " +
            "connection timeout=3";
            polaczenie.Open();

        }




    }
}
