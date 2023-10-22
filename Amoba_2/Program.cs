using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoba_2
{
    class Program
    {
        public static string Jatekos1;
        public static string Jatekos2;
        public static int aktualisJatekos = 1;        // 1-et tartalmaz: jatekos1 ha 2-t tartalmaz akkor jatekos2
        public static string[,] palya = new string[3,3]; // 3x3-as mátrix: ha 0-át tartalmaz akkor üres mező, 1-es tartalmaz akkor 1-es játékos, 2-őt tartalmaz akkor 2-es játékos 

        public static void NevBeker()
        {
            Console.WriteLine("Kérem az első játékos nevét");
            Jatekos1 = Console.ReadLine();
            Console.WriteLine("Kérem az második játékos nevét");
            Jatekos2 = Console.ReadLine();
        }

        public static void DisplayClass()
        {
            Console.WriteLine("Játékosok nevei:");
            Console.WriteLine(Jatekos1);
            Console.WriteLine(Jatekos2);
            Console.WriteLine("Aktuális játékos: ");
            if (aktualisJatekos == 1) { Console.WriteLine(Jatekos1); }
            else if (aktualisJatekos == 2) { Console.WriteLine(Jatekos2); }
            else { Console.WriteLine("Nem jó adat!"); }
            Console.WriteLine("Az aktuális pálya: ");
            PalyaKirajzol();
        }

        public static void PalyaKirajzol()
        {
            Console.Clear();
            for (int i = 0; i < palya.GetLength(0); i++)
            {
                int n = 0;
                for (int j = 0; j < palya.GetLength(1); j++)
                {
                    if (i == 0&&n == 0) { Console.Write("  "); }
                    if (i == 0) { Console.Write("|_" + Convert.ToChar(65 + n) + "_"); }
                    n++;
                    if (i == 0 && n == palya.GetLength(0)) { Console.Write("|"); Console.WriteLine(); }
                }
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0) { Console.Write((i + 1).ToString() +" "); }
                    if (palya[i, j] == "0") { Console.Write("|___"); }
                    else if (palya[i, j] == "1") { Console.Write("|_X_"); }
                    else if (palya[i, j] == "2") { Console.Write("|_O_"); }
                    else { Console.Write("| ? "); }
                }
                Console.WriteLine("|");
            }
        }

        public static void PalyaInicializal()
        {
            for (int i = 0; i < palya.GetLength(0); i++)
            {
                for (int j = 0; j < palya.GetLength(1); j++)
                {
                    palya[i, j] = "0";
                }
            }
        }

        public static int NyeroSor( int sor )
        {
            bool nyert1 = false;
            bool nyert2 = false;
            for (int j = 0; j < palya.GetLength(1)-2; j++)
            {
                if (palya[sor, j] == "1" && palya[sor,j+1]=="1" && palya[sor,j+2]=="1") { nyert1 = true; }
                if (palya[sor, j] == "2" && palya[sor, j + 1] == "2" && palya[sor, j + 2] == "2") { nyert2 = true; }
            }
            if (nyert1) { return 1; }
            else if (nyert2) { return 2; }
            else { return 0;  }
        }

        public static int NyeroOszlop(int oszlop)
        {
            bool nyert1 = false;
            bool nyert2 = false;
            for (int i = 0; i < palya.GetLength(0) - 2; i++)
            {
                if (palya[i, oszlop] == "1" && palya[i+1, oszlop] == "1" && palya[i+2, oszlop] == "1") { nyert1 = true; }
                if (palya[i, oszlop] == "2" && palya[i+1, oszlop] == "2" && palya[i+2, oszlop] == "2") { nyert2 = true; }
            }
            if (nyert1) { return 1; }
            else if (nyert2) { return 2; }
            else { return 0; }
        }

        public static int NyeroAtlo( int atlo )
        {
            return 0;
        }

        public static int KiNyert()
        {
            bool nyert1 = false;
            bool nyert2 = false;
            int nyertes, i, j;

            for ( i = 0; i < palya.GetLength(0); i++)
            {
                if ((nyertes = NyeroSor(i)) > 0) { return nyertes; }
            }
            for (j = 0; j < palya.GetLength(1); j++)
            {
                if ((nyertes = NyeroOszlop(j)) > 0) { return nyertes; }
            }
            for (i = 0; i < palya.GetLength(1); i++)
            {
                if ((nyertes = NyeroAtlo(i)) > 0) { return nyertes; }
            }
            return 0;
        }

        public static (bool, int, int) ErvenyesLepes(string lepes)
        {
            char[] Lepes = new char[2];
            Lepes = lepes.ToCharArray();
            char Hkar = ' ';
            int Hint = 0;
            int Vint = 0;
            bool ervenyes = true;

            Hkar = Lepes[0];
            Vint = Convert.ToInt32(Lepes[1].ToString())-1;
            switch (Hkar)
            {
                case 'a': Hint = 0; break;
                case 'b': Hint = 1; break;
                case 'c': Hint = 2; break;
                default: Hint = 3; break;
            }
            if ((Hint > 2 || Hint < 0) || (Vint > 2 || Vint < 0))
            {        
                ervenyes = false;
            }

            if (Convert.ToInt32(palya[Vint, Hint]) > 0)
                { ervenyes = false;  }

            return (ervenyes, Vint, Hint );
        }

        public static void JatekosValtas()
        {
            if (aktualisJatekos == 1) 
                { aktualisJatekos = 2; }
            else 
                { aktualisJatekos = 1; }
        }

        public static string AktualisJatekosNeve()
        {
            if (aktualisJatekos == 1)
                { return Jatekos1;  }
            else
                { return Jatekos2; }
        }

        public static void KovetkezoLepesBeker()
        {
            bool ervenyes; int x; int y;
            do
            {
                Console.WriteLine("Kedves " + AktualisJatekosNeve() + " kérem lépjen!");
                string lepes = Console.ReadLine().ToLower();
                (ervenyes, x, y) = ErvenyesLepes(lepes);
                if (!ervenyes)
                    { Console.WriteLine("Ervenytelen lepes, kérlek újra add meg a lépésed!"); }
            } while (!ervenyes);
            palya[x, y] = Convert.ToString(aktualisJatekos);

            JatekosValtas();

        }
        public static void GyoztesDicser()
        {
            int kiNyert = KiNyert();
            Console.WriteLine("Nagyon szuper vagy {0}!", kiNyert == 1 ? Jatekos1 : Jatekos2);
        }

        static void Main(string[] args)
        {
            PalyaInicializal();
            NevBeker();
            DisplayClass();
            while (KiNyert()==0)
            {
                KovetkezoLepesBeker();
                PalyaKirajzol();
            }
            GyoztesDicser();
            Console.ReadKey();
        }
    }
}
