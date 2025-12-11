using menu.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SzFKV.Controllers;
using SzFKV.Models;
using System.IO;


namespace SzFKV
{
    internal class Program
    {
        static void Main()
        {
            Console.Clear();

            CenterEngine.Show(
                "Szélesbálási Fedettpályás Kalaplengető Verseny",
                "",
                "1: Eredmények",
                "2: Új eredmény",
                "3: Kilépés"
            );
            string ans = CenterEngine.ReadCentered("");

            if (ans == "1")
            {
                Eredmenyek();
            }
            else if (ans == "2")
            {
                UjEredmeny();
            }
            else if (ans == "3")
            {
                Console.Clear();
                CenterEngine.Show(
                    "Biztos ki szeretne lépni?",
                    "",
                    "1: Igen",
                    "2: Nem"
                );
                string ans2 = CenterEngine.ReadCentered("");

                if (ans2 == "1")
                {
                    Environment.Exit(0);
                }
                else if (ans2 == "2")
                {

                    Main();
                }
            }
            else 
            {
                CenterEngine.ReadCentered("Érvénytelen menüpont");
                Main();
            }

            Console.ReadLine();
        }

        static void UjEredmeny()
        {
            Console.Clear();

            List<Data> adat = new SQLController().Kiir();
            CenterEngine.Show("*** Új eredmény rögzítése ***");

            string nev = CenterEngine.ReadCentered("Név:");
            float elso = float.Parse(CenterEngine.ReadCentered("Első:"));
            float masodik = float.Parse(CenterEngine.ReadCentered("Második:"));
            float harmadik = float.Parse(CenterEngine.ReadCentered("Harmadik:"));

            int maxHely = adat.Max(x => x.Hely);
            int hely = maxHely + 1;


            new SQLController().Beszur(hely, nev, elso, masodik, harmadik);
            new SQLController().UpdSorrend();

            CenterEngine.Show(
                "1: Új eredmény",
                "any: Menü"
            );
            string ans = CenterEngine.ReadCentered("");

            if (ans == "1")
            {
                UjEredmeny();
            }
            else
            {
                Main();
            }

        }

        static void Eredmenyek()
        {
            Console.Clear();

            CenterEngine.Show(
                "1: Frissítés",
                "any: Menü"
            );
            CenterEngine.Show("\n");

            List<Data> adat = new SQLController().Kiir();
            foreach (var user in adat)
            {
                CenterEngine.Show($"{user.Hely} | {user.Nev} | {user.ElsoLeng} | {user.MasoLeng} | {user.HarmLeng} | {user.Legjob}");
            }

            string ans = CenterEngine.ReadCentered("");

            if (ans == "1")
            {
                new SQLController().UpdSorrend();
                HTML();
                Eredmenyek();
            }
            else
            {
                Main();
            }
        }

        static void HTML()
        {
            List<Data> adat = new SQLController().Kiir();

            string filePath = @"D:\VS\SzFKV\SzFKV.html";

            var html = @"
<!DOCTYPE html>
<html lang='hu'>
    <head>
        <meta charset='UTF-8'>
        <title>Szélesbálási Kalaplengető Verseny</title>
        <style>
            table { margin-left: auto; margin-right: auto; }
            body { background-image: url(bg.png); background-size: cover; background-position: center; background-repeat: no-repeat; background-attachment: fixed; }
            thead { background: rgba(255, 255, 255, 0.4); color: rgb(0,0,0); }
            tbody { background: rgba(255,217,0,0.4); color: rgb(0,0,0); }
        </style>
    </head>
    <body>
        <div style='text-align: center;'>
            <div style='text-align: center; display: flex; justify-content: center; align-items: center; gap: 20px; margin-bottom: 20px;'>
                <img src='traktoros_cimer_buzakalasszal.png' alt='Left' style='height: 80px;'>
                <h1>Szélesbálási Fedettpályás Kalaplengető Verseny</h1>
            <img src='traktoros_cimer_buzakalasszal.png' alt='Right' style='height: 80px;'>
            </div>
        <h3>Pontszám:</h3>
        <table border='1' cellspacing='0' cellpadding='6'>
            <thead>
                <tr>
                    <th>Pillanatnyi helyezés</th>
                    <th>Versenyző neve</th>
                    <th>Első lengetés pontszáma</th>
                    <th>Második lengetés pontszáma</th>
                    <th>Harmadik lengetés pontszáma</th>
                    <th>Legjobb pontszám</th>
                </tr>
            </thead>
            <tbody>";

            foreach (var user in adat)
            {
                html += $@"
                <tr>
                    <td>{user.Hely}</td>
                    <td>{user.Nev}</td>
                    <td>{user.ElsoLeng}</td>
                    <td>{user.MasoLeng}</td>
                    <td>{user.HarmLeng}</td>
                    <td>{user.Legjob}</td>
                </tr>";
            }

            html += @"
            </tbody>
        </table>
        </div>
    </body>
</html>";

            File.WriteAllText(filePath, html);
        }
    }
}





