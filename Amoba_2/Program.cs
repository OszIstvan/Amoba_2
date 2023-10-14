﻿using System;
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
            for (int i = 0; i < 3; i++)
            {
                //if (i == 0) { Console.Write("|"); }
                for (int j = 0; j < 3; j++)
                {
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

        public static int KiNyert()
        {
            // TODO!!!
            int kiNyert = 0;
            if (palya[0, 0] == "X" && palya[0, 1] == "X" && palya[0, 2] == "X") { kiNyert = 1; }
            else if (palya[0, 0] == "O" && palya[0, 1] == "O" && palya[0, 2] == "O") { kiNyert = 2; }
            return kiNyert;
        }

        public static void LepesRegisztral(string lepes)
        {
            //  TODO!!!
            //Console.WriteLine("Léptem");
            //palya[1, 2] = Convert.ToString(aktualisJatekos);
            string[] Lepes = lepes.Split(' ');
            string Hlepes = Lepes[0];
            int HLepes=0;
            switch (Hlepes)
            {
                case "a": HLepes = 0; break;
                case "b": HLepes = 1; break;
                case "c": HLepes = 2; break;
                default: Console.WriteLine("Nem megfelelő adatbevitel!/nKérem próbálja újra!"); break;
            }
            int VLepes = Convert.ToInt32(Lepes[1]);
            palya[HLepes, VLepes] = Convert.ToString(aktualisJatekos); 
        }
        public static void KovetkezoLepesBeker()
        {
            if (aktualisJatekos == 1) { 
                Console.WriteLine("Kedves "+Jatekos1+" kérem lépjen! A mező koordinátáit szóközzel elválasztva adja meg!"); 
                string lepes=Console.ReadLine();
                LepesRegisztral(lepes);
                aktualisJatekos = 2;
            }
            else if (aktualisJatekos == 2)
            {
                Console.WriteLine("Kedves " + Jatekos2 + " kérem lépjen! A mező koordinátáit szóközzel elválasztva adja meg!");
                string lepes = Console.ReadLine();
                LepesRegisztral(lepes);
                aktualisJatekos = 1;
            }
        }
        public static void GyoztesDicser()
        {
            Console.WriteLine("Nagyon szuper vagy!");
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
