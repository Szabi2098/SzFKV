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
        public Data(int hely, string nev, float elsoLeng, float masoLeng, float harmLeng, int legjob)
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
        public float ElsoLeng { get; set; }
        public float MasoLeng { get; set; }
        public float HarmLeng { get; set; }
        public int Legjob { get; set; }
    }
}
