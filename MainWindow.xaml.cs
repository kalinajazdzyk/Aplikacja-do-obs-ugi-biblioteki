using BibliotekaPPO;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Oblsuga
{

    public partial class MainWindow : Window
    {
        public Biblioteka biblioteka = new Biblioteka();
        ObservableCollection<Ksiazka> lista;
        Ksiazka k1 = new Ksiazka();
        public MainWindow()
        {
            InitializeComponent();
            biblioteka = (Biblioteka)Biblioteka.OdczytXML("biblioteka.xml");
            lista = new ObservableCollection<Ksiazka>(biblioteka.Listaksiazek);
            textbox_nazwa_biblioteki.Text = biblioteka.Nazwa;

            listbox_ksiazek.ItemsSource = lista;
            button_Dodaj.Click += button_Dodaj_Click;
            button_Usun.Click += button_Usun_Click;
            /*button_Zmien.Click += button_Zmien_Click;*/
        }
        private void button_Dodaj_Click(object sender, RoutedEventArgs e)
        {

            Ksiazka cz = new Ksiazka();
            KsiazkaWindow okno = new KsiazkaWindow(cz);
            okno.ShowDialog();
            if (okno.textbox_nazwa_ksiazki.Text != "" && okno.textbox_autor.Text != "" && okno.textbox_dataWydania.Text != "")

            {
                
                biblioteka.DodajKsiazke(cz);
                lista.Add(cz);

            }

        }
        /*private void button_Zmien_Click(object sender, RoutedEventArgs e)
        {
            OsobaWindow okno = new OsobaWindow(zespol.Kierownik);
            okno.ShowDialog();
            textbox_kierownik.Text = zespol.Kierownik.ToString();
        }*/

        private void button_Usun_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listbox_ksiazek.SelectedIndex;
            lista.RemoveAt(zaznaczony);
            biblioteka.Listaksiazek.RemoveAt(zaznaczony);
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                biblioteka.Nazwa = textbox_nazwa_biblioteki.Text;
                Biblioteka.ZapisXML(biblioteka, filename);
            }
        }
        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                biblioteka.Nazwa = textbox_nazwa_biblioteki.Text;
                Biblioteka.OdczytXML(filename);
            }
        }
        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Zmien_Click(object sender, RoutedEventArgs e)
        {
            MenuOtworz_Click(sender, e);

        }

        private void button_Edytuj_Dane_Click(object sender, RoutedEventArgs e)
        {

            int zaznaczony = listbox_ksiazek.SelectedIndex;


            if (zaznaczony == -1)
            {
                MessageBox.Show("Nie zaznaczyłeś żadnej książki!");
            }
            else
            {

                k1 = lista[zaznaczony];
                KsiazkaWindow k = new KsiazkaWindow(k1);
                k.ShowDialog();
                lista.RemoveAt(zaznaczony);
                lista.Insert(zaznaczony, k1);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ksiazka baza = new Ksiazka("test", "test", "localhost\\s2012n", "zajecia");
        }
        private void button_PokazListeWypozyczen_Click(object sender, RoutedEventArgs e)
        {

            Wypozyczenia k = new Wypozyczenia();
            k.ShowDialog();

        }
    }
}
