using System.Collections.Generic;

namespace BibliotekaPPO
{
    interface IBiblioteka
    {
        /// <summary>

        /// implementacja interfejsu z metodami

        /// </summary>
        void DodajKsiazke(Ksiazka k);
        Ksiazka UsunKsiazke(int kodksiazki);
        List<Ksiazka> Filtruj(string r);

    }
}
