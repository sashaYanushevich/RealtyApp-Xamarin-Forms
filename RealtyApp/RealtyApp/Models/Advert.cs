using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace RealtApp.Model
{
    public class Advert
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int AllSquare { get; set; }
        public int LiveSquare { get; set; }
        public ulong Price { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string CityRegion { get; set; }
        public string MicroDistrict { get; set; }
        public string LineMetro { get; set; }
        public string StationMetro { get; set; }
        public int CountRooms { get; set; }
        public string TypeHouse { get; set; }
        public string Renovation { get; set; }
        public string Furniture { get; set; }
        public int Floor { get; set; }
        public int MaxFloor { get; set; }
        public int YearConstruction { get; set; }
        public string Desc { get; set; }
        public DateTime Date { get; set; }
        public List<string> Images { get; set; }

        public override string ToString()
        {
            return $"{CountRooms}-комн.кв. · {AllSquare} м² · {Floor}/{MaxFloor} этаж";
        }

        //public Advert(long iD, string name, string address, int allSquare, string desc, List<string> images)
        //{
        //    ID = iD;
        //    Name = name;
        //    Address = address;
        //    AllSquare = allSquare;
        //    Desc = desc;
        //    Images = images;
        //}






        //public Advert(long id, long userID, string name, string address, int rooms, int allSquare, int liveSquare, int year, string renovation, string desc, string date)
        //{
        //    this.id = id;
        //    this.userID = userID;
        //    this.Name = name;
        //    this.Address = address;
        //    this.rooms = rooms;
        //    this.AllSquare = allSquare;
        //    this.liveSquare = liveSquare;
        //    this.year = year;
        //    this.renovation = renovation;
        //    this.Desc = desc;
        //    this.date = date;
        //}

        //private static string connStr = "server=185.87.50.136;user=Alexandr;database=RealtApp;password=qazx1234;";

        //public static bool AddAdvert(string name, string address, int rooms,int allSquare,int liveSquare,int year,string renovation,string description)
        //{
        //    try
        //    {
        //        List<string> logins = new List<string>();
        //        MySqlConnection conn = new MySqlConnection(connStr);
        //        conn.Open();
        //        string sql2 = $"INSERT INTO adverts VALUES('0','0','{name}','{address}','{rooms}','{allSquare}','{liveSquare}','{year}','{renovation}','{description}','27.10.2022')";
        //        MySqlCommand command2 = new MySqlCommand(sql2, conn);
        //        command2.ExecuteNonQuery();
        //        conn.Close();
        //        return true;
        //    }
        //    catch (Exception ex) {
        //        return false;
        //    }
        //}

        //public static bool UpdateAdvert(long id,string name, string address, int rooms, int allSquare, int liveSquare, int year, string renovation, string description)
        //{
        //    try
        //    {
        //        List<string> logins = new List<string>();
        //        MySqlConnection conn = new MySqlConnection(connStr);
        //        conn.Open();
        //        string sql2 = $"UPDATE adverts SET name = '{name}', address = '{address}' WHERE id = '{id}'";
        //        MySqlCommand command2 = new MySqlCommand(sql2, conn);
        //        command2.ExecuteNonQuery();
        //        conn.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("-----------------------\n"+ex.Message);
        //        return false;
        //    }
        //}

        //public static bool DelAdvert(long id)
        //{
        //    try
        //    {
        //        List<string> logins = new List<string>();
        //        MySqlConnection conn = new MySqlConnection(connStr);
        //        conn.Open();
        //        string sql2 = $"DELETE FROM adverts WHERE id = '{id}'";
        //        MySqlCommand command2 = new MySqlCommand(sql2, conn);
        //        command2.ExecuteNonQuery();
        //        conn.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //static public List<Advert> ReadQuestions()
        //{
        //    List<Advert> quest = new List<Advert>();
        //    try
        //    {
        //        MySqlConnection conn = new MySqlConnection(connStr);
        //        conn.Open();
        //        string sql = "SELECT * FROM adverts";
        //        MySqlCommand command = new MySqlCommand(sql, conn);
        //        MySqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            quest.Add(new Advert(
        //                Convert.ToInt32(reader[0].ToString()),
        //                Convert.ToInt32(reader[1].ToString()),
        //                reader[2].ToString(),
        //                reader[3].ToString(),
        //                Convert.ToInt32(reader[4].ToString()),
        //                Convert.ToInt32(reader[5].ToString()),
        //                Convert.ToInt32(reader[6].ToString()),
        //                Convert.ToInt32(reader[7].ToString()),
        //                reader[8].ToString(),
        //                reader[9].ToString(),
        //                reader[10].ToString()
        //            ));
        //        }
        //        reader.Close();
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    { Console.WriteLine(ex.Message); }
        //    return quest;
        //}
    }
}
