using System;

namespace BibliotekaPPO
{



    public class Osoba

    {

        string imie;

        string nazwisko;

        DateTime dataUr;
        /// <summary>

        /// abstrakcyjna klasa osoba
        /// <param imie="Imię"></param>
        /// <param nazwisko="Nazwisko"></param>
        /// <param dataUr="Data Urodzenia"></param>
        /// </summary>


        /// <summary>

        /// szereg konstruktorów w klasie osoba

        /// </summary>

        public string Imie

        {

            get { return imie; }

            set { imie = value; }

        }

        public string Nazwisko

        {

            get { return nazwisko; }

            set { nazwisko = value; }

        }

        public DateTime DataUr

        {

            get { return dataUr; }

            set { dataUr = value; }

        }

        /*public Plec Plec

        {

            get { return plec; }

            set { plec = value; }

        }*/



        public Osoba()

        {



        }

        /// <summary>

        /// konstruktor parametryczny klasy osoba

        /// </summary>

        public Osoba(string i, string n, string d /*Plec p*/)

        {

            this.imie = i;

            this.nazwisko = n;

            this.dataUr = Convert.ToDateTime(d);

            //this.plec = p;



        }

        /// <summary>

        /// metoda obliczająca i zwracająca wiek danej osoby

        /// </summary>

        public int Wiek()

        {

            DateTime data = Convert.ToDateTime(dataUr);

            return (DateTime.Now.Year - data.Year);

        }

        public override string ToString()
        {
            return "Imie: " + imie + "\nNazwisko: " + Nazwisko + "\nData Urodzenia: " + DataUr;
        }
    }
}

