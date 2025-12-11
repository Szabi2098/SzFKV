using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzFKV.Models;
using SzFKV.Controllers;


namespace SzFKV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Data> adat = new SQLController().Kiir();
            foreach (var user in adat)
            {
                Console.WriteLine($"{user.Hely} {user.Nev} {user.ElsoLeng} {user.MasoLeng} {user.HarmLeng} {user.Legjob}");
            }
            Console.WriteLine("\n");

            Console.WriteLine("*** Új eredmény rögzítése ***");
            Console.Write(": ");
            string nev = Console.ReadLine();
            Console.Write(": ");
            int elso = int.Parse(Console.ReadLine());
            Console.Write(": ");
            int masodik = int.Parse(Console.ReadLine());
            Console.Write(": ");
            int harmadik = int.Parse(Console.ReadLine());
            int hely = 1;


            new SQLController().Beszur(hely, nev, elso, masodik, harmadik);
            new SQLController().UpdSorrend();




            

            Console.ReadLine();
        }
    }
}
