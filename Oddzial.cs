using System.Collections.Generic;

namespace BibliotekaPPO
{
    public class Oddzial
    {
        private string identyfikator;
        private string nazwaOdzialu;
        private List<Biblioteka> listaBibliotek;
        public string Identyfikator { get => identyfikator; set => identyfikator = value; }
        public string NazwaOdzialu { get => nazwaOdzialu; set => nazwaOdzialu = value; }
        public List<Biblioteka> ListaBibliotek { get => listaBibliotek; set => listaBibliotek = value; }

        public Oddzial()
        {
            Identyfikator = "100Mazwosze";
            NazwaOdzialu = null;
            ListaBibliotek = new List<Biblioteka>();
        }

        public Oddzial(string i) : this()
        {
            NazwaOdzialu = i;

        }

        public void DodajBiblioteke(Biblioteka b)
        {
            ListaBibliotek.Add(b);
        }


    }
}
