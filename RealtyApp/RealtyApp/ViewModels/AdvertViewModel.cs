using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using RealtApp.Model;
using RealtyApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySqlConnector;
using System.Text.RegularExpressions;

namespace RealtyApp.ViewModels
{
    public class AdvertViewModel : ObservableObject
    {
        private static string connStr = "server=185.87.50.136;user=Alexandr;database=RealtApp;password=qazx1234;";
        private Advert advert;
        public INavigation Navigation;
        public AdvertViewModel()
        {
            advert = new Advert();
        }
        public long ID { get => advert.ID; set => advert.ID = value; }
        public string Name { get => advert.Name; set => advert.Name = value; }
        public int AllSquare { get => advert.AllSquare; set => advert.AllSquare = value; }
        public int LiveSquare { get => advert.LiveSquare; set => advert.LiveSquare = value; }
        public ulong Price { get=>advert.Price; set=>advert.Price = value; }
        public string Region { get=>advert.Region; set=>advert.Region = value; }
        public string Country { get=>advert.Country; set=>advert.Country = value; }
        public string Street { get => advert.Street; set=>advert.Street=value; }
        public string HouseNumber { get => advert.HouseNumber; set => advert.HouseNumber = value; }
        public string CityRegion { get=>advert.CityRegion; set=> advert.CityRegion = value; }
        public string MicroDistrict { get=> advert.MicroDistrict; set=>advert.MicroDistrict=value; }
        public string LineMetro { get=>advert.LineMetro; set=>advert.LineMetro = value; }
        public string StationMetro { get=>advert.StationMetro; set=>advert.StationMetro = value; }
        public int CountRooms { get=>advert.CountRooms; set=>advert.CountRooms=value; }
        public string TypeHouse { get=>advert.TypeHouse; set=>advert.TypeHouse = value; }
        public string Renovation { get=>advert.Renovation; set=>advert.Renovation = value; }
        public string Furniture { get => advert.Furniture; set => advert.Furniture = value; }
        public int Floor { get =>advert.Floor; set=>advert.Floor = value; }
        public int MaxFloor { get=>advert.MaxFloor; set=>advert.MaxFloor = value; }
        public int YearConstruction { get=>advert.YearConstruction; set=>advert.YearConstruction = value; }
        public string Desc { get => advert.Desc; set => advert.Desc = value; }
        public DateTime Date { get=>advert.Date; set=>advert.Date = value; }
        public List<string> Images { get => advert.Images; set => advert.Images = value; }

        public string ToString
        {
            get => advert.ToString();
        }
        public string Address
        {
            get => $"ул. {Street}, {HouseNumber}";
        }
        public string PriceStr
        {
            get => Price.ToString("### ### ### ###") + " р.";
        }

        public string ShortDesc
        {
            get => Desc.Substring(0, 100) + "...";
        }

        public ICommand AdvertSelectedCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    var item = (e as AdvertViewModel);
                    // logic on item
                    INavigation navigation = item.Navigation;
                    await navigation.PushAsync(new AdvertPage(item));
                });
            }
        }

        static public List<AdvertViewModel> ReadAdverts(INavigation _navigation)
        {
            List<AdvertViewModel> adverts = new List<AdvertViewModel>();
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlConnection conn2 = new MySqlConnection(connStr);
                conn.Open();
                conn2.Open();

                string sql = "SELECT * FROM adverts";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    List<string> img = new List<string>();
                    MySqlCommand command2 = new MySqlCommand($"SELECT url FROM images WHERE id_advert = '{reader[0].ToString()}'", conn2);
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        Console.WriteLine(reader2[0].ToString());
                        img.Add(reader2[0].ToString());
                    }
                    reader2.Close();
                    adverts.Add(new AdvertViewModel()
                    {
                        Navigation = _navigation,
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Name = Convert.ToString(reader[2].ToString()),
                        AllSquare = Convert.ToInt32(reader[3].ToString()),
                        LiveSquare = Convert.ToInt32(reader[4].ToString()),
                        Price = Convert.ToUInt64(reader[5].ToString()),
                        Region = Convert.ToString(reader[6].ToString()),
                        Country = Convert.ToString(reader[7].ToString()),
                        Street = Convert.ToString(reader[8].ToString()),
                        HouseNumber = Convert.ToString(reader[9].ToString()),
                        CityRegion = Convert.ToString(reader[10].ToString()),
                        MicroDistrict = Convert.ToString(reader[11].ToString()),
                        LineMetro = Convert.ToString(reader[12].ToString()),
                        StationMetro = Convert.ToString(reader[13].ToString()),
                        CountRooms = Convert.ToInt32(reader[14].ToString()),
                        TypeHouse = Convert.ToString(reader[15].ToString()),
                        Renovation = Convert.ToString(reader[16].ToString()),
                        Furniture = Convert.ToString(reader[17].ToString()),
                        Floor = Convert.ToInt32(reader[18].ToString()),
                        MaxFloor = Convert.ToInt32(reader[19].ToString()),
                        YearConstruction = Convert.ToInt32(reader[20].ToString()),
                        Desc = Convert.ToString(reader[21].ToString()),
                        Images = img,
                    }); 
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("--------------\nERROR");
                Console.WriteLine(ex.Message);

            }
            return adverts;
            
        }


    }
}