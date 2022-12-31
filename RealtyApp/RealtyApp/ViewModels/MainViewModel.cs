using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MvvmHelpers;

namespace RealtyApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public IList<AdvertViewModel> Adverts   { get; set; }
        public MainViewModel()
        {
            Adverts = new ObservableRangeCollection<AdvertViewModel>() {
                new AdvertViewModel()
                {
                    id = 0,
                    Name = "260 000 р.",
                    Address = "ул. Пушкина 10",
                    AllSquare = 45,
                    Desc = "2-комн. кв. · 51 м · 3/8 этаж",
                    ImageUrl = "https://realt.by/uploads/pics/9c84ea33dd_01.jpg",
                    isFeatured = false
                },                
                new AdvertViewModel()
                {
                    id = 1,
                    Name = "290 000 р.",
                    Address = "ул. Колесникова 12",
                    AllSquare = 90,
                    Desc = "2-комн. кв. · 51 м · 3/8 этаж",
                    ImageUrl = "https://realt.by/uploads/pics/37935d698a.jpg",
                    isFeatured = false
                },
                new AdvertViewModel()
                {
                    id = 0,
                    Name = "350 000",
                    Address = "ул. Брестская 43",
                    AllSquare = 150,
                    Desc = "2-комн. кв. · 51 м · 3/8 этаж",
                    ImageUrl = "https://realt.by/typo3temp/pics/fd/01/fd01858382085b038e03d630169d31cb.jpg",
                    isFeatured = false
                },                
                new AdvertViewModel()
                {
                    id = 0,
                    Name = "300 000",
                    Address = "ул. Матусевича 32",
                    AllSquare = 40,
                    Desc = "2-комн. кв. · 51 м · 3/8 этаж",
                    ImageUrl = "https://realt.by/uploads/pics/b8b4eb5760.jpg",
                    isFeatured = false
                },
                new AdvertViewModel()
                {
                    id = 0,
                    Name = "200 000",
                    Address = "ул. Матусевича 32",
                    AllSquare = 40,
                    Desc = "2-комн. кв. · 51 м · 3/8 этаж",
                    ImageUrl = "https://realt.by/typo3temp/pics/23/3f/233fd0f71f1bdc7f5a10775c78e6c620.jpg",
                    isFeatured = false
                }
            };
        }
    }
}
