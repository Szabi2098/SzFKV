using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SzFKV.Models;

namespace SzFKV.Controllers
{
    internal class SQLController
    {
        public List<Data> Kiir()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "server=localhost;database=szfkv;uid=root;pwd=;";
            connection.ConnectionString = connectionString;

            connection.Open();
            string sql = "SELECT * FROM szfkv ORDER BY hely ASC;";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            List<Data> adat = new List<Data>();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Data d = new Data(
                    hely: reader.GetInt32("hely"),
                    nev: reader.GetString("nev"),
                    elsoLeng: 10f - (float)Math.Round(reader.GetFloat("elsoLeng"), 0),
                    masoLeng: 10f - (float)Math.Round(reader.GetFloat("masoLeng"), 0),
                    harmLeng: 10f - (float)Math.Round(reader.GetFloat("harmLeng"), 0),
                    legjob: reader.GetInt32("legjob")
                );
                adat.Add(d);
            }
            connection.Close();

            return adat;
        }

        public void Beszur(int hely, string nev, float elso, float msdk, float hrmdk)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "server=localhost;database=szfkv;uid=root;pwd=;";
            connection.ConnectionString = connectionString;

            connection.Open();
            string insertSql = "INSERT INTO `szfkv` VALUES (@hely,@nev,@elsoLeng,@masoLeng,@harmLeng,null,null)";
            MySqlCommand insertcmd = new MySqlCommand(insertSql, connection);
            insertcmd.Parameters.AddWithValue("@hely", hely);
            insertcmd.Parameters.AddWithValue("@nev", nev);
            insertcmd.Parameters.AddWithValue("@elsoLeng", elso);
            insertcmd.Parameters.AddWithValue("@masoLeng", msdk);
            insertcmd.Parameters.AddWithValue("@harmLeng", hrmdk);
            insertcmd.Parameters.AddWithValue("@legjob\t", null);
            int sorok = insertcmd.ExecuteNonQuery();
            connection.Close();

        }

        public void UpdSorrend() 
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "server=localhost;database=szfkv;uid=root;pwd=;";
            connection.ConnectionString = connectionString;

            connection.Open();
            string sql = "ALTER TABLE szfkv ADD COLUMN temp_rank INT; UPDATE szfkv v JOIN (SELECT hely, ROW_NUMBER() OVER (ORDER BY legjob DESC) AS new_rank FROM szfkv) ranked ON v.hely = ranked.hely SET v.temp_rank = ranked.new_rank; UPDATE szfkv SET hely = temp_rank; ALTER TABLE szfkv DROP COLUMN temp_rank;\r\n";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}
