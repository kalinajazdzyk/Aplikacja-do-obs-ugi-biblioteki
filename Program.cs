using System;

namespace BibliotekaPPO
{
    public enum StanBierzacy { wypozyczone, na_polce, brak };
    public enum Stan { zniszczona, dobry, bardzodobry };
    public enum jezykKsiazki { polski, angielski, francuski, rosyjski, hiszpanski, inny };
    public enum gatunekKsiazki { Kryminal, Poradnik, Obyczajowe, Poezja, Opowiadania, Czasopisma, Fantastyka, Romans, Mlodziezowe, Jezykowe, Dramat, Ciezko_sklasyfikowac, Akcji, Mangi };
    class Program
    {
        static void Main(string[] args)
        {

            Osoba osoba = new Osoba("Marek", "Makowski", "12-01-2000");
            Ksiazka ksiazka1 = new Ksiazka();
            Ksiazka ksiazka2 = new Ksiazka("Bieguni", "Olga Tokarczuk", StanBierzacy.na_polce, Stan.bardzodobry, jezykKsiazki.polski);
            Ksiazka ksiazka3 = new Ksiazka("Harry Potter i Kamień Filozoficzny", "J.K. Rowling", StanBierzacy.na_polce, Stan.dobry, jezykKsiazki.angielski);
            Ksiazka ksiazka4 = new Ksiazka("Szczygieł", "Danna Tartt", StanBierzacy.brak, Stan.bardzodobry, jezykKsiazki.polski);
            ksiazka1.Autor = "Jan Kochanowski";
            ksiazka1.Nazwa = "Wiersze wybrane";
            ksiazka1.stan = StanBierzacy.na_polce;


            Biblioteka b1 = new Biblioteka();
            b1.Nazwa = "Biblioteka Publiczna nr 13";
            b1.DodajKsiazke(ksiazka1);
            b1.DodajKsiazke(ksiazka2);
            b1.DodajKsiazke(ksiazka3);
            b1.DodajKsiazke(ksiazka4);
            b1.Wypozycz(ksiazka1, osoba);
            Console.WriteLine(b1);
            Biblioteka.ZapisXML(b1, "biblioteka.xml");
            Console.WriteLine("=========Zapisano=========");

            Console.WriteLine(b1.Listawypozyczen);
            Console.WriteLine(b1.Listaksiazek);



            /*
            System.Data.SqlClient.SqlConnection MSDEconn;
            MSDEconn = new SqlConnection();
            MSDEconn.ConnectionString = @"workstation id=KOMPUTER; packet size=4096; integrated security=SSPI; data source=KOMPUTER\NASZA_BAZA; persist security info=False; initial catalog=baza_testowa";
            MSDEconn.Open();
            System.Data.SqlClient.SqlCommand MSDEcommand = new SqlCommand();
            MSDEcommand.Connection = MSDEconn;
            MSDEcommand.CommandText = "SELECT wartosc FROM tabela WHERE id = 10";
            string wartosc = null;
            SqlDataReader reader = MSDEcommand.ExecuteReader();
            if (reader.Read())
                wartosc = reader.GetInt32(0).ToString();
            reader.Close();
            */
            Console.ReadLine();
        }

    }
}
