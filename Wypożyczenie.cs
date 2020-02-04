using System;
using System.Globalization;

namespace BibliotekaPPO
{
    public class Wypozyczenie
    {
        private Osoba osoba;
        private Ksiazka ksiazka;
        private DateTime dataWypozyczenia;
        /// <summary>
        /// <param osoba = "Dane osoby wypożyczającej"></param>
        /// <param ksiazka = "Wypożyczana ksiązka"></param>
        /// <param dataWypozyczenia = "Data wypożyczenia"></param>
        /// </summary>
        public Osoba Osoba { get => osoba; set => osoba = value; }
        public Ksiazka Ksiazka { get => ksiazka; set => ksiazka = value; }
        public DateTime DataWypozyczenia { get => dataWypozyczenia; set => dataWypozyczenia = value; }

        public Wypozyczenie()
        {
            DataWypozyczenia = DateTime.Now;

        }

        public Wypozyczenie(Osoba o1, Ksiazka k1, string d) : this()
        {
            this.Osoba = o1;
            this.Ksiazka = k1;
            DateTime data;
            DateTime.TryParseExact(d, new[] { "yyyy-mm-dd", "yyyy/mm/dd", "mm/dd/yyyy", "dd-mmm-yy" }, null, DateTimeStyles.None, out data);
            dataWypozyczenia = data;
        }

        public override string ToString()
        {

            return "Data wypożyczenia: " + DataWypozyczenia + "\nOsoba: " + "\n-----\n" + Osoba.ToString() + "\nKsiazka: " + "\n-------\n" + "\nKod Książki: " + Ksiazka.KodKsiazki + "\nNazwa Książki: " + Ksiazka.Nazwa + "\nAutor Książki: " + Ksiazka.Autor;
        }

    }
}
