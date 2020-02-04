using BibliotekaPPO;
using System;
using System.Globalization;
using System.Windows;

namespace Oblsuga
{

    public partial class KsiazkaWindow : Window
    {
        Ksiazka ksiazka;
        public KsiazkaWindow()
        {
            InitializeComponent();
        }
        public KsiazkaWindow(Ksiazka ksiazka) : this()

        {

            this.ksiazka = ksiazka;

            if (ksiazka != null)

            {

                textbox_nazwa_ksiazki.Text = ksiazka.Nazwa;

                textbox_autor.Text = ksiazka.Autor;



                textbox_opis.Text = ksiazka.Opis;
                textbox_dataWydania.Text = ksiazka.DataWydania.ToShortDateString();

                if ((ksiazka.stan) == StanBierzacy.na_polce)

                    combobox_stan.Text = "na półce";

                else if (ksiazka.stan == StanBierzacy.wypozyczone)

                    combobox_stan.Text = "wypozyczona";
                else
                    combobox_stan.Text = "brak";

                if (ksiazka.Jezyk == jezykKsiazki.angielski)
                    combobox_jezyk.Text = "angielski";

                else if (ksiazka.Jezyk == jezykKsiazki.francuski)
                    combobox_jezyk.Text = "francuski";

                else if (ksiazka.Jezyk == jezykKsiazki.hiszpanski)
                    combobox_jezyk.Text = "hiszpański";

                else if (ksiazka.Jezyk == jezykKsiazki.rosyjski)
                    combobox_jezyk.Text = "rosyjski";

                else if (ksiazka.Jezyk == jezykKsiazki.polski)
                    combobox_jezyk.Text = "poslki";


                else

                    combobox_jezyk.Text = "Inny";


                if (ksiazka.Gatunek == gatunekKsiazki.Akcji)
                    combobox_jezyk.Text = "Akcja";

                else if (ksiazka.Gatunek == gatunekKsiazki.Ciezko_sklasyfikowac)
                    combobox_jezyk.Text = "Ciężko sklasyfikować";

                else if (ksiazka.Gatunek == gatunekKsiazki.Czasopisma)
                    combobox_jezyk.Text = "Czasopisma";

                else if (ksiazka.Jezyk == jezykKsiazki.rosyjski)
                    combobox_jezyk.Text = "rosyjski";

                else if (ksiazka.Jezyk == jezykKsiazki.polski)
                    combobox_jezyk.Text = "poslki";


                else

                    combobox_jezyk.Text = "Inny";

                if ((ksiazka.jakistan) == Stan.bardzodobry)

                    combobox_stan.Text = "bardzo dobry";

                else if (ksiazka.jakistan == Stan.dobry)

                    combobox_stan.Text = "dobra";
                else
                    combobox_stan.Text = "zniszczona";



            }

        }
        private void button_Zatwierdz_Click(object sender, RoutedEventArgs e)

        {

            if (textbox_nazwa_ksiazki.Text == "" || textbox_autor.Text == "" || textbox_dataWydania.Text == "")

            {

                MessageBox.Show("Złe dane!!!");

                return;

            }

            this.ksiazka.Nazwa = textbox_nazwa_ksiazki.Text;

            this.ksiazka.Autor = textbox_autor.Text;

            this.ksiazka.Opis = textbox_opis.Text;


            DateTime date;

            DateTime.TryParseExact(textbox_dataWydania.Text, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out date);

            this.ksiazka.DataWydania = date;

            if (combobox_stan.Text == "na półce")

                this.ksiazka.stan = StanBierzacy.na_polce;
            else if (combobox_stan.Text == "wypożyczona")
                this.ksiazka.stan = StanBierzacy.wypozyczone;

            else

                this.ksiazka.stan = StanBierzacy.brak;


            if (combobox_stanjaki.Text == "bardzo dobry")
                this.ksiazka.jakistan = Stan.bardzodobry;
            else if (combobox_stanjaki.Text == "dobry")
                this.ksiazka.jakistan = Stan.dobry;
            else
                this.ksiazka.jakistan = Stan.zniszczona;


            if (combobox_jezyk.Text == "angielski")

                this.ksiazka.Jezyk = jezykKsiazki.angielski;
            else if (combobox_jezyk.Text == "francuski")
                this.ksiazka.Jezyk = jezykKsiazki.francuski;
            else if (combobox_jezyk.Text == "hiszpański")
                this.ksiazka.Jezyk = jezykKsiazki.hiszpanski;
            else if (combobox_jezyk.Text == "rosyjski")
                this.ksiazka.Jezyk = jezykKsiazki.rosyjski;
            else if (combobox_jezyk.Text == "poslki")
                this.ksiazka.Jezyk = jezykKsiazki.polski;

            else

                this.ksiazka.Jezyk = jezykKsiazki.inny;

            this.Close();

        }

        private void button_Anuluj_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_nazwa_ksiazki.Text == "" || textbox_autor.Text == "" || textbox_dataWydania.Text == "")

            {

                this.Close();



            }

        }


    }
}
