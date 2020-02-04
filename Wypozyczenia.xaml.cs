using BibliotekaPPO;
using System.Collections.Generic;
using System.Windows;

namespace Oblsuga
{
    /// <summary>
    /// Logika interakcji dla klasy Wypozyczenia.xaml
    /// </summary>
    public partial class Wypozyczenia : Window
    {

        //ObservableCollection<Wypozyczenia> lista;

        Biblioteka biblioteka = new Biblioteka();
        List<Wypozyczenie> lista1 = new List<Wypozyczenie>();

        public Wypozyczenia()
        {
            InitializeComponent();
            biblioteka = (Biblioteka)Biblioteka.OdczytXML("biblioteka1.xml");
            lista1 = biblioteka.Listawypozyczen;
            foreach (Wypozyczenie element in lista1)
            {
                listbox_wypozyczen.Items.Add(element);
            }

            //listbox_wypozyczen.ItemsSource = lista;
        }


    }
}
