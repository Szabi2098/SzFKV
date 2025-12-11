using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzFKV.Controllers;

namespace SzFKV.Models
{
    internal class Data
    {
        public Data(int hely, string nev, int elsoLeng, int masoLeng, int harmLeng, int legjob)
        {
            Hely = hely;
            Nev = nev;
            ElsoLeng = elsoLeng;
            MasoLeng = masoLeng;
            HarmLeng = harmLeng;
            Legjob = legjob;
        }

        public int Hely { get; set; }
        public string Nev { get; set; }
        public int ElsoLeng { get; set; }
        public int MasoLeng { get; set; }
        public int HarmLeng { get; set; }
        public int Legjob { get; set; }
    }
}
